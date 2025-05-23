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
            cbAccount = new ComboBox();
            gbAccountControl = new GroupBox();
            gbTransfer = new GroupBox();
            btnPayment = new Button();
            lblTransferTarget = new Label();
            tbTransferTarget = new TextBox();
            lblTransferAmount = new Label();
            nudTransferAmount = new NumericUpDown();
            btnTransfer = new Button();
            tbTransferComment = new TextBox();
            lblBalance = new Label();
            gbSearchTransactions = new GroupBox();
            dtpSearchEnd = new DateTimePicker();
            dtpSearchStart = new DateTimePicker();
            lblSearch = new Label();
            tbSearch = new TextBox();
            cbSearch = new ComboBox();
            gbSearchBusinessCards = new GroupBox();
            cbSearchBusinessCardsOnlyExpired = new CheckBox();
            cbSearchBusinessCardsOnlyUnexpired = new CheckBox();
            lblHeaderSearchBusinessCards = new Label();
            tbSearchBusinessCards = new TextBox();
            dgvTransactions = new DataGridView();
            NumberColumn = new DataGridViewTextBoxColumn();
            DateTimeColumn = new DataGridViewTextBoxColumn();
            TypeColumn = new DataGridViewTextBoxColumn();
            AmountColumn = new DataGridViewTextBoxColumn();
            TargetColumn = new DataGridViewTextBoxColumn();
            DescriptionColumn = new DataGridViewTextBoxColumn();
            ReceiptColumn = new DataGridViewButtonColumn();
            dgvBusinessCards = new DataGridView();
            CardNumberColumn = new DataGridViewTextBoxColumn();
            OwnerFullNameColumn = new DataGridViewTextBoxColumn();
            CardExpireDateColumn = new DataGridViewTextBoxColumn();
            CVVColumn = new DataGridViewTextBoxColumn();
            RenewCardColumn = new DataGridViewButtonColumn();
            gbPersonalAccountControl = new GroupBox();
            lblIBAN = new Label();
            tbIBAN = new TextBox();
            tbCardNumber = new TextBox();
            lblCVV = new Label();
            lblExpireDate = new Label();
            btnRenewCard = new Button();
            gbBusinessAccountControl = new GroupBox();
            btnChangeTable = new Button();
            cbBusinessPaymentSystem = new ComboBox();
            tbBusinessFullName = new TextBox();
            lblPaymentSystem = new Label();
            lblBusinessFullName = new Label();
            btnOpenCard = new Button();
            btnSubscribePremium = new Button();
            btnUnsubscribePremium = new Button();
            btnOpenDeposit = new Button();
            lblSelectAccount = new Label();
            gbAccountBlocked = new GroupBox();
            lblAccountBlocked = new Label();
            lblHeaderAccountBlocked = new Label();
            panelHeader.SuspendLayout();
            panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUser).BeginInit();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            gbAccountControl.SuspendLayout();
            gbTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTransferAmount).BeginInit();
            gbSearchTransactions.SuspendLayout();
            gbSearchBusinessCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBusinessCards).BeginInit();
            gbPersonalAccountControl.SuspendLayout();
            gbBusinessAccountControl.SuspendLayout();
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
            lblUser.Location = new Point(-62, 15);
            lblUser.Name = "lblUser";
            lblUser.RightToLeft = RightToLeft.No;
            lblUser.Size = new Size(224, 21);
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
            // cbAccount
            // 
            cbAccount.FormattingEnabled = true;
            cbAccount.Location = new Point(207, 66);
            cbAccount.Name = "cbAccount";
            cbAccount.Size = new Size(377, 23);
            cbAccount.TabIndex = 1;
            cbAccount.SelectedIndexChanged += cbAccount_SelectedIndexChanged;
            // 
            // gbAccountControl
            // 
            gbAccountControl.Controls.Add(gbTransfer);
            gbAccountControl.Controls.Add(lblBalance);
            gbAccountControl.Controls.Add(gbSearchTransactions);
            gbAccountControl.Controls.Add(gbSearchBusinessCards);
            gbAccountControl.Controls.Add(dgvTransactions);
            gbAccountControl.Controls.Add(dgvBusinessCards);
            gbAccountControl.Controls.Add(gbPersonalAccountControl);
            gbAccountControl.Controls.Add(gbBusinessAccountControl);
            gbAccountControl.Controls.Add(btnSubscribePremium);
            gbAccountControl.Controls.Add(btnUnsubscribePremium);
            gbAccountControl.Controls.Add(btnOpenDeposit);
            gbAccountControl.Location = new Point(12, 95);
            gbAccountControl.Name = "gbAccountControl";
            gbAccountControl.Size = new Size(660, 354);
            gbAccountControl.TabIndex = 2;
            gbAccountControl.TabStop = false;
            gbAccountControl.Visible = false;
            // 
            // gbTransfer
            // 
            gbTransfer.Controls.Add(btnPayment);
            gbTransfer.Controls.Add(lblTransferTarget);
            gbTransfer.Controls.Add(tbTransferTarget);
            gbTransfer.Controls.Add(lblTransferAmount);
            gbTransfer.Controls.Add(nudTransferAmount);
            gbTransfer.Controls.Add(btnTransfer);
            gbTransfer.Controls.Add(tbTransferComment);
            gbTransfer.Location = new Point(0, 0);
            gbTransfer.Name = "gbTransfer";
            gbTransfer.Size = new Size(183, 182);
            gbTransfer.TabIndex = 17;
            gbTransfer.TabStop = false;
            gbTransfer.Text = "Переказ коштів";
            // 
            // btnPayment
            // 
            btnPayment.Location = new Point(5, 144);
            btnPayment.Name = "btnPayment";
            btnPayment.Size = new Size(172, 29);
            btnPayment.TabIndex = 6;
            btnPayment.Text = "Сплатити послугу";
            btnPayment.UseVisualStyleBackColor = true;
            btnPayment.Click += btnPayment_Click;
            // 
            // lblTransferTarget
            // 
            lblTransferTarget.AutoSize = true;
            lblTransferTarget.Location = new Point(18, 16);
            lblTransferTarget.Name = "lblTransferTarget";
            lblTransferTarget.Size = new Size(0, 15);
            lblTransferTarget.TabIndex = 14;
            // 
            // tbTransferTarget
            // 
            tbTransferTarget.Location = new Point(6, 21);
            tbTransferTarget.Name = "tbTransferTarget";
            tbTransferTarget.PlaceholderText = "Номер картки або IBAN";
            tbTransferTarget.Size = new Size(172, 23);
            tbTransferTarget.TabIndex = 2;
            // 
            // lblTransferAmount
            // 
            lblTransferAmount.AutoSize = true;
            lblTransferAmount.Location = new Point(6, 50);
            lblTransferAmount.Name = "lblTransferAmount";
            lblTransferAmount.Size = new Size(39, 15);
            lblTransferAmount.TabIndex = 15;
            lblTransferAmount.Text = "Сума:";
            // 
            // nudTransferAmount
            // 
            nudTransferAmount.DecimalPlaces = 2;
            nudTransferAmount.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nudTransferAmount.Location = new Point(51, 48);
            nudTransferAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudTransferAmount.Name = "nudTransferAmount";
            nudTransferAmount.Size = new Size(127, 23);
            nudTransferAmount.TabIndex = 3;
            nudTransferAmount.ThousandsSeparator = true;
            // 
            // btnTransfer
            // 
            btnTransfer.Location = new Point(5, 106);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(172, 29);
            btnTransfer.TabIndex = 5;
            btnTransfer.Text = "Переказати кошти";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // tbTransferComment
            // 
            tbTransferComment.Location = new Point(6, 77);
            tbTransferComment.Name = "tbTransferComment";
            tbTransferComment.PlaceholderText = "Коментар (необов'язково)";
            tbTransferComment.Size = new Size(172, 23);
            tbTransferComment.TabIndex = 4;
            // 
            // lblBalance
            // 
            lblBalance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblBalance.Location = new Point(195, 19);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(303, 23);
            lblBalance.TabIndex = 4;
            lblBalance.Text = "Баланс: 0₴";
            lblBalance.TextAlign = ContentAlignment.TopCenter;
            // 
            // gbSearchTransactions
            // 
            gbSearchTransactions.Controls.Add(dtpSearchEnd);
            gbSearchTransactions.Controls.Add(dtpSearchStart);
            gbSearchTransactions.Controls.Add(lblSearch);
            gbSearchTransactions.Controls.Add(tbSearch);
            gbSearchTransactions.Controls.Add(cbSearch);
            gbSearchTransactions.Location = new Point(195, 81);
            gbSearchTransactions.Name = "gbSearchTransactions";
            gbSearchTransactions.Size = new Size(303, 101);
            gbSearchTransactions.TabIndex = 18;
            gbSearchTransactions.TabStop = false;
            // 
            // dtpSearchEnd
            // 
            dtpSearchEnd.Checked = false;
            dtpSearchEnd.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpSearchEnd.Format = DateTimePickerFormat.Custom;
            dtpSearchEnd.Location = new Point(6, 67);
            dtpSearchEnd.Name = "dtpSearchEnd";
            dtpSearchEnd.ShowCheckBox = true;
            dtpSearchEnd.Size = new Size(146, 23);
            dtpSearchEnd.TabIndex = 9;
            dtpSearchEnd.ValueChanged += transactionSearch;
            // 
            // dtpSearchStart
            // 
            dtpSearchStart.Checked = false;
            dtpSearchStart.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpSearchStart.Format = DateTimePickerFormat.Custom;
            dtpSearchStart.Location = new Point(6, 38);
            dtpSearchStart.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dtpSearchStart.Name = "dtpSearchStart";
            dtpSearchStart.ShowCheckBox = true;
            dtpSearchStart.Size = new Size(146, 23);
            dtpSearchStart.TabIndex = 8;
            dtpSearchStart.ValueChanged += transactionSearch;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(97, 19);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(108, 15);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Пошук по таблиці";
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(158, 67);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Контрагент або Опис";
            tbSearch.Size = new Size(139, 23);
            tbSearch.TabIndex = 11;
            tbSearch.TextChanged += transactionSearch;
            // 
            // cbSearch
            // 
            cbSearch.FormattingEnabled = true;
            cbSearch.ItemHeight = 15;
            cbSearch.Location = new Point(158, 38);
            cbSearch.Name = "cbSearch";
            cbSearch.Size = new Size(139, 23);
            cbSearch.TabIndex = 0;
            cbSearch.SelectedIndexChanged += transactionSearch;
            // 
            // gbSearchBusinessCards
            // 
            gbSearchBusinessCards.Controls.Add(cbSearchBusinessCardsOnlyExpired);
            gbSearchBusinessCards.Controls.Add(cbSearchBusinessCardsOnlyUnexpired);
            gbSearchBusinessCards.Controls.Add(lblHeaderSearchBusinessCards);
            gbSearchBusinessCards.Controls.Add(tbSearchBusinessCards);
            gbSearchBusinessCards.Location = new Point(195, 81);
            gbSearchBusinessCards.Name = "gbSearchBusinessCards";
            gbSearchBusinessCards.Size = new Size(303, 101);
            gbSearchBusinessCards.TabIndex = 19;
            gbSearchBusinessCards.TabStop = false;
            // 
            // cbSearchBusinessCardsOnlyExpired
            // 
            cbSearchBusinessCardsOnlyExpired.AutoSize = true;
            cbSearchBusinessCardsOnlyExpired.Location = new Point(164, 69);
            cbSearchBusinessCardsOnlyExpired.Name = "cbSearchBusinessCardsOnlyExpired";
            cbSearchBusinessCardsOnlyExpired.Size = new Size(133, 19);
            cbSearchBusinessCardsOnlyExpired.TabIndex = 10;
            cbSearchBusinessCardsOnlyExpired.Text = "Тільки прострочені";
            cbSearchBusinessCardsOnlyExpired.UseVisualStyleBackColor = true;
            cbSearchBusinessCardsOnlyExpired.CheckedChanged += cbSearchBusinessCardsOnlyExpired_CheckedChanged;
            // 
            // cbSearchBusinessCardsOnlyUnexpired
            // 
            cbSearchBusinessCardsOnlyUnexpired.AutoSize = true;
            cbSearchBusinessCardsOnlyUnexpired.Location = new Point(6, 69);
            cbSearchBusinessCardsOnlyUnexpired.Name = "cbSearchBusinessCardsOnlyUnexpired";
            cbSearchBusinessCardsOnlyUnexpired.Size = new Size(96, 19);
            cbSearchBusinessCardsOnlyUnexpired.TabIndex = 9;
            cbSearchBusinessCardsOnlyUnexpired.Text = "Тільки дійсні";
            cbSearchBusinessCardsOnlyUnexpired.UseVisualStyleBackColor = true;
            cbSearchBusinessCardsOnlyUnexpired.CheckedChanged += cbSearchBusinessCardsOnlyUnexpired_CheckedChanged;
            // 
            // lblHeaderSearchBusinessCards
            // 
            lblHeaderSearchBusinessCards.AutoSize = true;
            lblHeaderSearchBusinessCards.Location = new Point(97, 19);
            lblHeaderSearchBusinessCards.Name = "lblHeaderSearchBusinessCards";
            lblHeaderSearchBusinessCards.Size = new Size(108, 15);
            lblHeaderSearchBusinessCards.TabIndex = 2;
            lblHeaderSearchBusinessCards.Text = "Пошук по таблиці";
            // 
            // tbSearchBusinessCards
            // 
            tbSearchBusinessCards.Location = new Point(6, 38);
            tbSearchBusinessCards.Name = "tbSearchBusinessCards";
            tbSearchBusinessCards.PlaceholderText = "Номер картки або ФІО власника";
            tbSearchBusinessCards.Size = new Size(291, 23);
            tbSearchBusinessCards.TabIndex = 8;
            tbSearchBusinessCards.TextChanged += businessSearch;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.AllowUserToResizeRows = false;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Columns.AddRange(new DataGridViewColumn[] { NumberColumn, DateTimeColumn, TypeColumn, AmountColumn, TargetColumn, DescriptionColumn, ReceiptColumn });
            dgvTransactions.Location = new Point(0, 188);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.Size = new Size(660, 166);
            dgvTransactions.TabIndex = 16;
            dgvTransactions.CellClick += dgvTransactions_CellClick;
            // 
            // NumberColumn
            // 
            NumberColumn.HeaderText = "Номер";
            NumberColumn.Name = "NumberColumn";
            NumberColumn.ReadOnly = true;
            NumberColumn.Visible = false;
            // 
            // DateTimeColumn
            // 
            DateTimeColumn.HeaderText = "Дата";
            DateTimeColumn.Name = "DateTimeColumn";
            DateTimeColumn.ReadOnly = true;
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
            AmountColumn.Width = 60;
            // 
            // TargetColumn
            // 
            TargetColumn.HeaderText = "Контрагент";
            TargetColumn.Name = "TargetColumn";
            TargetColumn.ReadOnly = true;
            TargetColumn.Width = 135;
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
            ReceiptColumn.Text = "Зберегти";
            ReceiptColumn.UseColumnTextForButtonValue = true;
            ReceiptColumn.Width = 75;
            // 
            // dgvBusinessCards
            // 
            dgvBusinessCards.AllowUserToAddRows = false;
            dgvBusinessCards.AllowUserToDeleteRows = false;
            dgvBusinessCards.AllowUserToResizeRows = false;
            dgvBusinessCards.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBusinessCards.Columns.AddRange(new DataGridViewColumn[] { CardNumberColumn, OwnerFullNameColumn, CardExpireDateColumn, CVVColumn, RenewCardColumn });
            dgvBusinessCards.Location = new Point(0, 188);
            dgvBusinessCards.Name = "dgvBusinessCards";
            dgvBusinessCards.ReadOnly = true;
            dgvBusinessCards.RowHeadersVisible = false;
            dgvBusinessCards.Size = new Size(660, 166);
            dgvBusinessCards.TabIndex = 17;
            dgvBusinessCards.CellClick += dgvBusinessCards_CellClick;
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
            RenewCardColumn.Text = "Перевипустити";
            RenewCardColumn.UseColumnTextForButtonValue = true;
            RenewCardColumn.Width = 122;
            // 
            // gbPersonalAccountControl
            // 
            gbPersonalAccountControl.Controls.Add(lblIBAN);
            gbPersonalAccountControl.Controls.Add(tbIBAN);
            gbPersonalAccountControl.Controls.Add(tbCardNumber);
            gbPersonalAccountControl.Controls.Add(lblCVV);
            gbPersonalAccountControl.Controls.Add(lblExpireDate);
            gbPersonalAccountControl.Controls.Add(btnRenewCard);
            gbPersonalAccountControl.Location = new Point(504, 0);
            gbPersonalAccountControl.Name = "gbPersonalAccountControl";
            gbPersonalAccountControl.Size = new Size(156, 183);
            gbPersonalAccountControl.TabIndex = 1;
            gbPersonalAccountControl.TabStop = false;
            // 
            // lblIBAN
            // 
            lblIBAN.AutoSize = true;
            lblIBAN.Location = new Point(60, 86);
            lblIBAN.Name = "lblIBAN";
            lblIBAN.Size = new Size(37, 15);
            lblIBAN.TabIndex = 14;
            lblIBAN.Text = "IBAN:";
            // 
            // tbIBAN
            // 
            tbIBAN.Location = new Point(6, 111);
            tbIBAN.Name = "tbIBAN";
            tbIBAN.ReadOnly = true;
            tbIBAN.Size = new Size(144, 23);
            tbIBAN.TabIndex = 13;
            // 
            // tbCardNumber
            // 
            tbCardNumber.Location = new Point(6, 27);
            tbCardNumber.Name = "tbCardNumber";
            tbCardNumber.ReadOnly = true;
            tbCardNumber.Size = new Size(144, 23);
            tbCardNumber.TabIndex = 12;
            // 
            // lblCVV
            // 
            lblCVV.AutoSize = true;
            lblCVV.Location = new Point(125, 63);
            lblCVV.Name = "lblCVV";
            lblCVV.Size = new Size(25, 15);
            lblCVV.TabIndex = 10;
            lblCVV.Text = "000";
            // 
            // lblExpireDate
            // 
            lblExpireDate.AutoSize = true;
            lblExpireDate.Location = new Point(6, 63);
            lblExpireDate.Name = "lblExpireDate";
            lblExpireDate.Size = new Size(36, 15);
            lblExpireDate.TabIndex = 11;
            lblExpireDate.Text = "00/00";
            // 
            // btnRenewCard
            // 
            btnRenewCard.Location = new Point(6, 144);
            btnRenewCard.Name = "btnRenewCard";
            btnRenewCard.Size = new Size(144, 29);
            btnRenewCard.TabIndex = 14;
            btnRenewCard.Text = "Перевипустити картку";
            btnRenewCard.UseVisualStyleBackColor = true;
            btnRenewCard.Click += btnRenewCard_Click;
            // 
            // gbBusinessAccountControl
            // 
            gbBusinessAccountControl.Controls.Add(btnChangeTable);
            gbBusinessAccountControl.Controls.Add(cbBusinessPaymentSystem);
            gbBusinessAccountControl.Controls.Add(tbBusinessFullName);
            gbBusinessAccountControl.Controls.Add(lblPaymentSystem);
            gbBusinessAccountControl.Controls.Add(lblBusinessFullName);
            gbBusinessAccountControl.Controls.Add(btnOpenCard);
            gbBusinessAccountControl.Location = new Point(504, 0);
            gbBusinessAccountControl.Name = "gbBusinessAccountControl";
            gbBusinessAccountControl.Size = new Size(156, 182);
            gbBusinessAccountControl.TabIndex = 0;
            gbBusinessAccountControl.TabStop = false;
            gbBusinessAccountControl.Text = "Бізнес картки";
            // 
            // btnChangeTable
            // 
            btnChangeTable.Location = new Point(6, 147);
            btnChangeTable.Name = "btnChangeTable";
            btnChangeTable.Size = new Size(144, 29);
            btnChangeTable.TabIndex = 15;
            btnChangeTable.Text = "Змінити таблицю";
            btnChangeTable.UseVisualStyleBackColor = true;
            btnChangeTable.Click += btnChangeTable_Click;
            // 
            // cbBusinessPaymentSystem
            // 
            cbBusinessPaymentSystem.FormattingEnabled = true;
            cbBusinessPaymentSystem.ItemHeight = 15;
            cbBusinessPaymentSystem.Location = new Point(6, 82);
            cbBusinessPaymentSystem.Name = "cbBusinessPaymentSystem";
            cbBusinessPaymentSystem.Size = new Size(144, 23);
            cbBusinessPaymentSystem.TabIndex = 13;
            // 
            // tbBusinessFullName
            // 
            tbBusinessFullName.Location = new Point(6, 37);
            tbBusinessFullName.Name = "tbBusinessFullName";
            tbBusinessFullName.Size = new Size(144, 23);
            tbBusinessFullName.TabIndex = 12;
            // 
            // lblPaymentSystem
            // 
            lblPaymentSystem.AutoSize = true;
            lblPaymentSystem.Location = new Point(23, 63);
            lblPaymentSystem.Name = "lblPaymentSystem";
            lblPaymentSystem.Size = new Size(110, 15);
            lblPaymentSystem.TabIndex = 11;
            lblPaymentSystem.Text = "Платіжна система:";
            // 
            // lblBusinessFullName
            // 
            lblBusinessFullName.AutoSize = true;
            lblBusinessFullName.Location = new Point(36, 19);
            lblBusinessFullName.Name = "lblBusinessFullName";
            lblBusinessFullName.Size = new Size(83, 15);
            lblBusinessFullName.TabIndex = 10;
            lblBusinessFullName.Text = "ПІБ власника:";
            // 
            // btnOpenCard
            // 
            btnOpenCard.Location = new Point(6, 110);
            btnOpenCard.Name = "btnOpenCard";
            btnOpenCard.Size = new Size(144, 29);
            btnOpenCard.TabIndex = 14;
            btnOpenCard.Text = "Випустити нову картку";
            btnOpenCard.UseVisualStyleBackColor = true;
            btnOpenCard.Click += btnOpenCard_Click;
            // 
            // btnSubscribePremium
            // 
            btnSubscribePremium.Location = new Point(195, 51);
            btnSubscribePremium.Name = "btnSubscribePremium";
            btnSubscribePremium.Size = new Size(175, 29);
            btnSubscribePremium.TabIndex = 7;
            btnSubscribePremium.Text = "Підписатися на преміум";
            btnSubscribePremium.UseVisualStyleBackColor = true;
            btnSubscribePremium.Click += btnSubscribePremium_Click;
            // 
            // btnUnsubscribePremium
            // 
            btnUnsubscribePremium.Location = new Point(195, 51);
            btnUnsubscribePremium.Name = "btnUnsubscribePremium";
            btnUnsubscribePremium.Size = new Size(175, 29);
            btnUnsubscribePremium.TabIndex = 19;
            btnUnsubscribePremium.Text = "Відписатися від преміуму";
            btnUnsubscribePremium.UseVisualStyleBackColor = true;
            btnUnsubscribePremium.Click += btnUnsubscribePremium_Click;
            // 
            // btnOpenDeposit
            // 
            btnOpenDeposit.Location = new Point(376, 51);
            btnOpenDeposit.Name = "btnOpenDeposit";
            btnOpenDeposit.Size = new Size(122, 29);
            btnOpenDeposit.TabIndex = 20;
            btnOpenDeposit.Text = "Відкрити депозит";
            btnOpenDeposit.UseVisualStyleBackColor = true;
            btnOpenDeposit.Click += btnOpenDeposit_Click;
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
            gbAccountBlocked.Visible = false;
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
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(684, 461);
            Controls.Add(lblSelectAccount);
            Controls.Add(cbAccount);
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
            Text = "Кабінет";
            FormClosing += MenuForm_FormClosing;
            VisibleChanged += MenuForm_VisibleChanged;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUser).EndInit();
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            gbAccountControl.ResumeLayout(false);
            gbTransfer.ResumeLayout(false);
            gbTransfer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTransferAmount).EndInit();
            gbSearchTransactions.ResumeLayout(false);
            gbSearchTransactions.PerformLayout();
            gbSearchBusinessCards.ResumeLayout(false);
            gbSearchBusinessCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBusinessCards).EndInit();
            gbPersonalAccountControl.ResumeLayout(false);
            gbPersonalAccountControl.PerformLayout();
            gbBusinessAccountControl.ResumeLayout(false);
            gbBusinessAccountControl.PerformLayout();
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
        private ComboBox cbAccount;
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
        private Label lblExpireDate;
        private Label lblCVV;
        private Button btnOpenCard;
        private Button btnTransfer;
        private Button btnRenewCard;
        private Button btnSubscribePremium;
        private TextBox tbTransferComment;
        private Label lblTransferAmount;
        private Label lblTransferTarget;
        private GroupBox gbTransfer;
        private DataGridView dgvBusinessCards;
        private ComboBox cbBusinessPaymentSystem;
        private TextBox tbBusinessFullName;
        private Label lblPaymentSystem;
        private Label lblBusinessFullName;
        private Button btnChangeTable;
        private GroupBox gbSearchTransactions;
        private Label lblSearch;
        private TextBox tbSearch;
        private ComboBox cbSearch;
        private TextBox tbCardNumber;
        private Label lblIBAN;
        private TextBox tbIBAN;
        private Button btnPayment;
        private Button btnUnsubscribePremium;
        private GroupBox gbSearchBusinessCards;
        private Label lblHeaderSearchBusinessCards;
        private TextBox tbSearchBusinessCards;
        private DataGridViewTextBoxColumn CardNumberColumn;
        private DataGridViewTextBoxColumn OwnerFullNameColumn;
        private DataGridViewTextBoxColumn CardExpireDateColumn;
        private DataGridViewTextBoxColumn CVVColumn;
        private DataGridViewButtonColumn RenewCardColumn;
        private DateTimePicker dtpSearchStart;
        private DateTimePicker dtpSearchEnd;
        private CheckBox cbSearchBusinessCardsOnlyExpired;
        private CheckBox cbSearchBusinessCardsOnlyUnexpired;
        private DataGridViewTextBoxColumn NumberColumn;
        private DataGridViewTextBoxColumn DateTimeColumn;
        private DataGridViewTextBoxColumn TypeColumn;
        private DataGridViewTextBoxColumn AmountColumn;
        private DataGridViewTextBoxColumn TargetColumn;
        private DataGridViewTextBoxColumn DescriptionColumn;
        private DataGridViewButtonColumn ReceiptColumn;
        private Button btnOpenDeposit;
    }
}
