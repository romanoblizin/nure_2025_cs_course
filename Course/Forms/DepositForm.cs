namespace Course.Forms
{
    public partial class DepositForm : Form
    {
        private MenuForm menuForm;
        private const double creditRate = 24;

        public DepositForm(MenuForm menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
            tbRate.Text = creditRate.ToString();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (nudAmount.Value == 0)
            {
                MessageBox.Show("Сума не може бути 0!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nudMonths.Value == 0)
            {
                MessageBox.Show("Кількість місяців не може бути 0!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (menuForm.Bank.OpenDeposit(menuForm.Account, Convert.ToDouble(nudAmount.Value), Convert.ToDouble(tbRate.Text), Convert.ToInt32(nudMonths.Value)))
                MessageBox.Show("Депозит відкрито!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
