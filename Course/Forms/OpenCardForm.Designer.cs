namespace Course.Forms
{
    partial class OpenCardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenCardForm));
            gbBusinessAccount = new GroupBox();
            tbCompanyNumber = new TextBox();
            tbCompanyName = new TextBox();
            lblCompanyNumber = new Label();
            lblCompanyName = new Label();
            cbPaymentSystem = new ComboBox();
            lblPaymentSystem = new Label();
            btnOpenAccount = new Button();
            gbPersonalAccount = new GroupBox();
            gbBusinessAccount.SuspendLayout();
            gbPersonalAccount.SuspendLayout();
            SuspendLayout();
            // 
            // gbBusinessAccount
            // 
            gbBusinessAccount.Controls.Add(tbCompanyNumber);
            gbBusinessAccount.Controls.Add(tbCompanyName);
            gbBusinessAccount.Controls.Add(lblCompanyNumber);
            gbBusinessAccount.Controls.Add(lblCompanyName);
            gbBusinessAccount.Location = new Point(12, 12);
            gbBusinessAccount.Name = "gbBusinessAccount";
            gbBusinessAccount.Size = new Size(340, 112);
            gbBusinessAccount.TabIndex = 0;
            gbBusinessAccount.TabStop = false;
            // 
            // tbCompanyNumber
            // 
            tbCompanyNumber.Location = new Point(160, 65);
            tbCompanyNumber.Name = "tbCompanyNumber";
            tbCompanyNumber.Size = new Size(155, 23);
            tbCompanyNumber.TabIndex = 3;
            // 
            // tbCompanyName
            // 
            tbCompanyName.Location = new Point(160, 30);
            tbCompanyName.Name = "tbCompanyName";
            tbCompanyName.Size = new Size(155, 23);
            tbCompanyName.TabIndex = 2;
            // 
            // lblCompanyNumber
            // 
            lblCompanyNumber.AutoSize = true;
            lblCompanyNumber.Location = new Point(50, 68);
            lblCompanyNumber.Name = "lblCompanyNumber";
            lblCompanyNumber.Size = new Size(104, 15);
            lblCompanyNumber.TabIndex = 1;
            lblCompanyNumber.Text = "ІПН або ЄДРПОУ:";
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(25, 33);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(129, 15);
            lblCompanyName.TabIndex = 0;
            lblCompanyName.Text = "Повна назва компанії:";
            // 
            // cbPaymentSystem
            // 
            cbPaymentSystem.FormattingEnabled = true;
            cbPaymentSystem.Location = new Point(151, 45);
            cbPaymentSystem.Name = "cbPaymentSystem";
            cbPaymentSystem.Size = new Size(155, 23);
            cbPaymentSystem.TabIndex = 1;
            // 
            // lblPaymentSystem
            // 
            lblPaymentSystem.AutoSize = true;
            lblPaymentSystem.Location = new Point(35, 49);
            lblPaymentSystem.Name = "lblPaymentSystem";
            lblPaymentSystem.Size = new Size(110, 15);
            lblPaymentSystem.TabIndex = 2;
            lblPaymentSystem.Text = "Платіжна система:";
            // 
            // btnOpenAccount
            // 
            btnOpenAccount.BackColor = Color.DarkSeaGreen;
            btnOpenAccount.FlatStyle = FlatStyle.Flat;
            btnOpenAccount.Location = new Point(114, 135);
            btnOpenAccount.Name = "btnOpenAccount";
            btnOpenAccount.Size = new Size(136, 25);
            btnOpenAccount.TabIndex = 3;
            btnOpenAccount.Text = "Відкрити картку";
            btnOpenAccount.UseVisualStyleBackColor = false;
            btnOpenAccount.Click += btnOpenAccount_Click;
            // 
            // gbPersonalAccount
            // 
            gbPersonalAccount.Controls.Add(cbPaymentSystem);
            gbPersonalAccount.Controls.Add(lblPaymentSystem);
            gbPersonalAccount.Location = new Point(12, 11);
            gbPersonalAccount.Name = "gbPersonalAccount";
            gbPersonalAccount.Size = new Size(340, 113);
            gbPersonalAccount.TabIndex = 4;
            gbPersonalAccount.TabStop = false;
            // 
            // OpenCardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(364, 176);
            Controls.Add(btnOpenAccount);
            Controls.Add(gbPersonalAccount);
            Controls.Add(gbBusinessAccount);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "OpenCardForm";
            Text = "Відкриття рахунку";
            gbBusinessAccount.ResumeLayout(false);
            gbBusinessAccount.PerformLayout();
            gbPersonalAccount.ResumeLayout(false);
            gbPersonalAccount.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbBusinessAccount;
        private ComboBox cbPaymentSystem;
        private Label lblPaymentSystem;
        private TextBox tbCompanyName;
        private Label lblCompanyNumber;
        private Label lblCompanyName;
        private TextBox tbCompanyNumber;
        private Button btnOpenAccount;
        private GroupBox gbPersonalAccount;
    }
}