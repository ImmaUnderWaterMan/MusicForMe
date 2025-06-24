namespace case_4
{
    partial class login
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
            login_textBox = new TextBox();
            password_textBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // login_textBox
            // 
            login_textBox.Cursor = Cursors.IBeam;
            login_textBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            login_textBox.Location = new Point(89, 86);
            login_textBox.Margin = new Padding(3, 4, 3, 4);
            login_textBox.Name = "login_textBox";
            login_textBox.Size = new Size(212, 34);
            login_textBox.TabIndex = 1;
            // 
            // password_textBox
            // 
            password_textBox.Cursor = Cursors.IBeam;
            password_textBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            password_textBox.Location = new Point(89, 128);
            password_textBox.Margin = new Padding(3, 4, 3, 4);
            password_textBox.Name = "password_textBox";
            password_textBox.Size = new Size(212, 34);
            password_textBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Bauhaus 93", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(20, 94);
            label2.Name = "label2";
            label2.Size = new Size(57, 23);
            label2.TabIndex = 3;
            label2.Text = "Логин";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(22, 142);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 4;
            label3.Text = "Пароль";
            // 
            // button1
            // 
            button1.BackColor = Color.MintCream;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(75, 200);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(169, 40);
            button1.TabIndex = 6;
            button1.Text = "Авторизаваться";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Bauhaus 93", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 35);
            label1.Name = "label1";
            label1.Size = new Size(302, 26);
            label1.TabIndex = 7;
            label1.Text = "Введите ваш логин и пароль";
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MintCream;
            ClientSize = new Size(313, 253);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(password_textBox);
            Controls.Add(login_textBox);
            ForeColor = Color.FromArgb(51, 51, 51);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox login_textBox;
        private TextBox password_textBox;
        private Label label2;
        private Label label3;
        private Button button1;
        private Label label1;
    }
}