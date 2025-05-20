using Course.Classes;

namespace Course.Forms
{
    public partial class ProfileForm : Form
    {
        private MenuForm menuForm;
        private LoginForm loginForm;

        public ProfileForm(MenuForm menuForm, LoginForm loginForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
            this.loginForm = loginForm;
        }

        private void ProfileForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                lblTime.Text = DateTime.Now.ToString();
                lblUser.Text = $"{menuForm.User.Surname} {menuForm.User.Name[0]}.{(menuForm.User.Patronymic.Length > 0 ? $" {menuForm.User.Patronymic[0]}." : "")}";

                tbSurname.Text = menuForm.User.Surname;
                tbName.Text = menuForm.User.Name;
                tbPatronymic.Text = menuForm.User.Patronymic;
                tbEmail.Text = menuForm.User.Email;
                tbPhone.Text = menuForm.User.Phone;
                tbPassword.Text = menuForm.User.Password;
                lblCashback.Text = $"{menuForm.User.Cashback}{(menuForm.User.Cashback < 100 ? "/100" : "")} ₴";
                btnGetCashback.Enabled = menuForm.User.Cashback >= 100;
            }
        }

        private void panelLogo_MouseHover(object sender, EventArgs e)
        {
            panelLogo.Cursor = Cursors.Hand;
        }

        private void panelUser_MouseHover(object sender, EventArgs e)
        {
            panelUser.Cursor = Cursors.Hand;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now + menuForm.TimeDelta;
            lblTime.Text = now.ToString();

            if (now.Hour == 0 && now.Minute == 0 && now.Second == 0)
            {
                menuForm.Bank.NewDay(now);
            }
        }

        private void panelLogo_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuForm.Show();
        }

        private void ProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbSurname.Text.Length < 2)
            {
                MessageBox.Show("Невірне прізвище", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbName.Text.Length < 2)
            {
                MessageBox.Show("Невірне ім'я", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbPatronymic.Text.Length != 0 && tbPatronymic.Text.Length < 4)
            {
                MessageBox.Show("Невірне по-батькові", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!User.ValidatePhone(tbPhone.Text))
            {
                MessageBox.Show("Невірний номер телефону", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbEmail.Text.Length != 0 && !User.ValidateEmail(tbEmail.Text))
            {
                MessageBox.Show("Невірний адрес пошти", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!menuForm.Bank.IsPhoneAvailable(tbPhone.Text) && tbPhone.Text.Substring(tbPhone.Text.Length - 10) != menuForm.User.Phone)
            {
                MessageBox.Show("Даний номер телефону зайнятий іншим користувачем", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbEmail.Text.Length != 0 && !menuForm.Bank.IsEmailAvailable(tbEmail.Text) && tbEmail.Text != menuForm.User.Email)
            {
                MessageBox.Show("Дана пошта зайнята іншим користувачем", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbPassword.Text.Length < 8)
            {
                MessageBox.Show("Довжина паролю повинна бути 8 символів", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            menuForm.User.Surname = tbSurname.Text;
            menuForm.User.Name = tbName.Text;
            menuForm.User.Patronymic = tbPatronymic.Text;
            menuForm.User.Phone = tbPhone.Text.Substring(tbPhone.Text.Length - 10);
            menuForm.User.Email = tbEmail.Text;
            menuForm.User.Password = tbPassword.Text;
            lblUser.Text = $"{menuForm.User.Surname} {menuForm.User.Name[0]}.{(menuForm.User.Patronymic.Length > 0 ? $" {menuForm.User.Patronymic[0]}." : "")}";
        }

        private void btnOpenDebitAccount_Click(object sender, EventArgs e)
        {
            OpenCardForm openCardForm = new OpenCardForm(menuForm, BankCardType.DebitCard);
            openCardForm.ShowDialog();
        }

        private void btnOpenCreditAccount_Click(object sender, EventArgs e)
        {
            OpenCardForm openCardForm = new OpenCardForm(menuForm, BankCardType.CreditCard);
            openCardForm.ShowDialog();
        }

        private void btnOpenPayoutAccount_Click(object sender, EventArgs e)
        {
            OpenCardForm openCardForm = new OpenCardForm(menuForm, BankCardType.PayoutCard);
            openCardForm.ShowDialog();
        }

        private void btnOpenBusinessAccount_Click(object sender, EventArgs e)
        {
            OpenCardForm openCardForm = new OpenCardForm(menuForm, BankCardType.BusinessCard);
            openCardForm.ShowDialog();
        }

        private void btnGetCashback_Click(object sender, EventArgs e)
        {
            CashbankForm cashbankForm = new CashbankForm(menuForm);
            cashbankForm.ShowDialog();
            lblCashback.Text = $"{menuForm.User.Cashback}{(menuForm.User.Cashback < 100 ? "/100" : "")} ₴";
            btnGetCashback.Enabled = menuForm.User.Cashback >= 100;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }
    }
}
