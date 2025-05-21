namespace Course.Forms
{
    partial class CreditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditForm));
            lblMonths = new Label();
            lblAmount = new Label();
            lblRate = new Label();
            btnOpen = new Button();
            nudAmount = new NumericUpDown();
            tbRate = new TextBox();
            nudMonths = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonths).BeginInit();
            SuspendLayout();
            // 
            // lblMonths
            // 
            lblMonths.AutoSize = true;
            lblMonths.Location = new Point(38, 82);
            lblMonths.Name = "lblMonths";
            lblMonths.Size = new Size(98, 15);
            lblMonths.TabIndex = 13;
            lblMonths.Text = "Тривалість (міс.)";
            lblMonths.TextAlign = ContentAlignment.TopRight;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(97, 17);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(39, 15);
            lblAmount.TabIndex = 12;
            lblAmount.Text = "Сума:";
            // 
            // lblRate
            // 
            lblRate.AutoSize = true;
            lblRate.Location = new Point(27, 50);
            lblRate.Name = "lblRate";
            lblRate.Size = new Size(109, 15);
            lblRate.TabIndex = 11;
            lblRate.Text = "Процентна ставка:";
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(12, 123);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(340, 41);
            btnOpen.TabIndex = 9;
            btnOpen.Text = "Відкрити кредит";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new Point(142, 15);
            nudAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(210, 23);
            nudAmount.TabIndex = 8;
            // 
            // tbRate
            // 
            tbRate.Location = new Point(142, 47);
            tbRate.Name = "tbRate";
            tbRate.ReadOnly = true;
            tbRate.Size = new Size(210, 23);
            tbRate.TabIndex = 14;
            // 
            // nudMonths
            // 
            nudMonths.Location = new Point(142, 76);
            nudMonths.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudMonths.Name = "nudMonths";
            nudMonths.Size = new Size(210, 23);
            nudMonths.TabIndex = 15;
            // 
            // CreditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(364, 176);
            Controls.Add(nudMonths);
            Controls.Add(tbRate);
            Controls.Add(lblMonths);
            Controls.Add(lblAmount);
            Controls.Add(lblRate);
            Controls.Add(btnOpen);
            Controls.Add(nudAmount);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Відкриття кредиту";
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonths).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMonths;
        private Label lblAmount;
        private Label lblRate;
        private Button btnOpen;
        private NumericUpDown nudAmount;
        private TextBox tbRate;
        private NumericUpDown nudMonths;
    }
}