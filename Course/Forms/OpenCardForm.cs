using Course.Classes;

namespace Course.Forms
{
    public partial class OpenCardForm : Form
    {
        private MenuForm menuForm;
        private BankCardType bankCardType;
        private const double debitRate = 12;
        private const double creditRate = 36;

        public OpenCardForm(MenuForm menuForm, BankCardType bankCardType)
        {
            InitializeComponent();
            this.menuForm = menuForm;
            this.bankCardType = bankCardType;

            gbPersonalAccount.Visible = !(bankCardType is BankCardType.BusinessCard);

            if (bankCardType is not BankCardType.BusinessCard)
            {
                cbPaymentSystem.DataSource = Enum.GetValues(typeof(PaymentSystem));

                lblRate.Visible = tbRate.Visible = !(bankCardType is BankCardType.PayoutCard);
                if (!tbRate.Visible)
                    tbRate.Text = (bankCardType is BankCardType.DebitCard) ? debitRate.ToString() : creditRate.ToString();
            }
        }

        private void btnOpenAccount_Click(object sender, EventArgs e)
        {
            if (bankCardType is BankCardType.BusinessCard)
            {
                if (tbCompanyName.Text.Length == 0)
                {
                    MessageBox.Show("Введіть назву компанії!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tbCompanyNumber.Text.Length != 8 && tbCompanyNumber.Text.Length != 10)
                {
                    MessageBox.Show("Введіть коректний ІПН або ЄДРПОУ!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                menuForm.User.OpenBusinessAccount(tbCompanyName.Text, tbCompanyNumber.Text);
                MessageBox.Show("Рахунок відкрито!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cbPaymentSystem.SelectedIndex == -1)
                {
                    MessageBox.Show("Оберіть платіжну систему!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PaymentSystem paymentSystem = BankCard.PaymentSystemFromText(cbPaymentSystem.Text);

                switch (bankCardType)
                {
                    case BankCardType.DebitCard:
                        menuForm.User.OpenDebitCard(paymentSystem, Convert.ToDouble(tbRate.Text));
                        break;
                    case BankCardType.CreditCard:
                        menuForm.User.OpenCreditCard(paymentSystem, Convert.ToDouble(tbRate.Text));
                        break;
                    case BankCardType.PayoutCard:
                        menuForm.User.OpenPayoutCard(paymentSystem);
                        break;
                    default:
                        break;
                }
                MessageBox.Show("Рахунок відкрито!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}