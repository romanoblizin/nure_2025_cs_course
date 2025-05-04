using Course.Classes;
using Course.Forms;
using System.Security.Principal;
using System.Windows.Forms;

namespace Course
{
    public partial class MenuForm : Form
    {
        public TimeSpan TimeDelta { get; set; } = TimeSpan.Zero;
        public User user;
        public Bank bank;
        private string? filepath;
        private LoginForm loginForm;
        private ProfileForm? profileForm;

        public MenuForm(LoginForm loginForm, Bank bank, User user, string? filepath)
        {
            InitializeComponent();
            this.bank = bank;
            this.user = user;
            this.filepath = filepath;
            this.loginForm = loginForm;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
            lblUser.Text = $"{user.Surname} {user.Name[0]}.{(user.Patronymic.Length > 0 ? $" {user.Patronymic[0]}." : "")}";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now + TimeDelta;
            lblTime.Text = now.ToString();

            if (now.Hour == 0 && now.Minute == 0 && now.Second == 0)
            {
                bank.NewDay();
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
                    bank.SaveToFile(saveFileDialog.FileName);
            }
            else
                bank.SaveToFile(filepath);

            Application.Exit();
        }
    }
}
