namespace Course.Forms
{
    partial class TimeDeltaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeDeltaForm));
            nudSeconds = new NumericUpDown();
            nudMinutes = new NumericUpDown();
            nudHours = new NumericUpDown();
            nudDays = new NumericUpDown();
            lblSeconds = new Label();
            lblMinutes = new Label();
            lblHours = new Label();
            lblDays = new Label();
            btnSave = new Button();
            lblTitle = new Label();
            nudAmount = new NumericUpDown();
            btnExpand = new Button();
            btnDeposit = new Button();
            btnWithdraw = new Button();
            btnPayout = new Button();
            tbReason = new TextBox();
            btnBlock = new Button();
            tbCompanyName = new TextBox();
            tbCompanyNumber = new TextBox();
            tbCompanyIBAN = new TextBox();
            tbCompanyOwner = new TextBox();
            btnAddService = new Button();
            btnDeleteService = new Button();
            gbAccount = new GroupBox();
            cbCard = new ComboBox();
            btnDeleteAccount = new Button();
            gbService = new GroupBox();
            cbServices = new ComboBox();
            lblSmile = new Label();
            ((System.ComponentModel.ISupportInitialize)nudSeconds).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinutes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudHours).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            gbAccount.SuspendLayout();
            gbService.SuspendLayout();
            SuspendLayout();
            // 
            // nudSeconds
            // 
            nudSeconds.Location = new Point(74, 44);
            nudSeconds.Name = "nudSeconds";
            nudSeconds.Size = new Size(88, 23);
            nudSeconds.TabIndex = 0;
            // 
            // nudMinutes
            // 
            nudMinutes.Location = new Point(74, 92);
            nudMinutes.Name = "nudMinutes";
            nudMinutes.Size = new Size(88, 23);
            nudMinutes.TabIndex = 1;
            // 
            // nudHours
            // 
            nudHours.Location = new Point(243, 44);
            nudHours.Name = "nudHours";
            nudHours.Size = new Size(88, 23);
            nudHours.TabIndex = 2;
            // 
            // nudDays
            // 
            nudDays.Location = new Point(243, 92);
            nudDays.Name = "nudDays";
            nudDays.Size = new Size(88, 23);
            nudDays.TabIndex = 3;
            // 
            // lblSeconds
            // 
            lblSeconds.AutoSize = true;
            lblSeconds.Location = new Point(12, 46);
            lblSeconds.Name = "lblSeconds";
            lblSeconds.Size = new Size(56, 15);
            lblSeconds.TabIndex = 5;
            lblSeconds.Text = "Секунди:";
            // 
            // lblMinutes
            // 
            lblMinutes.AutoSize = true;
            lblMinutes.Location = new Point(10, 94);
            lblMinutes.Name = "lblMinutes";
            lblMinutes.Size = new Size(58, 15);
            lblMinutes.TabIndex = 6;
            lblMinutes.Text = "Хвилини:";
            // 
            // lblHours
            // 
            lblHours.AutoSize = true;
            lblHours.Location = new Point(187, 46);
            lblHours.Name = "lblHours";
            lblHours.Size = new Size(50, 15);
            lblHours.TabIndex = 7;
            lblHours.Text = "Години:";
            // 
            // lblDays
            // 
            lblDays.AutoSize = true;
            lblDays.Location = new Point(198, 94);
            lblDays.Name = "lblDays";
            lblDays.Size = new Size(39, 15);
            lblDays.TabIndex = 8;
            lblDays.Text = "Доби:";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkSeaGreen;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Location = new Point(75, 133);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(214, 26);
            btnSave.TabIndex = 4;
            btnSave.Text = "Зберегти час та закрити";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(77, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(211, 21);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Додати час до поточного";
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new Point(6, 51);
            nudAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudAmount.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(107, 23);
            nudAmount.TabIndex = 11;
            nudAmount.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            // 
            // btnExpand
            // 
            btnExpand.Location = new Point(327, 133);
            btnExpand.Name = "btnExpand";
            btnExpand.Size = new Size(25, 26);
            btnExpand.TabIndex = 5;
            btnExpand.Text = ">";
            btnExpand.UseVisualStyleBackColor = true;
            btnExpand.Click += btnExpand_Click;
            // 
            // btnDeposit
            // 
            btnDeposit.Enabled = false;
            btnDeposit.Location = new Point(119, 51);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(82, 23);
            btnDeposit.TabIndex = 12;
            btnDeposit.Text = "Поповнити";
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // btnWithdraw
            // 
            btnWithdraw.Enabled = false;
            btnWithdraw.Location = new Point(207, 51);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(67, 23);
            btnWithdraw.TabIndex = 13;
            btnWithdraw.Text = "Зняти";
            btnWithdraw.UseVisualStyleBackColor = true;
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // btnPayout
            // 
            btnPayout.Enabled = false;
            btnPayout.Location = new Point(280, 51);
            btnPayout.Name = "btnPayout";
            btnPayout.Size = new Size(75, 23);
            btnPayout.TabIndex = 14;
            btnPayout.Text = "Виплатити";
            btnPayout.UseVisualStyleBackColor = true;
            btnPayout.Click += btnPayout_Click;
            // 
            // tbReason
            // 
            tbReason.Location = new Point(6, 80);
            tbReason.Name = "tbReason";
            tbReason.PlaceholderText = "Причина";
            tbReason.Size = new Size(154, 23);
            tbReason.TabIndex = 15;
            // 
            // btnBlock
            // 
            btnBlock.Enabled = false;
            btnBlock.Location = new Point(166, 80);
            btnBlock.Name = "btnBlock";
            btnBlock.Size = new Size(68, 23);
            btnBlock.TabIndex = 16;
            btnBlock.Text = "(раз)блок";
            btnBlock.UseVisualStyleBackColor = true;
            btnBlock.Click += btnBlock_Click;
            // 
            // tbCompanyName
            // 
            tbCompanyName.Location = new Point(6, 22);
            tbCompanyName.Name = "tbCompanyName";
            tbCompanyName.PlaceholderText = "Назва компанії";
            tbCompanyName.Size = new Size(130, 23);
            tbCompanyName.TabIndex = 20;
            // 
            // tbCompanyNumber
            // 
            tbCompanyNumber.Location = new Point(144, 22);
            tbCompanyNumber.Name = "tbCompanyNumber";
            tbCompanyNumber.PlaceholderText = "ІПН / ЄДРПОУ";
            tbCompanyNumber.Size = new Size(130, 23);
            tbCompanyNumber.TabIndex = 21;
            // 
            // tbCompanyIBAN
            // 
            tbCompanyIBAN.Location = new Point(144, 51);
            tbCompanyIBAN.Name = "tbCompanyIBAN";
            tbCompanyIBAN.PlaceholderText = "IBAN";
            tbCompanyIBAN.Size = new Size(130, 23);
            tbCompanyIBAN.TabIndex = 23;
            // 
            // tbCompanyOwner
            // 
            tbCompanyOwner.Location = new Point(6, 51);
            tbCompanyOwner.Name = "tbCompanyOwner";
            tbCompanyOwner.PlaceholderText = "ФІО власника";
            tbCompanyOwner.Size = new Size(130, 23);
            tbCompanyOwner.TabIndex = 22;
            // 
            // btnAddService
            // 
            btnAddService.Location = new Point(280, 22);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(75, 52);
            btnAddService.TabIndex = 24;
            btnAddService.Text = "Додати компанію";
            btnAddService.UseVisualStyleBackColor = true;
            btnAddService.Click += btnAddService_Click;
            // 
            // btnDeleteService
            // 
            btnDeleteService.Enabled = false;
            btnDeleteService.Location = new Point(280, 79);
            btnDeleteService.Name = "btnDeleteService";
            btnDeleteService.Size = new Size(75, 23);
            btnDeleteService.TabIndex = 26;
            btnDeleteService.Text = "Видалити";
            btnDeleteService.UseVisualStyleBackColor = true;
            btnDeleteService.Click += btnDeleteService_Click;
            // 
            // gbAccount
            // 
            gbAccount.Controls.Add(cbCard);
            gbAccount.Controls.Add(nudAmount);
            gbAccount.Controls.Add(btnDeposit);
            gbAccount.Controls.Add(btnWithdraw);
            gbAccount.Controls.Add(btnPayout);
            gbAccount.Controls.Add(tbReason);
            gbAccount.Controls.Add(btnDeleteAccount);
            gbAccount.Controls.Add(btnBlock);
            gbAccount.Location = new Point(371, 12);
            gbAccount.Name = "gbAccount";
            gbAccount.Size = new Size(361, 112);
            gbAccount.TabIndex = 26;
            gbAccount.TabStop = false;
            gbAccount.Text = "Рахунок";
            // 
            // cbCard
            // 
            cbCard.FormattingEnabled = true;
            cbCard.Location = new Point(6, 22);
            cbCard.Name = "cbCard";
            cbCard.Size = new Size(349, 23);
            cbCard.TabIndex = 10;
            cbCard.SelectedIndexChanged += cbCard_SelectedIndexChanged;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.BackColor = Color.IndianRed;
            btnDeleteAccount.Enabled = false;
            btnDeleteAccount.FlatStyle = FlatStyle.Popup;
            btnDeleteAccount.Location = new Point(240, 80);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(115, 23);
            btnDeleteAccount.TabIndex = 17;
            btnDeleteAccount.Text = "Видалити рахунок";
            btnDeleteAccount.UseVisualStyleBackColor = false;
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            // 
            // gbService
            // 
            gbService.Controls.Add(cbServices);
            gbService.Controls.Add(btnDeleteService);
            gbService.Controls.Add(btnAddService);
            gbService.Controls.Add(tbCompanyName);
            gbService.Controls.Add(tbCompanyNumber);
            gbService.Controls.Add(tbCompanyIBAN);
            gbService.Controls.Add(tbCompanyOwner);
            gbService.Location = new Point(371, 130);
            gbService.Name = "gbService";
            gbService.Size = new Size(361, 112);
            gbService.TabIndex = 27;
            gbService.TabStop = false;
            gbService.Text = "Послуги (компанії)";
            // 
            // cbServices
            // 
            cbServices.FormattingEnabled = true;
            cbServices.Location = new Point(6, 80);
            cbServices.Name = "cbServices";
            cbServices.Size = new Size(268, 23);
            cbServices.TabIndex = 25;
            cbServices.SelectedIndexChanged += cbServices_SelectedIndexChanged;
            // 
            // lblSmile
            // 
            lblSmile.AutoSize = true;
            lblSmile.Font = new Font("Segoe UI Black", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            lblSmile.Location = new Point(127, 162);
            lblSmile.Name = "lblSmile";
            lblSmile.Size = new Size(110, 86);
            lblSmile.TabIndex = 28;
            lblSmile.Text = "=)";
            // 
            // TimeDeltaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(364, 176);
            Controls.Add(lblSmile);
            Controls.Add(gbService);
            Controls.Add(gbAccount);
            Controls.Add(btnExpand);
            Controls.Add(lblTitle);
            Controls.Add(btnSave);
            Controls.Add(lblDays);
            Controls.Add(lblHours);
            Controls.Add(lblMinutes);
            Controls.Add(lblSeconds);
            Controls.Add(nudDays);
            Controls.Add(nudHours);
            Controls.Add(nudMinutes);
            Controls.Add(nudSeconds);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "TimeDeltaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Зміна часу";
            ((System.ComponentModel.ISupportInitialize)nudSeconds).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMinutes).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudHours).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            gbAccount.ResumeLayout(false);
            gbAccount.PerformLayout();
            gbService.ResumeLayout(false);
            gbService.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown nudSeconds;
        private NumericUpDown nudMinutes;
        private NumericUpDown nudHours;
        private NumericUpDown nudDays;
        private Label lblSeconds;
        private Label lblMinutes;
        private Label lblHours;
        private Label lblDays;
        private Button btnSave;
        private Label lblTitle;
        private NumericUpDown nudAmount;
        private Button btnExpand;
        private Button btnDeposit;
        private Button btnWithdraw;
        private Button btnPayout;
        private TextBox tbReason;
        private Button btnBlock;
        private TextBox tbCompanyName;
        private TextBox tbCompanyNumber;
        private TextBox tbCompanyIBAN;
        private TextBox tbCompanyOwner;
        private Button btnAddService;
        private Button btnDeleteService;
        private GroupBox gbAccount;
        private GroupBox gbService;
        private ComboBox cbCard;
        private ComboBox cbServices;
        private Label lblSmile;
        private Button btnDeleteAccount;
    }
}