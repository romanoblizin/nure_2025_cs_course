namespace Course.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panelHeader = new Panel();
            lblTime = new Label();
            panelUser = new Panel();
            pbUser = new PictureBox();
            lblUser = new Label();
            panelLogo = new Panel();
            lblLogo = new Label();
            pbLogo = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            lblLogin = new Label();
            tbLogin = new TextBox();
            lblPassword = new Label();
            tbPassword = new TextBox();
            gbLogin = new GroupBox();
            lblRegister = new Label();
            btnToRegister = new Button();
            btnLogIn = new Button();
            gbRegistration = new GroupBox();
            label1 = new Label();
            lblEmail = new Label();
            lblPatronymic = new Label();
            btnToLogIn = new Button();
            tbPatronymic = new TextBox();
            tbSurname = new TextBox();
            tbPhone = new TextBox();
            tbEmail = new TextBox();
            lblName = new Label();
            lblSurname = new Label();
            btnRegister = new Button();
            lblPhone = new Label();
            tbPasswordR = new TextBox();
            tbName = new TextBox();
            lblPasswordR = new Label();
            panelHeader.SuspendLayout();
            panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUser).BeginInit();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            gbLogin.SuspendLayout();
            gbRegistration.SuspendLayout();
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
            pbUser.Location = new Point(160, 0);
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
            lblUser.Location = new Point(0, 15);
            lblUser.Name = "lblUser";
            lblUser.RightToLeft = RightToLeft.No;
            lblUser.Size = new Size(162, 21);
            lblUser.TabIndex = 2;
            lblUser.Text = "Увійдіть до аккаунту";
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
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblLogin.ForeColor = SystemColors.Desktop;
            lblLogin.Location = new Point(24, 48);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(168, 15);
            lblLogin.TabIndex = 2;
            lblLogin.Text = "Номер телефону або пошта:";
            // 
            // tbLogin
            // 
            tbLogin.Location = new Point(209, 45);
            tbLogin.Name = "tbLogin";
            tbLogin.Size = new Size(150, 23);
            tbLogin.TabIndex = 0;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(140, 89);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(52, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Пароль:";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(209, 86);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(150, 23);
            tbPassword.TabIndex = 1;
            // 
            // gbLogin
            // 
            gbLogin.Controls.Add(lblRegister);
            gbLogin.Controls.Add(btnToRegister);
            gbLogin.Controls.Add(btnLogIn);
            gbLogin.Controls.Add(lblLogin);
            gbLogin.Controls.Add(tbPassword);
            gbLogin.Controls.Add(tbLogin);
            gbLogin.Controls.Add(lblPassword);
            gbLogin.Location = new Point(138, 89);
            gbLogin.Name = "gbLogin";
            gbLogin.Size = new Size(408, 302);
            gbLogin.TabIndex = 6;
            gbLogin.TabStop = false;
            gbLogin.Text = "Логін";
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Location = new Point(160, 275);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(118, 15);
            lblRegister.TabIndex = 5;
            lblRegister.Text = "Ще немає аккаунту?";
            // 
            // btnToRegister
            // 
            btnToRegister.BackColor = SystemColors.ActiveCaption;
            btnToRegister.FlatStyle = FlatStyle.Popup;
            btnToRegister.Location = new Point(284, 268);
            btnToRegister.Name = "btnToRegister";
            btnToRegister.Size = new Size(118, 28);
            btnToRegister.TabIndex = 3;
            btnToRegister.Text = "Зареєструватися";
            btnToRegister.UseVisualStyleBackColor = false;
            btnToRegister.Click += btnToRegister_Click;
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = SystemColors.ButtonHighlight;
            btnLogIn.FlatStyle = FlatStyle.Popup;
            btnLogIn.Location = new Point(145, 138);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(118, 28);
            btnLogIn.TabIndex = 2;
            btnLogIn.Text = "Увійти";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // gbRegistration
            // 
            gbRegistration.Controls.Add(label1);
            gbRegistration.Controls.Add(lblEmail);
            gbRegistration.Controls.Add(lblPatronymic);
            gbRegistration.Controls.Add(btnToLogIn);
            gbRegistration.Controls.Add(tbPatronymic);
            gbRegistration.Controls.Add(tbSurname);
            gbRegistration.Controls.Add(tbPhone);
            gbRegistration.Controls.Add(tbEmail);
            gbRegistration.Controls.Add(lblName);
            gbRegistration.Controls.Add(lblSurname);
            gbRegistration.Controls.Add(btnRegister);
            gbRegistration.Controls.Add(lblPhone);
            gbRegistration.Controls.Add(tbPasswordR);
            gbRegistration.Controls.Add(tbName);
            gbRegistration.Controls.Add(lblPasswordR);
            gbRegistration.Location = new Point(138, 89);
            gbRegistration.Name = "gbRegistration";
            gbRegistration.Size = new Size(408, 302);
            gbRegistration.TabIndex = 9;
            gbRegistration.TabStop = false;
            gbRegistration.Text = "Реєстрація";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(190, 275);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 17;
            label1.Text = "Вже є аккаунт?";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(79, 135);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(113, 15);
            lblEmail.TabIndex = 16;
            lblEmail.Text = "Електронна пошта:";
            // 
            // lblPatronymic
            // 
            lblPatronymic.AutoSize = true;
            lblPatronymic.Location = new Point(115, 106);
            lblPatronymic.Name = "lblPatronymic";
            lblPatronymic.Size = new Size(77, 15);
            lblPatronymic.TabIndex = 15;
            lblPatronymic.Text = "По-батькові:";
            // 
            // btnToLogIn
            // 
            btnToLogIn.BackColor = SystemColors.ActiveCaption;
            btnToLogIn.FlatStyle = FlatStyle.Flat;
            btnToLogIn.Location = new Point(284, 268);
            btnToLogIn.Name = "btnToLogIn";
            btnToLogIn.Size = new Size(118, 28);
            btnToLogIn.TabIndex = 11;
            btnToLogIn.Text = "Увійти";
            btnToLogIn.UseVisualStyleBackColor = false;
            btnToLogIn.Click += btnToLogIn_Click;
            // 
            // tbPatronymic
            // 
            tbPatronymic.Location = new Point(209, 103);
            tbPatronymic.Name = "tbPatronymic";
            tbPatronymic.PlaceholderText = "Необов'язково";
            tbPatronymic.Size = new Size(150, 23);
            tbPatronymic.TabIndex = 6;
            // 
            // tbSurname
            // 
            tbSurname.Location = new Point(209, 45);
            tbSurname.Name = "tbSurname";
            tbSurname.Size = new Size(150, 23);
            tbSurname.TabIndex = 4;
            // 
            // tbPhone
            // 
            tbPhone.Location = new Point(209, 161);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(150, 23);
            tbPhone.TabIndex = 8;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(209, 132);
            tbEmail.Name = "tbEmail";
            tbEmail.PlaceholderText = "Необов'язково";
            tbEmail.Size = new Size(150, 23);
            tbEmail.TabIndex = 7;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(161, 77);
            lblName.Name = "lblName";
            lblName.Size = new Size(31, 15);
            lblName.TabIndex = 10;
            lblName.Text = "Ім'я:";
            // 
            // lblSurname
            // 
            lblSurname.AutoSize = true;
            lblSurname.Location = new Point(128, 48);
            lblSurname.Name = "lblSurname";
            lblSurname.Size = new Size(64, 15);
            lblSurname.TabIndex = 9;
            lblSurname.Text = "Прізвище:";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = SystemColors.ButtonHighlight;
            btnRegister.FlatStyle = FlatStyle.Popup;
            btnRegister.Location = new Point(145, 232);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(118, 28);
            btnRegister.TabIndex = 10;
            btnRegister.Text = "Зареєструватися";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPhone.ForeColor = SystemColors.Desktop;
            lblPhone.Location = new Point(86, 164);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(106, 15);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Номер телефону:";
            // 
            // tbPasswordR
            // 
            tbPasswordR.Location = new Point(209, 190);
            tbPasswordR.Name = "tbPasswordR";
            tbPasswordR.PasswordChar = '*';
            tbPasswordR.Size = new Size(150, 23);
            tbPasswordR.TabIndex = 9;
            // 
            // tbName
            // 
            tbName.Location = new Point(209, 74);
            tbName.Name = "tbName";
            tbName.Size = new Size(150, 23);
            tbName.TabIndex = 5;
            // 
            // lblPasswordR
            // 
            lblPasswordR.AutoSize = true;
            lblPasswordR.Location = new Point(140, 193);
            lblPasswordR.Name = "lblPasswordR";
            lblPasswordR.Size = new Size(52, 15);
            lblPasswordR.TabIndex = 4;
            lblPasswordR.Text = "Пароль:";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(684, 461);
            Controls.Add(panelHeader);
            Controls.Add(gbLogin);
            Controls.Add(gbRegistration);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(700, 500);
            MinimumSize = new Size(700, 500);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизація";
            FormClosing += LoginForm_FormClosing;
            Load += LoginForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUser).EndInit();
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            gbLogin.ResumeLayout(false);
            gbLogin.PerformLayout();
            gbRegistration.ResumeLayout(false);
            gbRegistration.PerformLayout();
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
        private Label lblLogin;
        private TextBox tbLogin;
        private Label lblPassword;
        private TextBox tbPassword;
        private GroupBox gbLogin;
        private Button btnLogIn;
        private Button btnToRegister;
        private GroupBox gbRegistration;
        private TextBox tbPatronymic;
        private TextBox tbSurname;
        private TextBox tbPhone;
        private TextBox tbEmail;
        private Label lblName;
        private Label lblSurname;
        private Button btnRegister;
        private Button btnToLogIn;
        private Label lblPhone;
        private TextBox tbPasswordR;
        private TextBox tbName;
        private Label lblPasswordR;
        private Label lblEmail;
        private Label lblPatronymic;
        private Label lblRegister;
        private Label label1;
    }
}