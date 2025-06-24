namespace case_4
{
    partial class MFM
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            buttonAvt = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 35);
            label1.Name = "label1";
            label1.Size = new Size(58, 54);
            label1.TabIndex = 0;
            label1.Text = "M";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(60, 55);
            label2.Name = "label2";
            label2.Size = new Size(63, 29);
            label2.TabIndex = 1;
            label2.Text = "usic";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(60, 109);
            label3.Name = "label3";
            label3.Size = new Size(46, 29);
            label3.TabIndex = 3;
            label3.Text = "or";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Showcard Gothic", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 89);
            label4.Name = "label4";
            label4.Size = new Size(47, 54);
            label4.TabIndex = 2;
            label4.Text = "F";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(60, 163);
            label5.Name = "label5";
            label5.Size = new Size(26, 29);
            label5.TabIndex = 5;
            label5.Text = "e";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Showcard Gothic", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 143);
            label6.Name = "label6";
            label6.Size = new Size(58, 54);
            label6.TabIndex = 4;
            label6.Text = "M";
            // 
            // buttonAvt
            // 
            buttonAvt.BackColor = Color.MintCream;
            buttonAvt.FlatStyle = FlatStyle.Popup;
            buttonAvt.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAvt.Location = new Point(60, 195);
            buttonAvt.Name = "buttonAvt";
            buttonAvt.Size = new Size(211, 44);
            buttonAvt.TabIndex = 6;
            buttonAvt.Text = "Авторизация";
            buttonAvt.UseVisualStyleBackColor = false;
            buttonAvt.Click += buttonAvt_Click;
            // 
            // MFM
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MintCream;
            ClientSize = new Size(344, 258);
            Controls.Add(buttonAvt);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MFM";
            Text = "MFM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button buttonAvt;
    }
}