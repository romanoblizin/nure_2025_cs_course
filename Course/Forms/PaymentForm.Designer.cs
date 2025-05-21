namespace Course.Forms
{
    partial class PaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            cbService = new ComboBox();
            nudAmount = new NumericUpDown();
            btnPay = new Button();
            lblService = new Label();
            lblAmount = new Label();
            lblComment = new Label();
            tbComment = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            SuspendLayout();
            // 
            // cbService
            // 
            cbService.FormattingEnabled = true;
            cbService.Location = new Point(142, 15);
            cbService.Name = "cbService";
            cbService.Size = new Size(210, 23);
            cbService.TabIndex = 0;
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new Point(142, 44);
            nudAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(210, 23);
            nudAmount.TabIndex = 1;
            // 
            // btnPay
            // 
            btnPay.Location = new Point(12, 117);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(340, 41);
            btnPay.TabIndex = 2;
            btnPay.Text = "Оплатити";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Location = new Point(80, 18);
            lblService.Name = "lblService";
            lblService.Size = new Size(56, 15);
            lblService.TabIndex = 4;
            lblService.Text = "Послуга:";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(97, 46);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(39, 15);
            lblAmount.TabIndex = 5;
            lblAmount.Text = "Сума:";
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Location = new Point(12, 70);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(127, 30);
            lblComment.TabIndex = 6;
            lblComment.Text = "Коментар\r\n(номер рахунку і т. д.)";
            lblComment.TextAlign = ContentAlignment.TopRight;
            // 
            // tbComment
            // 
            tbComment.Location = new Point(142, 75);
            tbComment.Name = "tbComment";
            tbComment.Size = new Size(210, 23);
            tbComment.TabIndex = 3;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(364, 176);
            Controls.Add(lblComment);
            Controls.Add(lblAmount);
            Controls.Add(lblService);
            Controls.Add(tbComment);
            Controls.Add(btnPay);
            Controls.Add(nudAmount);
            Controls.Add(cbService);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Оплата послуг";
            Load += PaymentForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbService;
        private NumericUpDown nudAmount;
        private Button btnPay;
        private Label lblService;
        private Label lblAmount;
        private Label lblComment;
        private TextBox tbComment;
    }
}