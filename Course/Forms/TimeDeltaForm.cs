using Course.Classes;
using System.Text.RegularExpressions;

namespace Course.Forms
{
    public partial class TimeDeltaForm : Form
    {
        private MenuForm menuForm;
        private BankCard? selectedCard;

        public TimeDeltaForm(MenuForm menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
            cbCard.DataSource = menuForm.Bank.GetAllCardsList();
            cbCard.SelectedIndex = -1;
            cbServices.DataSource = menuForm.Bank.GetAllServicesList();
            cbServices.SelectedIndex = -1;
        }

        private void updateCheckBox()
        {
            int selectedIndex = cbCard.SelectedIndex;
            cbCard.DataSource = menuForm.Bank.GetAllCardsList();
            cbCard.SelectedIndex = selectedIndex;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(Convert.ToInt32(nudSeconds.Value));
            timeSpan = timeSpan.Add(TimeSpan.FromMinutes(Convert.ToInt32(nudMinutes.Value)));
            timeSpan = timeSpan.Add(TimeSpan.FromHours(Convert.ToInt32(nudHours.Value)));
            timeSpan = timeSpan.Add(TimeSpan.FromDays(Convert.ToInt32(nudDays.Value)));

            nudSeconds.Value = 0;
            nudMinutes.Value = 0;
            nudHours.Value = 0;
            nudDays.Value = 0;

            menuForm.TimeDelta += timeSpan;
            this.Close();
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (this.Width == 380)
            {
                this.Width = 760;
                this.Height = 293;
                btnExpand.Text = "<";
                btnExpand.Location = new Point(btnExpand.Location.X, 216);
            }
            else
            {
                this.Width = 380;
                this.Height = 215;
                btnExpand.Text = ">";
                btnExpand.Location = new Point(btnExpand.Location.X, 133);
            }
        }

        private void cbCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeposit.Enabled = btnWithdraw.Enabled = btnPayout.Enabled = btnBlock.Enabled = btnDeleteAccount.Enabled = (cbCard.SelectedIndex != -1);

            if (cbCard.SelectedIndex != -1)
            {
                selectedCard = menuForm.Bank.GetCardByNumber(cbCard.Text.Split(") ")[1].Split(":")[0]);
                tbReason.Text = selectedCard.Account.Blocked;
                tbReason.ReadOnly = false;
            }
            else
            {
                tbReason.Text = string.Empty;
                tbReason.ReadOnly = true;
                selectedCard = null;
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (selectedCard.Pay((double)nudAmount.Value))
            {
                updateCheckBox();
                MessageBox.Show("Оплата здійснена!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (selectedCard.Deposit((double)nudAmount.Value))
            {
                updateCheckBox();
                MessageBox.Show("Рахунок поповнено!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (selectedCard.Withdraw((double)nudAmount.Value))
            {
                updateCheckBox();
                MessageBox.Show("Кошти зняті!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPayout_Click(object sender, EventArgs e)
        {
            if (selectedCard is PayoutCard payoutCard)
            {
                payoutCard.Payout(Bank.GenerateTransactionNumber(), (double)nudAmount.Value, "Виплата від банку");
                updateCheckBox();
                MessageBox.Show("Кошти виплачено!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Картка не для виплат!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            selectedCard.Account.Blocked = tbReason.Text;
            MessageBox.Show("Статус рахунку змінено!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви впевнені, що хочете видалити цей рахунок?\nЦю дію неможливо відмінити!", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                menuForm.Bank.DeleteAccount(selectedCard.Account);

                cbCard.SelectedIndex = -1;
                updateCheckBox();

                MessageBox.Show("Рахунок видалено!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteAccount.Enabled = !(cbServices.SelectedIndex == -1);
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (tbCompanyName.Text.Length == 0 || tbCompanyOwner.Text.Length == 0)
            {
                MessageBox.Show("Заповніть усі поля!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(tbCompanyNumber.Text, @"^(\d{8}|\d{10})$"))
            {
                MessageBox.Show("Некоректний ІПН/ЄДРПОУ!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(tbCompanyIBAN.Text, @"^[a-zA-Z]{2}\d{24}$"))
            {
                MessageBox.Show("Некоректний IBAN!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!menuForm.Bank.AddService(tbCompanyName.Text, tbCompanyNumber.Text, tbCompanyOwner.Text, tbCompanyIBAN.Text))
                return;

            cbServices.DataSource = menuForm.Bank.GetAllServicesList();
            tbCompanyName.Text = tbCompanyIBAN.Text = tbCompanyNumber.Text = tbCompanyOwner.Text = string.Empty;
            MessageBox.Show("Компанію додано!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви впевнені, що хочете видалити цю компанію?\nЦю дію неможливо відмінити!", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                menuForm.Bank.DeleteService(cbServices.Text.Split("(")[1].Split(")")[0]);

                cbServices.DataSource = menuForm.Bank.GetAllServicesList();
                cbServices.SelectedIndex = -1;

                MessageBox.Show("Компанію видалено!", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
