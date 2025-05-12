namespace Course.Forms
{
    partial class CashbankForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashbankForm));
            lblHeader = new Label();
            cbCard = new ComboBox();
            btnConfirm = new Button();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Location = new Point(63, 39);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(238, 15);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Оберіть рахунок для отримання кешбеку:";
            // 
            // cbCard
            // 
            cbCard.FormattingEnabled = true;
            cbCard.Location = new Point(87, 64);
            cbCard.Name = "cbCard";
            cbCard.Size = new Size(190, 23);
            cbCard.TabIndex = 1;
            cbCard.SelectedIndexChanged += cbCard_SelectedIndexChanged;
            // 
            // btnConfirm
            // 
            btnConfirm.Enabled = false;
            btnConfirm.Location = new Point(129, 103);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(106, 25);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Підтвердити";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // CashbankForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(364, 176);
            Controls.Add(btnConfirm);
            Controls.Add(cbCard);
            Controls.Add(lblHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CashbankForm";
            Text = "Отримання кешбеку";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeader;
        private ComboBox cbCard;
        private Button btnConfirm;
    }
}