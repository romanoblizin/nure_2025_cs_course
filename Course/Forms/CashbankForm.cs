namespace Course.Forms
{
    public partial class CashbankForm : Form
    {
        private MenuForm menuForm;

        public CashbankForm(MenuForm menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
            cbCard.DataSource = menuForm.User.GetAllAccountsText(false);
        }

        private void cbCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConfirm.Enabled = (cbCard.SelectedIndex != -1);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            menuForm.User.GetCashback(menuForm.User.Accounts.First(x => x.Number == cbCard.Text.Split(" ")[1].Split(":")[0]));
            MessageBox.Show("Кешбек отримано!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
