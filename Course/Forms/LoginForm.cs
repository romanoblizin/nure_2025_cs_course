using Course.Classes;

namespace Course.Forms
{
    public partial class LoginForm : Form
    {
        private Bank bank;
        private string? filepath;
        private MenuForm? menuForm;

        public LoginForm()
        {
            InitializeComponent();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bank = Bank.LoadFromFile(openFileDialog.FileName);
                filepath = openFileDialog.FileName;
            }
            else
                bank = new Bank();
        }

        private void SetMenuForm(User user)
        {
            if (menuForm == null)
                menuForm = new MenuForm(this, bank, user, filepath);
            else
                menuForm.user = user;

            this.Hide();
            menuForm.Show();

            tbLogin.Text = string.Empty;
            tbPassword.Text = string.Empty;
            tbName.Text = string.Empty;
            tbSurname.Text = string.Empty;
            tbPatronymic.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbPhone.Text = string.Empty;
            tbPasswordR.Text = string.Empty;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (menuForm != null)
                now += menuForm.TimeDelta;

            lblTime.Text = now.ToString();

            if (now.Hour == 0 && now.Minute == 0 && now.Second == 0)
            {
                bank.NewDay();
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

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            User? user = bank.LogIn(tbLogin.Text, tbPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Невірні дані!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetMenuForm(user);
        }

        private void btnToRegister_Click(object sender, EventArgs e)
        {
            gbLogin.Visible = false;
            gbRegistration.Visible = true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbPasswordR.Text.Length < 8)
            {
                MessageBox.Show("Довжина паролю повинна бути 8 символів", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User? user = bank.Register(tbName.Text, tbSurname.Text, tbPatronymic.Text, tbPhone.Text, tbPasswordR.Text, tbEmail.Text);

            if (user == null)
                return;

            SetMenuForm(user);
        }

        private void btnToLogIn_Click(object sender, EventArgs e)
        {
            gbLogin.Visible = true;
            gbRegistration.Visible = false;
        }
    }
}
