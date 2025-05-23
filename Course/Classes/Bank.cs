namespace Course.Classes
{
    /// <summary>
    /// Клас Bank реалізує основну логіку банківської системи. 
    /// Він відповідає за збереження та завантаження з файлу, а також
    /// управління платіжними системами, генерацією номерів, користувачами та сервісами.
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// Унікальний код банку, який використовується у формуванні IBAN.
        /// </summary>
        public const string bankCode = "111111";

        private const double premiumCost = 300;
        private static Dictionary<PaymentSystem, (int MinValue, int MaxValue)> paymentSystemRanges = new()
        {
            { PaymentSystem.Visa, (400000, 499999) },
            { PaymentSystem.Mastercard, (510000, 559999) }
        };
        private static HashSet<string> accountNumbers = new HashSet<string>();
        private static HashSet<string> cardNumbers = new HashSet<string>();
        private static HashSet<string> transactionNumbers = new HashSet<string>();
        private static List<User> users { get; set; } = new List<User>();
        private static List<Service> services { get; set; } = new List<Service>();

        /// <summary>
        /// Створює новий екземпляр банку та очищує всі попередні дані.
        /// </summary>
        public Bank()
        {
            accountNumbers.Clear();
            cardNumbers.Clear();
            transactionNumbers.Clear();
            users.Clear();
            services.Clear();
        }

        /// <summary>
        /// Реєстрація нового користувача з перевіркою валідності введених даних.
        /// </summary>
        public User? Register(string name, string surname, string patronymic, string phone, string password, string email)
        {
            if (surname.Length < 2)
            {
                MessageBox.Show("Невірне прізвище!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (name.Length < 2)
            {
                MessageBox.Show("Невірне ім'я!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (patronymic.Length != 0 && patronymic.Length < 4)
            {
                MessageBox.Show("Невірне по-батькові!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (!User.ValidatePhone(phone))
            {
                MessageBox.Show("Невірний номер телефону!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (email.Length != 0 && !User.ValidateEmail(email))
            {
                MessageBox.Show("Невірний адрес пошти!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (!IsPhoneAvailable(phone))
            {
                MessageBox.Show("Даний номер телефону зайнятий іншим користувачем!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (email.Length != 0 && !IsEmailAvailable(email))
            {
                MessageBox.Show("Дана пошта зайнята іншим користувачем!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            User user = new User(name, surname, patronymic, phone.Substring(phone.Length - 10), password, email);
            users.Add(user);

            return user;
        }
        
        /// <summary>
        /// Вхід користувача за email або номером телефону та паролем.
        /// </summary>
        public User? LogIn(string login, string password)
        {
            if (User.ValidateEmail(login))
            {
                return users.FirstOrDefault(u => u.Phone == login && u.Password == password);
            }
            else if (User.ValidatePhone(login))
            {
                return users.FirstOrDefault(u => u.Phone == login.Substring(login.Length - 10) && u.Password == password);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Додає новий сервіс (компанію) для можливості оплати її послуг.
        /// </summary>
        public bool AddService(string companyName, string companyNumber, string ownerFullName, string iban)
        {
            if (services.Any(x => x.CompanyNumber == companyNumber))
            {
                MessageBox.Show("Номер компанії вже існує!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Service service = new Service(companyName, companyNumber, ownerFullName, iban);
            services.Add(service);
            return true;
        }

        /// <summary>
        /// Видаляє сервіс за його унікальним номером.
        /// </summary>
        public void DeleteService(string companyNumber)
        {
            Service? service = services.FirstOrDefault(x => x.CompanyNumber == companyNumber);

            if (service == null)
            {
                MessageBox.Show("Сервіс не знайдено!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            services.Remove(service);
        }


        private bool TransferToBusinessAccount(Account accountFrom, BusinessAccount accountTo, double amount, string comment)
        {
            if (accountFrom == accountTo)
            {
                MessageBox.Show("Перераховувати кошти самому собі неможливо!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!accountTo.IsAvailable())
            {
                MessageBox.Show("Перераховувати кошти на цю картку неможливо!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!accountFrom.IsPaymentAvailable(amount))
            {
                MessageBox.Show("На рахунку недостатньо коштів!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            accountFrom.Balance -= amount;
            accountTo.Balance += accountFrom.GetTransferAmount(amount);

            Transaction transaction = new Transaction(GenerateTransactionNumber(), -amount, accountTo.CompanyNumber, comment, TransactionType.Transfer);
            accountFrom.Transactions.Add(transaction);
            accountTo.Transactions.Add(new BusinessTransaction(transaction.Number, accountFrom.GetTransferAmount(amount), transaction.Target, transaction.Description, transaction.Type, accountTo.CompanyName));

            return true;
        }
        private bool TransferToCard(Account accountFrom, BankCard cardTo, double amount, string comment)
        {
            if (accountFrom == cardTo.Account)
            {
                MessageBox.Show("Перераховувати кошти самому собі неможливо!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!cardTo.IsAvailable() || cardTo is PayoutCard)
            {
                MessageBox.Show("Перераховувати кошти на цю картку неможливо!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!accountFrom.IsPaymentAvailable(amount))
            {
                MessageBox.Show("На рахунку недостатньо коштів!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            accountFrom.Balance -= amount;
            cardTo.Account.Balance += accountFrom.GetTransferAmount(amount);

            Transaction transaction = new Transaction(GenerateTransactionNumber(), -amount, cardTo.Number, comment, TransactionType.Transfer);
            accountFrom.Transactions.Add(transaction);

            if (cardTo is BusinessCard businessCardTo)
            {
                cardTo.Account.Transactions.Add(new BusinessTransaction(transaction.Number, accountFrom.GetTransferAmount(amount), transaction.Target, transaction.Description, transaction.Type, businessCardTo.OwnerFullName));
            }
            else
            {
                transaction = new Transaction(transaction.Number, accountFrom.GetTransferAmount(amount), (accountFrom is PersonalAccount personalAccount ? personalAccount.Card.Number : accountFrom.IBAN), comment, TransactionType.Transfer);
                cardTo.Account.Transactions.Add(transaction);
            }

            return true;
        }

        /// <summary>
        /// Переказ коштів з рахунку на картку за її номером.
        /// </summary>
        public bool TransferToCard(Account accountFrom, string cardNumberToStr, double amount, string comment)
        {
            BankCard? cardTo = GetCardByNumber(cardNumberToStr);

            if (cardTo != null)
            {
                return TransferToCard(accountFrom, cardTo, amount, comment);
            }

            if (!accountFrom.IsPaymentAvailable(amount))
            {
                MessageBox.Show("На рахунку недостатньо коштів!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            accountFrom.Balance -= amount;
            accountFrom.AddTransaction(GenerateTransactionNumber(), -amount, cardNumberToStr, comment, TransactionType.Transfer);

            return true;
        }

        /// <summary>
        /// Переказ коштів з рахунку на IBAN.
        /// </summary>
        public bool TransferToIBAN(Account accountFrom, string iban, double amount, string comment)
        {
            Account? accountTo = GetAccountByIBAN(iban);
            if (accountTo != null)
            {
                if (accountTo is PersonalAccount personalAccountTo)
                {
                    return TransferToCard(accountFrom, personalAccountTo.Card, amount, comment);
                }
                else if (accountTo is BusinessAccount businessAccountTo)
                {
                    return TransferToBusinessAccount(accountFrom, businessAccountTo, amount, comment);
                }
            }

            if (!accountFrom.IsPaymentAvailable(amount))
            {
                MessageBox.Show("На рахунку недостатньо коштів!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            accountFrom.Balance -= amount;
            accountFrom.AddTransaction(GenerateTransactionNumber(), -amount, iban, comment, TransactionType.Transfer);

            return true;
        }


        /// <summary>
        /// Відкриває депозит за заданими параметрами.
        /// </summary>
        public bool OpenDeposit(Account accountFrom, double amount, double rate, int months)
        {
            if (accountFrom is not PersonalAccount personalAccountFrom)
                return false;

            if (personalAccountFrom.Card is not DebitCard card)
                return false;

            return card.OpenDeposit(amount, rate, months);
        }


        /// <summary>
        /// Щоденне оновлення банку: обробка депозитів, відсотків за місяць, кредитних лімітів, оплата преміум-підписок.
        /// </summary>
        public void NewDay(DateTime now)
        {

            if (now.Day == 1)
            {
                List<BankCard> debitCards = GetCardsByType(typeof(DebitCard));

                foreach (DebitCard card in debitCards)
                {
                    card.ApplyMonthlyInterest();

                    foreach (DepositClass deposit in card.Deposits)
                    {
                        if (deposit.IsExpired(now))
                        {
                            card.CloseDeposit(deposit);
                        }
                    }
                }

                foreach (User user in users)
                {
                    foreach (Account account in user.Accounts)
                    {
                        if (account.Premium)
                        {
                            if (account.Balance >= premiumCost)
                            {
                                account.Balance -= premiumCost;
                                account.Transactions.Add(new Transaction(GenerateTransactionNumber(), -premiumCost, null, "", TransactionType.Premium));
                            }
                            else
                            {
                                account.Premium = false;
                            }
                        }
                    }
                }
            }

            List<BankCard> creditCards = GetCardsByType(typeof(DebitCard));

            foreach (CreditCard card in creditCards)
            {
                if (card.CreditTriggered != null)
                {
                    if (card.CreditTriggered.Value - now >= TimeSpan.FromDays(5))
                    {
                        double interest = Math.Round((card.CreditLimit - card.CreditLeft) * 0.36 / 365 * (card.Account.Premium ? 0.75 : 1), 2);
                        card.CreditLeft -= interest;
                        card.Account.AddTransaction(GenerateTransactionNumber(), -interest, null, "", TransactionType.CreditInterest);
                    }
                }
            }
        }

        /// <summary>
        /// Видаляє рахунок з системи.
        /// </summary>
        public void DeleteAccount(Account account)
        {
            foreach (User user in users)
            {
                if (user.Accounts.Contains(account))
                {
                    user.Accounts.Remove(account);
                }
            }
        }


        private void SaveToFile(StreamWriter sw)
        {
            sw.WriteLine(string.Join(" ", accountNumbers));
            sw.WriteLine(string.Join(" ", cardNumbers));
            sw.WriteLine(string.Join(" ", transactionNumbers));

            sw.WriteLine(users.Count);
            foreach (User user in users)
            {
                user.SaveToFile(sw);
            }

            sw.WriteLine(services.Count);
            foreach (Service service in services)
            {
                service.SaveToFile(sw);
            }
        }

        /// <summary>
        /// Зберігає стан банку у файл за шляхом.
        /// </summary>
        public void SaveToFile(string filepath)
        {
            StreamWriter sw = new StreamWriter(filepath);
            SaveToFile(sw);
            sw.Close();
        }
        
        private static Bank LoadFromFile(StreamReader sr)
        {
            Bank bank = new Bank();

            try            
            {
                string? line = sr.ReadLine();
                int amount;

                foreach (string number in line.Split(" ").Skip(1))
                {
                    accountNumbers.Add(number);
                }

                line = sr.ReadLine();
                foreach (string number in line.Split(" ").Skip(1))
                {
                    cardNumbers.Add(number);
                }

                line = sr.ReadLine();
                foreach (string number in line.Split(" ").Skip(1))
                {
                    transactionNumbers.Add(number);
                }

                amount = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < amount; i++)
                {
                    users.Add(User.LoadFromFile(sr));
                }

                amount = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < amount; i++)
                {
                    services.Add(Service.LoadFromFile(sr));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Файл пошкоджено!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bank;
        }

        /// <summary>
        /// Завантажує банк із файлу за шляхом.
        /// </summary>
        public static Bank LoadFromFile(string filepath)
        {
            StreamReader sr = new StreamReader(filepath);
            Bank bank = LoadFromFile(sr);
            sr.Close();
            return bank;
        }


        /// <summary>
        /// Генерує унікальний номер рахунку.
        /// </summary>
        public static string GenerateAccountNumber()
        {
            string result;
            Random rnd = new Random();

            do
            {
                result = new string(Enumerable.Range(0, 16)
                    .Select(_ => rnd.Next(10).ToString()[0])
                    .ToArray());
            } while (transactionNumbers.Contains(result));

            accountNumbers.Add(result);
            return result;
        }

        /// <summary>
        /// Генерує унікальний номер картки з урахуванням платіжної системи.
        /// </summary>
        public static string GenerateCardNumber(PaymentSystem paymentSystem)
        {
            string result;
            Random rnd = new Random();

            if (paymentSystemRanges.TryGetValue(paymentSystem, out var paymentSystemRange))
                result = rnd.Next(paymentSystemRange.MinValue, paymentSystemRange.MaxValue + 1).ToString();
            else
                result = "000000";

            do
            {
                result += new string(Enumerable.Range(0, 9)
                    .Select(_ => rnd.Next(10).ToString()[0])
                    .ToArray());
            } while (transactionNumbers.Contains(result));

            result += GetLuhnDigit(result);

            cardNumbers.Add(result);
            return result;
        }

        /// <summary>
        /// Генерує унікальний номер транзакції.
        /// </summary>
        public static string GenerateTransactionNumber()
        {
            string result;
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            do
            {
                result = new string(Enumerable.Repeat(chars, 16)
                    .Select(s => s[rnd.Next(s.Length)])
                    .ToArray());
            } while (transactionNumbers.Contains(result));

            transactionNumbers.Add(result);
            return result;
        }


        /// <summary>
        /// Повертає картку за номером.
        /// </summary>
        public BankCard? GetCardByNumber(string number)
        {
            List<BankCard> Cards = GetCardsByType(typeof(BankCard));

            return Cards.FirstOrDefault(x => x.Number == number);
        }

        /// <summary>
        /// Повертає рахунок за IBAN.
        /// </summary>
        public Account? GetAccountByIBAN(string iban)
        {
            foreach (User user in users)
            {
                foreach (Account account in user.Accounts)
                {
                    if (account.IBAN == iban)
                        return account;
                }
            }

            return null;
        }

        
        private List<BankCard> GetCardsByType(Type cardType)
        {
            Type accountType;
            List<BankCard> Cards = new List<BankCard>();

            if (cardType == typeof(BusinessCard))
                accountType = typeof(BusinessAccount);
            else if (cardType == typeof(DebitCard) || cardType == typeof(CreditCard) || cardType == typeof(PayoutCard))
                accountType = typeof(PersonalAccount);
            else if (cardType == typeof(BankCard))
                accountType = typeof(Account);
            else
                return Cards;

            foreach (User user in users)
            {
                foreach (Account account in user.Accounts)
                {
                    if (accountType.IsAssignableFrom(account.GetType()))
                    {
                        if (account is PersonalAccount)
                        {
                            PersonalAccount personalAccount = (PersonalAccount)account;
                            Cards.Add(personalAccount.Card);
                        }
                        else if (account is BusinessAccount)
                        {
                            BusinessAccount businessAccount = (BusinessAccount)account;

                            foreach (BusinessCard card in businessAccount.Cards)
                            {
                                Cards.Add(card);
                            }
                        }
                    }
                }
            }

            return Cards;
        }

        /// <summary>
        /// Повертає користувача, який володіє вказаним рахунком.
        /// </summary>
        public static User? GetUserByAccount(Account account)
        {
            foreach (User user in users)
            {
                foreach (Account acc in user.Accounts)
                {
                    if (account == acc)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Обчислює контрольну цифру за алгоритмом Луна для номера картки.
        /// </summary>
        public static string GetLuhnDigit(string number)
        {
            int sum = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(number[i].ToString());

                if (i % 2 == 0)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
            }

            int checkDigit = (10 - (sum % 10)) % 10;
            return checkDigit.ToString();
        }

        /// <summary>
        /// Повертає сервіс за його назвою.
        /// </summary>
        public Service? GetServiceByName(string serviceName)
        {
            return services.FirstOrDefault(x => x.CompanyName == serviceName);
        }

        /// <summary>
        /// Повертає список усіх назв сервісів.
        /// </summary>
        public List<string> GetAllServicesNameList()
        {
            return services.Select(x => x.CompanyName).ToList();
        }

        /// <summary>
        /// Повертає список усіх сервісів у форматі "Назва (Номер)".
        /// </summary>
        public List<string> GetAllServicesList()
        {
            return services.Select(x => $"{x.CompanyName} ({x.CompanyNumber})").ToList();
        }

        /// <summary>
        /// Повертає список усіх банківських карток у форматі "(Тип) Номер: Баланс".
        /// </summary>
        public List<string> GetAllCardsList()
        {
            List<string> result = new List<string>();

            foreach (User user in users)
            {
                result.AddRange(user.GetAllAccountsText(true));
            }

            return GetCardsByType(typeof(BankCard)).Select(x => $"({x.Account.GetAccountType()}) {x.Number}: {x.Account.Balance}₴").ToList();
        }


        /// <summary>
        /// Перевіряє, чи доступний номер телефону для реєстрації.
        /// </summary>
        public bool IsPhoneAvailable(string phone)
        {
            foreach (User user in users)
            {
                if (user.Phone == phone)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Перевіряє, чи доступна електронна адреса для реєстрації.
        /// </summary>
        public bool IsEmailAvailable(string email)
        {
            foreach (User user in users)
            {
                if (user.Email == email)
                    return false;
            }

            return true;
        }
    }
}