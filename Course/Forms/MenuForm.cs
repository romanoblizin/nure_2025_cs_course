using Course.Classes;
using Course.Forms;
using System.Text.RegularExpressions;

namespace Course
{
    public partial class MenuForm : Form
    {
        public TimeSpan TimeDelta { get; set; } = TimeSpan.Zero;
        public User User;
        public Bank Bank;
        public Account? Account;
        private string? filepath;
        private LoginForm loginForm;
        private ProfileForm? profileForm;
        private bool isSaved = false;

        public MenuForm(LoginForm loginForm, Bank bank, User user, string? filepath)
        {
            InitializeComponent();
            Bank = bank;
            User = user;
            this.filepath = filepath;
            this.loginForm = loginForm;
        }

        private void updateBalance()
        {
            int selectedIndex = cbAccount.SelectedIndex;
            cbAccount.DataSource = User.GetAllAccountsText(true);
            cbAccount.SelectedIndex = selectedIndex;
            lblBalance.Text = $"Баланс: {Account.Balance}₴";
        }

        private DateTime timeNow()
        {
            return DateTime.Now + TimeDelta;
        }

        private void MenuForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                lblTime.Text = DateTime.Now.ToString();
                lblUser.Text = $"{User.Surname} {User.Name[0]}.{(User.Patronymic.Length > 0 ? $" {User.Patronymic[0]}." : "")}";

                cbAccount.DataSource = User.GetAllAccountsText(true);
                if (cbAccount.SelectedIndex == -1)
                {
                    cbAccount.Text = string.Empty;
                    Account = null;
                    gbAccountControl.Visible = false;
                    gbAccountBlocked.Visible = false;
                }
                else
                    cbAccount.SelectedIndex = -1;

                cbBusinessPaymentSystem.DataSource = Enum.GetValues(typeof(PaymentSystem));

                List<string> transactionTypes = new List<string>() { "-" };

                foreach (TransactionType type in Enum.GetValues(typeof(TransactionType)))
                {
                    transactionTypes.Add(Transaction.GetTranslatedType(type));
                }

                cbSearch.DataSource = transactionTypes;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = timeNow();
            lblTime.Text = now.ToString();

            if (now.Hour == 0 && now.Minute == 0 && now.Second == 0)
            {
                Bank.NewDay(now);
            }
        }

        private void lblTime_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TimeDeltaForm timeDeltaForm = new TimeDeltaForm(this);
            timeDeltaForm.ShowDialog();
            MenuForm_VisibleChanged(sender, e);
        }

        private void panelLogo_MouseHover(object sender, EventArgs e)
        {
            panelLogo.Cursor = Cursors.Hand;
        }

        private void panelUser_MouseHover(object sender, EventArgs e)
        {
            panelUser.Cursor = Cursors.Hand;
        }

        private void panelUser_Click(object sender, EventArgs e)
        {
            if (profileForm == null)
                profileForm = new ProfileForm(this, loginForm);
            this.Hide();
            profileForm.Show();
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isSaved)
                return;

            isSaved = true;

            if (filepath == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    Bank.SaveToFile(saveFileDialog.FileName);
            }
            else
                Bank.SaveToFile(filepath);

            Application.Exit();
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAccount.SelectedIndex == -1)
            {
                Account = null;
                gbAccountControl.Visible = false;
                gbAccountBlocked.Visible = false;
                return;
            }

            Account = User.Accounts.First(x => x.Number == cbAccount.Text.Split(") ")[1].Split(":")[0]);

            gbAccountControl.Visible = !Account.IsBlocked();
            gbAccountBlocked.Visible = Account.IsBlocked();

            if (Account.IsBlocked())
            {
                lblAccountBlocked.Text = $"Причина: {Account.Blocked}";
                return;
            }

            tbTransferTarget.Text = string.Empty;
            nudTransferAmount.Value = 0;
            tbTransferComment.Text = string.Empty;

            lblBalance.Text = $"Баланс: {Account.Balance}₴";
            btnSubscribePremium.Visible = !(Account.Premium);

            cbSearch.SelectedIndex = -1;
            tbSearch.Text = string.Empty;
            dtpSearchStart.Value = DateTime.Now;
            dtpSearchEnd.Value = DateTime.Now;
            dtpSearchStart.Checked = false;
            dtpSearchEnd.Checked = false;

            gbPersonalAccountControl.Visible = (Account is PersonalAccount);
            transactionSearch(null, null);

            if (Account is PersonalAccount personalAccount)
            {
                dgvTransactions.Visible = gbSearchTransactions.Visible =  true;
                tbCardNumber.Text = personalAccount.Card.Number.Insert(4, " ").Insert(9, " ").Insert(14, " ");
                lblExpireDate.Text = personalAccount.Card.ExpirationDate.ToString("MM\\/yyyy");
                lblCVV.Text = personalAccount.Card.CVV;
                tbIBAN.Text = personalAccount.IBAN;
                btnRenewCard.Enabled = (personalAccount.Card.IsExpired(timeNow()));
            }
            else if (Account is BusinessAccount businessAccount)
            {
                tbSearchBusinessCards.Text = string.Empty;
                cbSearchBusinessCardsOnlyExpired.Checked = false;
                cbSearchBusinessCardsOnlyUnexpired.Checked = false;

                tbBusinessFullName.Text = string.Empty;
                cbBusinessPaymentSystem.SelectedIndex = -1;

                businessSearch(null, null);
            }
        }

        private void btnSubscribePremium_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"З вашого рахунку буде списуватися {Account.PremiumCost}₴ щомісяця\nВи впевнені, що хочете активувати підписку?", "Преміум-підписка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (Account.SubscribePremium())
            {
                transactionSearch(null, null);
                updateBalance();
                btnSubscribePremium.Visible = !(Account.Premium);
                MessageBox.Show("Преміум-підписка активна!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("На рахунку не вистачає коштів!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnUnsubscribePremium_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Підписка буде скасована, кошти за залишившийся час не будуть повернені\nВи впевнені, що хочете відмінити підписку?", "Преміум-підписка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Account.Premium = false;
            btnSubscribePremium.Visible = !(Account.Premium);
            MessageBox.Show("Преміум підписка скасована!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (tbTransferTarget.Text.Length == 0)
            {
                MessageBox.Show("Введіть отримувача!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nudTransferAmount.Value == 0)
            {
                MessageBox.Show("Сума повинна бути більше за 0!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tbTransferTarget.Text = tbTransferTarget.Text.Replace(" ", "");

            if (Regex.IsMatch(tbTransferTarget.Text, @"^\d{16}$"))
            {
                if (Bank.GetLuhnDigit(tbTransferTarget.Text.Substring(0, 15)) != tbTransferTarget.Text[15].ToString())
                {
                    MessageBox.Show("Введіть коректний номер картки!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Bank.TransferToCard(Account, tbTransferTarget.Text, (double)nudTransferAmount.Value, tbTransferComment.Text);
            }
            else if (Regex.IsMatch(tbTransferTarget.Text, @"^[a-zA-Z]{2}\d{24}$"))
            {
                Bank.TransferToIBAN(Account, tbTransferTarget.Text, (double)nudTransferAmount.Value, tbTransferComment.Text);
            }
            else
            {
                MessageBox.Show("Введіть коректний номер картки або IBAN!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tbTransferTarget.Text = string.Empty;
            nudTransferAmount.Value = 0;
            tbTransferComment.Text = string.Empty;
            updateBalance();
            MessageBox.Show("Переказ здійснено!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            transactionSearch(null, null);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm(this);
            paymentForm.ShowDialog();
            updateBalance();
            transactionSearch(null, null);
        }

        private void btnRenewCard_Click(object sender, EventArgs e)
        {
            ((PersonalAccount)Account).Card.RenewCard();
            MessageBox.Show("Картка оновлена!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void transactionSearch(object? sender, EventArgs? e)
        {
            if (Account is null) return;
            dgvTransactions.Rows.Clear();

            List<Transaction> transactions = Account.Transactions.ToList();

            if (cbSearch.SelectedIndex > 0)
            {
                transactions = transactions.Where(x => string.Equals(Transaction.GetTranslatedType(x.Type), cbSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (tbSearch.Text.Length > 0)
                transactions = transactions.Where(x => (string.IsNullOrEmpty(x.Target) ? "Банк" : x.Target).Contains(tbSearch.Text, StringComparison.OrdinalIgnoreCase) || x.Description != null && x.Description.Contains(tbSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!dtpSearchStart.Checked || !dtpSearchEnd.Checked || dtpSearchStart.Value <= dtpSearchEnd.Value)
            {
                if (dtpSearchStart.Checked)
                    transactions = transactions.Where(x => x.Date >= dtpSearchStart.Value).ToList();
                if (dtpSearchEnd.Checked)
                    transactions = transactions.Where(x => x.Date <= dtpSearchEnd.Value).ToList();
            }

            foreach (Transaction transaction in transactions)
            {
                dgvTransactions.Rows.Add(transaction.Number, transaction.Date.ToString("dd.MM.yyyy HH:mm"), Transaction.GetTranslatedType(transaction.Type), transaction.Amount.ToString(), (string.IsNullOrEmpty(transaction.Target) ? "Банк" : transaction.Target), transaction.Description);
            }
        }

        private void businessSearch(object? sender, EventArgs? e)
        {
            dgvBusinessCards.Rows.Clear();

            List<BusinessCard> cards = ((BusinessAccount)Account).Cards.ToList();

            if (tbSearchBusinessCards.Text.Length > 0)
                cards = cards.Where(x => x.OwnerFullName.Contains(tbSearchBusinessCards.Text, StringComparison.OrdinalIgnoreCase) || x.Number.Contains(tbSearchBusinessCards.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            if (cbSearchBusinessCardsOnlyExpired.Checked)
                cards = cards.Where(x => x.IsExpired()).ToList();
            else if (cbSearchBusinessCardsOnlyUnexpired.Checked)
                cards = cards.Where(x => !x.IsExpired()).ToList();

            foreach (BusinessCard card in cards)
            {
                dgvBusinessCards.Rows.Add(card.Number, card.OwnerFullName, card.ExpirationDate.ToString("MM\\/yyyy"), card.CVV);
            }
        }

        private void btnOpenCard_Click(object sender, EventArgs e)
        {
            if (tbBusinessFullName.Text.Length == 0)
            {
                MessageBox.Show("Вкажіть ФІО власника картки!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbBusinessPaymentSystem.SelectedIndex == -1)
            {
                MessageBox.Show("Оберіть платіжну систему!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ((BusinessAccount)Account).OpenBusinessCard(BankCard.PaymentSystemFromText(cbBusinessPaymentSystem.Text), tbBusinessFullName.Text);
            businessSearch(null, null);
            cbBusinessPaymentSystem.SelectedIndex = -1;
            tbBusinessFullName.Text = string.Empty;
            MessageBox.Show("Нову картку створено!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            dgvTransactions.Visible = !dgvTransactions.Visible;
            gbSearchTransactions.Visible = !gbSearchTransactions.Visible;
        }

        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex != -1)
            {
                string receipt = Account.Transactions.First(x => x.Number == dgvTransactions.Rows[e.RowIndex].Cells["NumberColumn"].Value.ToString()).GetReceipt(Account);

                if (MessageBox.Show($"Ви впевнені, що хочете зберегти дану квітанцію:\n\n{receipt}", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                        sw.Write(receipt);
                        sw.Close();
                    }
                }
            }
        }

        private void dgvBusinessCards_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != -1)
            {
                BusinessCard card = ((BusinessAccount)Account).Cards.First(x => x.Number == dgvBusinessCards.Rows[e.RowIndex].Cells["CardNumberColumn"].Value.ToString());
                if (!card.IsExpired())
                {
                    MessageBox.Show("Картка не прострочена!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                card.RenewCard();
                businessSearch(null, null);
                MessageBox.Show("Картку оновлено!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbSearchBusinessCardsOnlyUnexpired_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchBusinessCardsOnlyUnexpired.Checked)
                cbSearchBusinessCardsOnlyExpired.Checked = false;

            businessSearch(null, null);
        }

        private void cbSearchBusinessCardsOnlyExpired_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchBusinessCardsOnlyExpired.Checked)
                cbSearchBusinessCardsOnlyUnexpired.Checked = false;

            businessSearch(null, null);
        }
    }
}