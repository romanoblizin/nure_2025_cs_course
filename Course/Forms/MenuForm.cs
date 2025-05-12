using Course.Classes;
using Course.Forms;

namespace Course
{
    public partial class MenuForm : Form
    {
        public TimeSpan TimeDelta { get; set; } = TimeSpan.Zero;
        public User User;
        public Bank Bank;
        private string? filepath;
        private LoginForm loginForm;
        private ProfileForm? profileForm;
        private Account? Account;

        public MenuForm(LoginForm loginForm, Bank bank, User user, string? filepath)
        {
            InitializeComponent();
            Bank = bank;
            User = user;
            this.filepath = filepath;
            this.loginForm = loginForm;
        }

        private void MenuForm_Shown(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
            lblUser.Text = $"{User.Surname} {User.Name[0]}.{(User.Patronymic.Length > 0 ? $" {User.Patronymic[0]}." : "")}";
            cbCard.SelectedIndex = -1;
            cbCard.DataSource = User.GetAllAccountsText(true);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now + TimeDelta;
            lblTime.Text = now.ToString();

            if (now.Hour == 0 && now.Minute == 0 && now.Second == 0)
            {
                Bank.NewDay();
            }
        }

        private void lblTime_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TimeDeltaForm timeDeltaForm = new TimeDeltaForm(this);
            timeDeltaForm.ShowDialog();
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

        private void cbCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account = User.Accounts.First(x => x.Number == cbCard.SelectedText.Split(":")[0]);

            gbAccountControl.Visible = !Account.IsBlocked();

            if (Account.IsBlocked())
            {
                lblAccountBlocked.Text = $"Причина: {Account.Blocked}";
                return;
            }

            gbPersonalAccountControl.Visible = (Account is PersonalAccount);


        }
    }
}
