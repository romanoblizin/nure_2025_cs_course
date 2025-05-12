namespace Course
{
    partial class MenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            panelHeader = new Panel();
            lblTime = new Label();
            panelUser = new Panel();
            pbUser = new PictureBox();
            lblUser = new Label();
            panelLogo = new Panel();
            lblLogo = new Label();
            pbLogo = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            cbCard = new ComboBox();
            gbAccountControl = new GroupBox();
            gbSearch = new GroupBox();
            lblSearch = new Label();
            tbSearch = new TextBox();
            cbSearch = new ComboBox();
            gbTransfer = new GroupBox();
            lblTransferTarget = new Label();
            lblTransferComment = new Label();
            tbTransferTarget = new TextBox();
            lblTransferAmount = new Label();
            nudTransferAmount = new NumericUpDown();
            btnTransfer = new Button();
            tbTransferComment = new TextBox();
            btnPremium = new Button();
            lblBalance = new Label();
            gbBusinessAccountControl = new GroupBox();
            btnChangeTable = new Button();
            cbBusinessPaymentSystem = new ComboBox();
            tbBusinessFullName = new TextBox();
            lblPaymentSystem = new Label();
            lblBusinessFullName = new Label();
            btnOpenCard = new Button();
            dgvTransactions = new DataGridView();
            ColumnDateTime = new DataGridViewTextBoxColumn();
            TypeColumn = new DataGridViewTextBoxColumn();
            AmountColumn = new DataGridViewTextBoxColumn();
            TargetColumn = new DataGridViewTextBoxColumn();
            DescriptionColumn = new DataGridViewTextBoxColumn();
            ReceiptColumn = new DataGridViewButtonColumn();
            dataGridView1 = new DataGridView();
            gbPersonalAccountControl = new GroupBox();
            lblCVV = new Label();
            lblExpirationDate = new Label();
            button2 = new Button();
            lblSelectAccount = new Label();
            gbAccountBlocked = new GroupBox();
            lblAccountBlocked = new Label();
            lblHeaderAccountBlocked = new Label();
            CardNumberColumn = new DataGridViewTextBoxColumn();
            OwnerFullNameColumn = new DataGridViewTextBoxColumn();
            CardExpireDateColumn = new DataGridViewTextBoxColumn();
            CVVColumn = new DataGridViewTextBoxColumn();
            RenewCardColumn = new DataGridViewButtonColumn();
            tbCardNumber = new TextBox();
            tbIBAN = new TextBox();
            lblIBAN = new Label();
            panelHeader.SuspendLayout();
            panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUser).BeginInit();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            gbAccountControl.SuspendLayout();
            gbSearch.SuspendLayout();
            gbTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTransferAmount).BeginInit();
            gbBusinessAccountControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            gbPersonalAccountControl.SuspendLayout();
            gbAccountBlocked.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ControlDarkDark;
            panelHeader.Controls.Add(lblTime);
            panelHeader.Controls.Add(panelUser);
            panelHeader.Controls.Add(panelLogo);
            panelHeader.ForeColor = SystemColors.ControlText;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(684, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTime.ForeColor = SystemColors.Control;
            lblTime.Location = new Point(225, 9);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(182, 30);
            lblTime.TabIndex = 4;
            lblTime.Text = "01.01.1970 0:00:00";
            lblTime.MouseDoubleClick += lblTime_MouseDoubleClick;
            // 
            // panelUser
            // 
            panelUser.Controls.Add(pbUser);
            panelUser.Controls.Add(lblUser);
            panelUser.Location = new Point(465, 0);
            panelUser.Name = "panelUser";
            panelUser.Size = new Size(216, 50);
            panelUser.TabIndex = 3;
            panelUser.Click += panelUser_Click;
            panelUser.MouseHover += panelUser_MouseHover;
            // 
            // pbUser
            // 
            pbUser.Image = Properties.Resources.user_icon;
            pbUser.Location = new Point(158, 0);
            pbUser.Name = "pbUser";
            pbUser.Size = new Size(55, 50);
            pbUser.SizeMode = PictureBoxSizeMode.Zoom;
            pbUser.TabIndex = 3;
            pbUser.TabStop = false;
            pbUser.Click += panelUser_Click;
            pbUser.MouseHover += panelUser_MouseHover;
            // 
            // lblUser
            // 
            lblUser.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(-153, 15);
            lblUser.Name = "lblUser";
            lblUser.RightToLeft = RightToLeft.No;
            lblUser.Size = new Size(315, 21);
            lblUser.TabIndex = 2;
            lblUser.TextAlign = ContentAlignment.MiddleRight;
            lblUser.Click += panelUser_Click;
            lblUser.MouseHover += panelUser_MouseHover;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(lblLogo);
            panelLogo.Controls.Add(pbLogo);
            panelLogo.Location = new Point(3, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(147, 50);
            panelLogo.TabIndex = 1;
            panelLogo.MouseHover += panelLogo_MouseHover;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("ROG Fonts", 20F, FontStyle.Bold);
            lblLogo.ForeColor = SystemColors.Control;
            lblLogo.Location = new Point(51, 9);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(92, 32);
            lblLogo.TabIndex = 2;
            lblLogo.Text = "БАНК";
            lblLogo.MouseHover += panelLogo_MouseHover;
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(0, 3);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(53, 44);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            pbLogo.MouseHover += panelLogo_MouseHover;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // cbCard
            // 
            cbCard.FormattingEnabled = true;
            cbCard.Location = new Point(207, 66);
            cbCard.Name = "cbCard";
            cbCard.Size = new Size(377, 23);
            cbCard.TabIndex = 1;
            cbCard.SelectedIndexChanged += cbCard_SelectedIndexChanged;
            // 
            // gbAccountControl
            // 
            gbAccountControl.Controls.Add(gbSearch);
            gbAccountControl.Controls.Add(gbTransfer);
            gbAccountControl.Controls.Add(btnPremium);
            gbAccountControl.Controls.Add(lblBalance);
            gbAccountControl.Controls.Add(dataGridView1);
            gbAccountControl.Controls.Add(dgvTransactions);
            gbAccountControl.Controls.Add(gbPersonalAccountControl);
            gbAccountControl.Controls.Add(gbBusinessAccountControl);
            gbAccountControl.Location = new Point(12, 95);
            gbAccountControl.Name = "gbAccountControl";
            gbAccountControl.Size = new Size(660, 354);
            gbAccountControl.TabIndex = 2;
            gbAccountControl.TabStop = false;
            // 
            // gbSearch
            // 
            gbSearch.Controls.Add(lblSearch);
            gbSearch.Controls.Add(tbSearch);
            gbSearch.Controls.Add(cbSearch);
            gbSearch.Location = new Point(283, 81);
            gbSearch.Name = "gbSearch";
            gbSearch.Size = new Size(171, 101);
            gbSearch.TabIndex = 18;
            gbSearch.TabStop = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(62, 19);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(46, 15);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Пошук";
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(6, 69);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(159, 23);
            tbSearch.TabIndex = 1;
            // 
            // cbSearch
            // 
            cbSearch.FormattingEnabled = true;
            cbSearch.Location = new Point(6, 40);
            cbSearch.Name = "cbSearch";
            cbSearch.Size = new Size(159, 23);
            cbSearch.TabIndex = 0;
            // 
            // gbTransfer
            // 
            gbTransfer.Controls.Add(lblTransferTarget);
            gbTransfer.Controls.Add(lblTransferComment);
            gbTransfer.Controls.Add(tbTransferTarget);
            gbTransfer.Controls.Add(lblTransferAmount);
            gbTransfer.Controls.Add(nudTransferAmount);
            gbTransfer.Controls.Add(btnTransfer);
            gbTransfer.Controls.Add(tbTransferComment);
            gbTransfer.Location = new Point(6, 9);
            gbTransfer.Name = "gbTransfer";
            gbTransfer.Size = new Size(271, 173);
            gbTransfer.TabIndex = 17;
            gbTransfer.TabStop = false;
            // 
            // lblTransferTarget
            // 
            lblTransferTarget.AutoSize = true;
            lblTransferTarget.Location = new Point(20, 21);
            lblTransferTarget.Name = "lblTransferTarget";
            lblTransferTarget.Size = new Size(141, 15);
            lblTransferTarget.TabIndex = 14;
            lblTransferTarget.Text = "Номер картки або IBAN:";
            // 
            // lblTransferComment
            // 
            lblTransferComment.AutoSize = true;
            lblTransferComment.Location = new Point(6, 89);
            lblTransferComment.Name = "lblTransferComment";
            lblTransferComment.Size = new Size(155, 15);
            lblTransferComment.TabIndex = 16;
            lblTransferComment.Text = "Коментар (необов'язково):";
            // 
            // tbTransferTarget
            // 
            tbTransferTarget.Location = new Point(167, 18);
            tbTransferTarget.Name = "tbTransferTarget";
            tbTransferTarget.Size = new Size(100, 23);
            tbTransferTarget.TabIndex = 3;
            // 
            // lblTransferAmount
            // 
            lblTransferAmount.AutoSize = true;
            lblTransferAmount.Location = new Point(122, 54);
            lblTransferAmount.Name = "lblTransferAmount";
            lblTransferAmount.Size = new Size(39, 15);
            lblTransferAmount.TabIndex = 15;
            lblTransferAmount.Text = "Сума:";
            // 
            // nudTransferAmount
            // 
            nudTransferAmount.DecimalPlaces = 2;
            nudTransferAmount.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nudTransferAmount.Location = new Point(167, 52);
            nudTransferAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudTransferAmount.Name = "nudTransferAmount";
            nudTransferAmount.Size = new Size(100, 23);
            nudTransferAmount.TabIndex = 12;
            nudTransferAmount.ThousandsSeparator = true;
            // 
            // btnTransfer
            // 
            btnTransfer.Location = new Point(6, 126);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(261, 29);
            btnTransfer.TabIndex = 7;
            btnTransfer.Text = "Перерахувати кошти";
            btnTransfer.UseVisualStyleBackColor = true;
            // 
            // tbTransferComment
            // 
            tbTransferComment.Location = new Point(165, 86);
            tbTransferComment.Name = "tbTransferComment";
            tbTransferComment.Size = new Size(100, 23);
            tbTransferComment.TabIndex = 13;
            // 
            // btnPremium
            // 
            btnPremium.Location = new Point(283, 52);
            btnPremium.Name = "btnPremium";
            btnPremium.Size = new Size(171, 29);
            btnPremium.TabIndex = 5;
            btnPremium.Text = "Підписатися на преміум";
            btnPremium.UseVisualStyleBackColor = true;
            // 
            // lblBalance
            // 
            lblBalance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblBalance.Location = new Point(283, 19);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(171, 23);
            lblBalance.TabIndex = 4;
            lblBalance.Text = "Баланс: 0₴";
            lblBalance.TextAlign = ContentAlignment.TopCenter;
            // 
            // gbBusinessAccountControl
            // 
            gbBusinessAccountControl.Controls.Add(btnChangeTable);
            gbBusinessAccountControl.Controls.Add(cbBusinessPaymentSystem);
            gbBusinessAccountControl.Controls.Add(tbBusinessFullName);
            gbBusinessAccountControl.Controls.Add(lblPaymentSystem);
            gbBusinessAccountControl.Controls.Add(lblBusinessFullName);
            gbBusinessAccountControl.Controls.Add(btnOpenCard);
            gbBusinessAccountControl.Location = new Point(460, 0);
            gbBusinessAccountControl.Name = "gbBusinessAccountControl";
            gbBusinessAccountControl.Size = new Size(200, 182);
            gbBusinessAccountControl.TabIndex = 0;
            gbBusinessAccountControl.TabStop = false;
            // 
            // btnChangeTable
            // 
            btnChangeTable.Location = new Point(19, 145);
            btnChangeTable.Name = "btnChangeTable";
            btnChangeTable.Size = new Size(163, 29);
            btnChangeTable.TabIndex = 14;
            btnChangeTable.Text = "Змінити таблицю";
            btnChangeTable.UseVisualStyleBackColor = true;
            // 
            // cbBusinessPaymentSystem
            // 
            cbBusinessPaymentSystem.FormattingEnabled = true;
            cbBusinessPaymentSystem.Location = new Point(19, 81);
            cbBusinessPaymentSystem.Name = "cbBusinessPaymentSystem";
            cbBusinessPaymentSystem.Size = new Size(163, 23);
            cbBusinessPaymentSystem.TabIndex = 13;
            // 
            // tbBusinessFullName
            // 
            tbBusinessFullName.Location = new Point(19, 37);
            tbBusinessFullName.Name = "tbBusinessFullName";
            tbBusinessFullName.Size = new Size(163, 23);
            tbBusinessFullName.TabIndex = 12;
            // 
            // lblPaymentSystem
            // 
            lblPaymentSystem.AutoSize = true;
            lblPaymentSystem.Location = new Point(45, 63);
            lblPaymentSystem.Name = "lblPaymentSystem";
            lblPaymentSystem.Size = new Size(110, 15);
            lblPaymentSystem.TabIndex = 11;
            lblPaymentSystem.Text = "Платіжна система:";
            // 
            // lblBusinessFullName
            // 
            lblBusinessFullName.AutoSize = true;
            lblBusinessFullName.Location = new Point(57, 19);
            lblBusinessFullName.Name = "lblBusinessFullName";
            lblBusinessFullName.Size = new Size(85, 15);
            lblBusinessFullName.TabIndex = 10;
            lblBusinessFullName.Text = "ФІО власника:";
            // 
            // btnOpenCard
            // 
            btnOpenCard.Location = new Point(19, 110);
            btnOpenCard.Name = "btnOpenCard";
            btnOpenCard.Size = new Size(163, 29);
            btnOpenCard.TabIndex = 4;
            btnOpenCard.Text = "Випустити нову картку";
            btnOpenCard.UseVisualStyleBackColor = true;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.AllowUserToResizeColumns = false;
            dgvTransactions.AllowUserToResizeRows = false;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Columns.AddRange(new DataGridViewColumn[] { ColumnDateTime, TypeColumn, AmountColumn, TargetColumn, DescriptionColumn, ReceiptColumn });
            dgvTransactions.Location = new Point(0, 188);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.Size = new Size(660, 166);
            dgvTransactions.TabIndex = 2;
            // 
            // ColumnDateTime
            // 
            ColumnDateTime.HeaderText = "Дата";
            ColumnDateTime.Name = "ColumnDateTime";
            ColumnDateTime.ReadOnly = true;
            ColumnDateTime.Width = 90;
            // 
            // TypeColumn
            // 
            TypeColumn.HeaderText = "Тип";
            TypeColumn.Name = "TypeColumn";
            TypeColumn.ReadOnly = true;
            TypeColumn.Width = 140;
            // 
            // AmountColumn
            // 
            AmountColumn.HeaderText = "Сума";
            AmountColumn.Name = "AmountColumn";
            AmountColumn.ReadOnly = true;
            AmountColumn.Width = 75;
            // 
            // TargetColumn
            // 
            TargetColumn.HeaderText = "Контрагент";
            TargetColumn.Name = "TargetColumn";
            TargetColumn.ReadOnly = true;
            TargetColumn.Width = 130;
            // 
            // DescriptionColumn
            // 
            DescriptionColumn.HeaderText = "Опис";
            DescriptionColumn.Name = "DescriptionColumn";
            DescriptionColumn.ReadOnly = true;
            DescriptionColumn.Width = 147;
            // 
            // ReceiptColumn
            // 
            ReceiptColumn.HeaderText = "Квітанція";
            ReceiptColumn.Name = "ReceiptColumn";
            ReceiptColumn.ReadOnly = true;
            ReceiptColumn.Width = 75;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { CardNumberColumn, OwnerFullNameColumn, CardExpireDateColumn, CVVColumn, RenewCardColumn });
            dataGridView1.Location = new Point(0, 188);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(660, 166);
            dataGridView1.TabIndex = 9;
            // 
            // gbPersonalAccountControl
            // 
            gbPersonalAccountControl.Controls.Add(lblIBAN);
            gbPersonalAccountControl.Controls.Add(tbIBAN);
            gbPersonalAccountControl.Controls.Add(tbCardNumber);
            gbPersonalAccountControl.Controls.Add(lblCVV);
            gbPersonalAccountControl.Controls.Add(lblExpirationDate);
            gbPersonalAccountControl.Controls.Add(button2);
            gbPersonalAccountControl.Location = new Point(460, 0);
            gbPersonalAccountControl.Name = "gbPersonalAccountControl";
            gbPersonalAccountControl.Size = new Size(200, 182);
            gbPersonalAccountControl.TabIndex = 1;
            gbPersonalAccountControl.TabStop = false;
            // 
            // lblCVV
            // 
            lblCVV.AutoSize = true;
            lblCVV.Location = new Point(157, 63);
            lblCVV.Name = "lblCVV";
            lblCVV.Size = new Size(25, 15);
            lblCVV.TabIndex = 10;
            lblCVV.Text = "000";
            // 
            // lblExpirationDate
            // 
            lblExpirationDate.AutoSize = true;
            lblExpirationDate.Location = new Point(19, 63);
            lblExpirationDate.Name = "lblExpirationDate";
            lblExpirationDate.Size = new Size(36, 15);
            lblExpirationDate.TabIndex = 11;
            lblExpirationDate.Text = "01/25";
            // 
            // button2
            // 
            button2.Location = new Point(19, 144);
            button2.Name = "button2";
            button2.Size = new Size(163, 29);
            button2.TabIndex = 6;
            button2.Text = "Перевипустити картку";
            button2.UseVisualStyleBackColor = true;
            // 
            // lblSelectAccount
            // 
            lblSelectAccount.AutoSize = true;
            lblSelectAccount.Location = new Point(100, 69);
            lblSelectAccount.Name = "lblSelectAccount";
            lblSelectAccount.Size = new Size(101, 15);
            lblSelectAccount.TabIndex = 3;
            lblSelectAccount.Text = "Оберіть рахунок:";
            // 
            // gbAccountBlocked
            // 
            gbAccountBlocked.Controls.Add(lblAccountBlocked);
            gbAccountBlocked.Controls.Add(lblHeaderAccountBlocked);
            gbAccountBlocked.Location = new Point(12, 95);
            gbAccountBlocked.Name = "gbAccountBlocked";
            gbAccountBlocked.Size = new Size(660, 354);
            gbAccountBlocked.TabIndex = 0;
            gbAccountBlocked.TabStop = false;
            // 
            // lblAccountBlocked
            // 
            lblAccountBlocked.Location = new Point(99, 167);
            lblAccountBlocked.Name = "lblAccountBlocked";
            lblAccountBlocked.Size = new Size(462, 163);
            lblAccountBlocked.TabIndex = 1;
            lblAccountBlocked.Text = "Причина: причина не вказана";
            lblAccountBlocked.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblHeaderAccountBlocked
            // 
            lblHeaderAccountBlocked.AutoSize = true;
            lblHeaderAccountBlocked.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblHeaderAccountBlocked.Location = new Point(162, 96);
            lblHeaderAccountBlocked.Name = "lblHeaderAccountBlocked";
            lblHeaderAccountBlocked.Size = new Size(336, 32);
            lblHeaderAccountBlocked.TabIndex = 0;
            lblHeaderAccountBlocked.Text = "Ваш рахунок заблоковано!";
            // 
            // CardNumberColumn
            // 
            CardNumberColumn.HeaderText = "Номер картки";
            CardNumberColumn.Name = "CardNumberColumn";
            CardNumberColumn.ReadOnly = true;
            CardNumberColumn.Width = 150;
            // 
            // OwnerFullNameColumn
            // 
            OwnerFullNameColumn.HeaderText = "ФІО власника";
            OwnerFullNameColumn.Name = "OwnerFullNameColumn";
            OwnerFullNameColumn.ReadOnly = true;
            OwnerFullNameColumn.Width = 220;
            // 
            // CardExpireDateColumn
            // 
            CardExpireDateColumn.HeaderText = "Термін дії";
            CardExpireDateColumn.Name = "CardExpireDateColumn";
            CardExpireDateColumn.ReadOnly = true;
            // 
            // CVVColumn
            // 
            CVVColumn.HeaderText = "CVV";
            CVVColumn.Name = "CVVColumn";
            CVVColumn.ReadOnly = true;
            CVVColumn.Width = 65;
            // 
            // RenewCardColumn
            // 
            RenewCardColumn.HeaderText = "Перевипуск картки";
            RenewCardColumn.Name = "RenewCardColumn";
            RenewCardColumn.ReadOnly = true;
            RenewCardColumn.Width = 122;
            // 
            // tbCardNumber
            // 
            tbCardNumber.Location = new Point(19, 27);
            tbCardNumber.Name = "tbCardNumber";
            tbCardNumber.ReadOnly = true;
            tbCardNumber.Size = new Size(163, 23);
            tbCardNumber.TabIndex = 12;
            // 
            // tbIBAN
            // 
            tbIBAN.Location = new Point(19, 110);
            tbIBAN.Name = "tbIBAN";
            tbIBAN.ReadOnly = true;
            tbIBAN.Size = new Size(163, 23);
            tbIBAN.TabIndex = 13;
            // 
            // lblIBAN
            // 
            lblIBAN.AutoSize = true;
            lblIBAN.Location = new Point(75, 89);
            lblIBAN.Name = "lblIBAN";
            lblIBAN.Size = new Size(37, 15);
            lblIBAN.TabIndex = 14;
            lblIBAN.Text = "IBAN:";
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(684, 461);
            Controls.Add(lblSelectAccount);
            Controls.Add(cbCard);
            Controls.Add(panelHeader);
            Controls.Add(gbAccountControl);
            Controls.Add(gbAccountBlocked);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(700, 500);
            MinimumSize = new Size(700, 500);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Банк";
            FormClosing += MenuForm_FormClosing;
            Shown += MenuForm_Shown;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUser).EndInit();
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            gbAccountControl.ResumeLayout(false);
            gbSearch.ResumeLayout(false);
            gbSearch.PerformLayout();
            gbTransfer.ResumeLayout(false);
            gbTransfer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTransferAmount).EndInit();
            gbBusinessAccountControl.ResumeLayout(false);
            gbBusinessAccountControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            gbPersonalAccountControl.ResumeLayout(false);
            gbPersonalAccountControl.PerformLayout();
            gbAccountBlocked.ResumeLayout(false);
            gbAccountBlocked.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private PictureBox pbLogo;
        private Panel panelLogo;
        private Label lblLogo;
        private Label lblUser;
        private Panel panelUser;
        private PictureBox pbUser;
        private Label lblTime;
        private System.Windows.Forms.Timer timer;
        private ComboBox cbCard;
        private GroupBox gbAccountControl;
        private Label lblSelectAccount;
        private GroupBox gbAccountBlocked;
        private Label lblAccountBlocked;
        private Label lblHeaderAccountBlocked;
        private GroupBox gbBusinessAccountControl;
        private GroupBox gbPersonalAccountControl;
        private DataGridView dgvTransactions;
        private Label lblBalance;
        private TextBox tbTransferTarget;
        private NumericUpDown nudTransferAmount;
        private Label lblExpirationDate;
        private Label lblCVV;
        private Button btnOpenCard;
        private Button btnTransfer;
        private Button button2;
        private Button btnPremium;
        private TextBox tbTransferComment;
        private Label lblTransferComment;
        private Label lblTransferAmount;
        private Label lblTransferTarget;
        private GroupBox gbTransfer;
        private DataGridView dataGridView1;
        private ComboBox cbBusinessPaymentSystem;
        private TextBox tbBusinessFullName;
        private Label lblPaymentSystem;
        private Label lblBusinessFullName;
        private Button btnChangeTable;
        private DataGridViewTextBoxColumn ColumnDateTime;
        private DataGridViewTextBoxColumn TypeColumn;
        private DataGridViewTextBoxColumn AmountColumn;
        private DataGridViewTextBoxColumn TargetColumn;
        private DataGridViewTextBoxColumn DescriptionColumn;
        private DataGridViewButtonColumn ReceiptColumn;
        private GroupBox gbSearch;
        private Label lblSearch;
        private TextBox tbSearch;
        private ComboBox cbSearch;
        private DataGridViewTextBoxColumn CardNumberColumn;
        private DataGridViewTextBoxColumn OwnerFullNameColumn;
        private DataGridViewTextBoxColumn CardExpireDateColumn;
        private DataGridViewTextBoxColumn CVVColumn;
        private DataGridViewButtonColumn RenewCardColumn;
        private TextBox tbCardNumber;
        private Label lblIBAN;
        private TextBox tbIBAN;
    }
}
