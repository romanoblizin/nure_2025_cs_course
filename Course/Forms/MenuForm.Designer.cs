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
            panelHeader.SuspendLayout();
            panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUser).BeginInit();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
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
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(684, 461);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(700, 500);
            MinimumSize = new Size(700, 500);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Банк";
            FormClosing += MenuForm_FormClosing;
            Load += MainForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbUser).EndInit();
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
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
    }
}
