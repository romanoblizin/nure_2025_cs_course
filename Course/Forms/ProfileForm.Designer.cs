namespace Course.Forms
{
    partial class ProfileForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            panelHeader = new Panel();
            lblTime = new Label();
            panelUser = new Panel();
            pbUser = new PictureBox();
            lblUser = new Label();
            panelLogo = new Panel();
            lblLogo = new Label();
            pbLogo = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            gbPersonalData = new GroupBox();
            btnSave = new Button();
            tbPassword = new TextBox();
            tbPhone = new TextBox();
            tbName = new TextBox();
            tbEmail = new TextBox();
            tbPatronymic = new TextBox();
            tbSurname = new TextBox();
            lblPassword = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            lblPatronymic = new Label();
            lblName = new Label();
            lblSurname = new Label();
            btnOpenDebitAccount = new Button();
            gbOpenAccounts = new GroupBox();
            lblCashback = new Label();
            btnGetCashback = new Button();
            btnOpenBusinessAccount = new Button();
            btnOpenPayoutAccount = new Button();
            btnOpenCreditAccount = new Button();
            btnLogOut = new Button();
            panelHeader.SuspendLayout();
            panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUser).BeginInit();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            gbPersonalData.SuspendLayout();
            gbOpenAccounts.SuspendLayout();
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
            panelHeader.TabIndex = 1;
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
            // 
            // panelUser
            // 
            panelUser.Controls.Add(pbUser);
            panelUser.Controls.Add(lblUser);
            panelUser.Location = new Point(465, 0);
            panelUser.Name = "panelUser";
            panelUser.Size = new Size(216, 50);
            panelUser.TabIndex = 3;
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
            panelLogo.Click += panelLogo_Click;
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
            lblLogo.Click += panelLogo_Click;
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
            pbLogo.Click += panelLogo_Click;
            pbLogo.MouseHover += panelLogo_MouseHover;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // gbPersonalData
            // 
            gbPersonalData.Controls.Add(btnSave);
            gbPersonalData.Controls.Add(tbPassword);
            gbPersonalData.Controls.Add(tbPhone);
            gbPersonalData.Controls.Add(tbName);
            gbPersonalData.Controls.Add(tbEmail);
            gbPersonalData.Controls.Add(tbPatronymic);
            gbPersonalData.Controls.Add(tbSurname);
            gbPersonalData.Controls.Add(lblPassword);
            gbPersonalData.Controls.Add(lblPhone);
            gbPersonalData.Controls.Add(lblEmail);
            gbPersonalData.Controls.Add(lblPatronymic);
            gbPersonalData.Controls.Add(lblName);
            gbPersonalData.Controls.Add(lblSurname);
            gbPersonalData.Location = new Point(12, 66);
            gbPersonalData.Name = "gbPersonalData";
            gbPersonalData.Size = new Size(286, 317);
            gbPersonalData.TabIndex = 2;
            gbPersonalData.TabStop = false;
            gbPersonalData.Text = "Персональні дані";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ButtonHighlight;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Location = new Point(18, 260);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(256, 35);
            btnSave.TabIndex = 12;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(128, 213);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(146, 23);
            tbPassword.TabIndex = 11;
            // 
            // tbPhone
            // 
            tbPhone.Location = new Point(128, 177);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(146, 23);
            tbPhone.TabIndex = 10;
            // 
            // tbName
            // 
            tbName.Location = new Point(128, 69);
            tbName.Name = "tbName";
            tbName.Size = new Size(146, 23);
            tbName.TabIndex = 9;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(128, 141);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(146, 23);
            tbEmail.TabIndex = 8;
            // 
            // tbPatronymic
            // 
            tbPatronymic.Location = new Point(128, 105);
            tbPatronymic.Name = "tbPatronymic";
            tbPatronymic.Size = new Size(146, 23);
            tbPatronymic.TabIndex = 7;
            // 
            // tbSurname
            // 
            tbSurname.Location = new Point(128, 33);
            tbSurname.Name = "tbSurname";
            tbSurname.Size = new Size(146, 23);
            tbSurname.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(70, 216);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(52, 15);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Пароль:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(18, 180);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(104, 15);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Номер телефону:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(9, 144);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(113, 15);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Електронна пошта:";
            // 
            // lblPatronymic
            // 
            lblPatronymic.AutoSize = true;
            lblPatronymic.Location = new Point(45, 108);
            lblPatronymic.Name = "lblPatronymic";
            lblPatronymic.Size = new Size(77, 15);
            lblPatronymic.TabIndex = 2;
            lblPatronymic.Text = "По-батькові:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(91, 72);
            lblName.Name = "lblName";
            lblName.Size = new Size(31, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Ім'я:";
            // 
            // lblSurname
            // 
            lblSurname.AutoSize = true;
            lblSurname.Location = new Point(58, 36);
            lblSurname.Name = "lblSurname";
            lblSurname.Size = new Size(64, 15);
            lblSurname.TabIndex = 0;
            lblSurname.Text = "Прізвище:";
            // 
            // btnOpenDebitAccount
            // 
            btnOpenDebitAccount.Location = new Point(55, 37);
            btnOpenDebitAccount.Name = "btnOpenDebitAccount";
            btnOpenDebitAccount.Size = new Size(221, 35);
            btnOpenDebitAccount.TabIndex = 3;
            btnOpenDebitAccount.Text = "Відкрити дебетову картку";
            btnOpenDebitAccount.UseVisualStyleBackColor = true;
            btnOpenDebitAccount.Click += btnOpenDebitAccount_Click;
            // 
            // gbOpenAccounts
            // 
            gbOpenAccounts.Controls.Add(lblCashback);
            gbOpenAccounts.Controls.Add(btnGetCashback);
            gbOpenAccounts.Controls.Add(btnOpenBusinessAccount);
            gbOpenAccounts.Controls.Add(btnOpenPayoutAccount);
            gbOpenAccounts.Controls.Add(btnOpenCreditAccount);
            gbOpenAccounts.Controls.Add(btnOpenDebitAccount);
            gbOpenAccounts.Location = new Point(348, 66);
            gbOpenAccounts.Name = "gbOpenAccounts";
            gbOpenAccounts.Size = new Size(330, 317);
            gbOpenAccounts.TabIndex = 4;
            gbOpenAccounts.TabStop = false;
            gbOpenAccounts.Text = "Операції";
            // 
            // lblCashback
            // 
            lblCashback.AutoSize = true;
            lblCashback.Location = new Point(147, 284);
            lblCashback.Name = "lblCashback";
            lblCashback.Size = new Size(37, 15);
            lblCashback.TabIndex = 4;
            lblCashback.Text = "0.00 ₴";
            // 
            // btnGetCashback
            // 
            btnGetCashback.Location = new Point(55, 241);
            btnGetCashback.Name = "btnGetCashback";
            btnGetCashback.Size = new Size(221, 35);
            btnGetCashback.TabIndex = 3;
            btnGetCashback.Text = "Отримати зароблений кешбек";
            btnGetCashback.UseVisualStyleBackColor = true;
            btnGetCashback.Click += btnGetCashback_Click;
            // 
            // btnOpenBusinessAccount
            // 
            btnOpenBusinessAccount.Location = new Point(55, 190);
            btnOpenBusinessAccount.Name = "btnOpenBusinessAccount";
            btnOpenBusinessAccount.Size = new Size(221, 35);
            btnOpenBusinessAccount.TabIndex = 3;
            btnOpenBusinessAccount.Text = "Відкрити корпоративний рахунок";
            btnOpenBusinessAccount.UseVisualStyleBackColor = true;
            btnOpenBusinessAccount.Click += btnOpenBusinessAccount_Click;
            // 
            // btnOpenPayoutAccount
            // 
            btnOpenPayoutAccount.Location = new Point(55, 139);
            btnOpenPayoutAccount.Name = "btnOpenPayoutAccount";
            btnOpenPayoutAccount.Size = new Size(221, 35);
            btnOpenPayoutAccount.TabIndex = 3;
            btnOpenPayoutAccount.Text = "Відкрити картку для виплат";
            btnOpenPayoutAccount.UseVisualStyleBackColor = true;
            btnOpenPayoutAccount.Click += btnOpenPayoutAccount_Click;
            // 
            // btnOpenCreditAccount
            // 
            btnOpenCreditAccount.Location = new Point(55, 88);
            btnOpenCreditAccount.Name = "btnOpenCreditAccount";
            btnOpenCreditAccount.Size = new Size(221, 35);
            btnOpenCreditAccount.TabIndex = 3;
            btnOpenCreditAccount.Text = "Відкрити кредитну картку";
            btnOpenCreditAccount.UseVisualStyleBackColor = true;
            btnOpenCreditAccount.Click += btnOpenCreditAccount_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.IndianRed;
            btnLogOut.FlatStyle = FlatStyle.Popup;
            btnLogOut.Location = new Point(12, 405);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(666, 35);
            btnLogOut.TabIndex = 5;
            btnLogOut.Text = "Вийти з акаунту";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(684, 461);
            Controls.Add(btnLogOut);
            Controls.Add(gbOpenAccounts);
            Controls.Add(gbPersonalData);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(700, 500);
            MinimumSize = new Size(700, 500);
            Name = "ProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Профіль";
            FormClosing += ProfileForm_FormClosing;
            VisibleChanged += ProfileForm_VisibleChanged;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUser).EndInit();
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            gbPersonalData.ResumeLayout(false);
            gbPersonalData.PerformLayout();
            gbOpenAccounts.ResumeLayout(false);
            gbOpenAccounts.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTime;
        private Panel panelUser;
        private PictureBox pbUser;
        private Label lblUser;
        private Panel panelLogo;
        private Label lblLogo;
        private PictureBox pbLogo;
        private System.Windows.Forms.Timer timer;
        private GroupBox gbPersonalData;
        private TextBox tbPassword;
        private TextBox tbPhone;
        private TextBox tbName;
        private TextBox tbEmail;
        private TextBox tbPatronymic;
        private TextBox tbSurname;
        private Label lblPassword;
        private Label lblPhone;
        private Label lblEmail;
        private Label lblPatronymic;
        private Label lblName;
        private Label lblSurname;
        private Button btnSave;
        private Button btnOpenDebitAccount;
        private GroupBox gbOpenAccounts;
        private Button btnOpenBusinessAccount;
        private Button btnOpenPayoutAccount;
        private Button btnOpenCreditAccount;
        private Button btnGetCashback;
        private Label lblCashback;
        private Button btnLogOut;
    }
}