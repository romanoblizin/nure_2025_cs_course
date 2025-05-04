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
            ((System.ComponentModel.ISupportInitialize)nudSeconds).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinutes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudHours).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDays).BeginInit();
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
            btnSave.Text = "Зберегти";
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
            // TimeDeltaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 176);
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
    }
}