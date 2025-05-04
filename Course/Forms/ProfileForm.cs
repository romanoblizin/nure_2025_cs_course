using Course.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

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

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
            lblUser.Text = $"{menuForm.user.Surname} {menuForm.user.Name[0]}.{(menuForm.user.Patronymic.Length > 0 ? $" {menuForm.user.Patronymic[0]}." : "")}";

            tbSurname.Text = menuForm.user.Surname;
            tbName.Text = menuForm.user.Name;
            tbPatronymic.Text = menuForm.user.Patronymic;
            tbEmail.Text = menuForm.user.Email;
            tbPhone.Text = menuForm.user.Phone;
            tbPassword.Text = menuForm.user.Password;
            lblCashback.Text = $"{menuForm.user.Cashback}{(menuForm.user.Cashback < 100 ? "/100" : "")} ₴";
            btnGetCashback.Enabled = menuForm.user.Cashback >= 100;
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
                menuForm.bank.NewDay();
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
            if (!menuForm.bank.IsPhoneAvailable(tbPhone.Text) && tbPhone.Text.Substring(tbPhone.Text.Length - 10) != menuForm.user.Phone)
            {
                MessageBox.Show("Даний номер телефону зайнятий іншим користувачем", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbEmail.Text.Length != 0 && !menuForm.bank.IsEmailAvailable(tbEmail.Text) && tbEmail.Text != menuForm.user.Email)
            {
                MessageBox.Show("Дана пошта зайнята іншим користувачем", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbPassword.Text.Length < 8)
            {
                MessageBox.Show("Довжина паролю повинна бути 8 символів", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            menuForm.user.Surname = tbSurname.Text;
            menuForm.user.Name = tbName.Text;
            menuForm.user.Patronymic = tbPatronymic.Text;
            menuForm.user.Phone = tbPhone.Text.Substring(tbPhone.Text.Length - 10);
            menuForm.user.Email = tbEmail.Text;
            menuForm.user.Password = tbPassword.Text;
        }

        private void btnOpenDebitAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenCreditAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenPayoutAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenBusinessAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnGetCashback_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }
    }
}
