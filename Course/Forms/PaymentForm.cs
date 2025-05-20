namespace Course.Forms
{
    public partial class PaymentForm : Form
    {
        private MenuForm menuForm;

        public PaymentForm(MenuForm menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            cbService.DataSource = menuForm.Bank.GetAllServicesNameList();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (cbService.SelectedIndex == -1)
            {
                MessageBox.Show("Оберіть послугу!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nudAmount.Value == 0)
            {
                MessageBox.Show("Сума повинна бути більше за 0!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tbComment.Text.Length == 0)
            {
                MessageBox.Show("Вкажіть коментар (номер рахунку і т. д.)!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            menuForm.Account.PayService((double)nudAmount.Value, menuForm.Bank.GetServiceByName(cbService.Text), tbComment.Text);
            cbService.SelectedIndex = -1;
            nudAmount.Value = 0;
            tbComment.Text = string.Empty;
            MessageBox.Show("Послугу сплачено!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
