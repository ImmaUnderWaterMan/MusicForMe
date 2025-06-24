namespace case_4
{
    partial class MusicForMeApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicForMeApp));
            panel1 = new Panel();
            search_listBox = new ListBox();
            Dislike_label = new Label();
            Like_label = new Label();
            search_panel = new Panel();
            search_textBox = new TextBox();
            search_button = new Button();
            close_search_button = new Button();
            Last_pictureBox = new PictureBox();
            Next_pictureBox = new PictureBox();
            trackAtrtist_label = new Label();
            trackName_label = new Label();
            likelist_button = new Button();
            Start2_pictureBox = new PictureBox();
            Stop2_pictureBox = new PictureBox();
            Start_pictureBox = new PictureBox();
            accountname_label = new Label();
            list_panel = new Panel();
            TracksTypelabel = new Label();
            listBoxTracks = new ListBox();
            backFromList_pictureBox = new PictureBox();
            lastlistened_listBox = new ListBox();
            information_listBox = new ListBox();
            raiting_panel = new Panel();
            acceptRaiting_label = new Label();
            label8 = new Label();
            label4 = new Label();
            raitingName_label = new Label();
            raiting_numericUpDown = new NumericUpDown();
            raiting_listBox = new ListBox();
            pictureBox5 = new PictureBox();
            label_history = new Label();
            label_nowplaying = new Label();
            panel1.SuspendLayout();
            search_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Last_pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Next_pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Start2_pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Stop2_pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Start_pictureBox).BeginInit();
            list_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backFromList_pictureBox).BeginInit();
            raiting_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)raiting_numericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Indigo;
            panel1.Controls.Add(search_listBox);
            panel1.Controls.Add(Dislike_label);
            panel1.Controls.Add(Like_label);
            panel1.Controls.Add(search_panel);
            panel1.Controls.Add(Last_pictureBox);
            panel1.Controls.Add(Next_pictureBox);
            panel1.Controls.Add(trackAtrtist_label);
            panel1.Controls.Add(trackName_label);
            panel1.Controls.Add(likelist_button);
            panel1.Controls.Add(Start2_pictureBox);
            panel1.Controls.Add(Stop2_pictureBox);
            panel1.ForeColor = Color.DimGray;
            panel1.Location = new Point(5, 255);
            panel1.Margin = new Padding(2, 4, 2, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1201, 132);
            panel1.TabIndex = 0;
            // 
            // search_listBox
            // 
            search_listBox.BackColor = Color.FromArgb(37, 37, 37);
            search_listBox.BorderStyle = BorderStyle.None;
            search_listBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            search_listBox.ForeColor = Color.White;
            search_listBox.FormattingEnabled = true;
            search_listBox.Location = new Point(1208, 82);
            search_listBox.Margin = new Padding(4);
            search_listBox.Name = "search_listBox";
            search_listBox.Size = new Size(146, 28);
            search_listBox.TabIndex = 0;
            search_listBox.SelectedIndexChanged += Search_listBox_SelectedIndexChanged;
            // 
            // Dislike_label
            // 
            Dislike_label.AutoSize = true;
            Dislike_label.Cursor = Cursors.Hand;
            Dislike_label.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Dislike_label.ForeColor = Color.Black;
            Dislike_label.Location = new Point(977, 48);
            Dislike_label.Margin = new Padding(4, 0, 4, 0);
            Dislike_label.Name = "Dislike_label";
            Dislike_label.Size = new Size(72, 54);
            Dislike_label.TabIndex = 35;
            Dislike_label.Text = "👎";
            Dislike_label.Click += Dislike_label_Click;
            // 
            // Like_label
            // 
            Like_label.AutoSize = true;
            Like_label.Cursor = Cursors.Hand;
            Like_label.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Like_label.ForeColor = Color.Black;
            Like_label.Location = new Point(1072, 40);
            Like_label.Margin = new Padding(4, 0, 4, 0);
            Like_label.Name = "Like_label";
            Like_label.Size = new Size(72, 54);
            Like_label.TabIndex = 34;
            Like_label.Text = "👍";
            Like_label.Click += Like_label_Click;
            // 
            // search_panel
            // 
            search_panel.AutoSize = true;
            search_panel.BackgroundImage = (Image)resources.GetObject("search_panel.BackgroundImage");
            search_panel.Controls.Add(search_textBox);
            search_panel.Controls.Add(search_button);
            search_panel.Controls.Add(close_search_button);
            search_panel.Location = new Point(1199, 82);
            search_panel.Margin = new Padding(4);
            search_panel.Name = "search_panel";
            search_panel.Size = new Size(285, 68);
            search_panel.TabIndex = 16;
            // 
            // search_textBox
            // 
            search_textBox.BackColor = Color.FromArgb(37, 37, 37);
            search_textBox.BorderStyle = BorderStyle.FixedSingle;
            search_textBox.Cursor = Cursors.IBeam;
            search_textBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            search_textBox.ForeColor = Color.White;
            search_textBox.Location = new Point(120, 15);
            search_textBox.Margin = new Padding(2, 4, 2, 4);
            search_textBox.Name = "search_textBox";
            search_textBox.Size = new Size(104, 39);
            search_textBox.TabIndex = 5;
            // 
            // search_button
            // 
            search_button.BackColor = Color.FromArgb(37, 37, 37);
            search_button.Cursor = Cursors.Hand;
            search_button.FlatAppearance.BorderSize = 0;
            search_button.FlatStyle = FlatStyle.Flat;
            search_button.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            search_button.ForeColor = Color.White;
            search_button.Location = new Point(72, 15);
            search_button.Margin = new Padding(2, 4, 2, 4);
            search_button.Name = "search_button";
            search_button.Size = new Size(42, 41);
            search_button.TabIndex = 6;
            search_button.Text = "✔️";
            search_button.UseVisualStyleBackColor = false;
            search_button.Click += Search_button_Click;
            // 
            // close_search_button
            // 
            close_search_button.BackColor = Color.FromArgb(37, 37, 37);
            close_search_button.Cursor = Cursors.Hand;
            close_search_button.FlatAppearance.BorderSize = 0;
            close_search_button.FlatStyle = FlatStyle.Flat;
            close_search_button.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            close_search_button.ForeColor = Color.White;
            close_search_button.Location = new Point(239, 15);
            close_search_button.Margin = new Padding(2, 4, 2, 4);
            close_search_button.Name = "close_search_button";
            close_search_button.Size = new Size(44, 41);
            close_search_button.TabIndex = 17;
            close_search_button.Text = "❌";
            close_search_button.UseVisualStyleBackColor = false;
            close_search_button.Click += Close_search_button_Click;
            // 
            // Last_pictureBox
            // 
            Last_pictureBox.BackColor = Color.Transparent;
            Last_pictureBox.Cursor = Cursors.Hand;
            Last_pictureBox.Image = (Image)resources.GetObject("Last_pictureBox.Image");
            Last_pictureBox.Location = new Point(719, 48);
            Last_pictureBox.Margin = new Padding(2);
            Last_pictureBox.Name = "Last_pictureBox";
            Last_pictureBox.Size = new Size(65, 41);
            Last_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            Last_pictureBox.TabIndex = 16;
            Last_pictureBox.TabStop = false;
            Last_pictureBox.Click += Last_pictureBox_Click;
            // 
            // Next_pictureBox
            // 
            Next_pictureBox.BackColor = Color.Transparent;
            Next_pictureBox.Cursor = Cursors.Hand;
            Next_pictureBox.Image = (Image)resources.GetObject("Next_pictureBox.Image");
            Next_pictureBox.Location = new Point(884, 48);
            Next_pictureBox.Margin = new Padding(2);
            Next_pictureBox.Name = "Next_pictureBox";
            Next_pictureBox.Size = new Size(65, 41);
            Next_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            Next_pictureBox.TabIndex = 15;
            Next_pictureBox.TabStop = false;
            Next_pictureBox.Click += Next_pictureBox_Click;
            // 
            // trackAtrtist_label
            // 
            trackAtrtist_label.AutoSize = true;
            trackAtrtist_label.BackColor = Color.Transparent;
            trackAtrtist_label.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            trackAtrtist_label.ForeColor = Color.White;
            trackAtrtist_label.Location = new Point(149, 68);
            trackAtrtist_label.Margin = new Padding(2, 0, 2, 0);
            trackAtrtist_label.Name = "trackAtrtist_label";
            trackAtrtist_label.Size = new Size(0, 23);
            trackAtrtist_label.TabIndex = 7;
            // 
            // trackName_label
            // 
            trackName_label.AutoSize = true;
            trackName_label.BackColor = Color.Transparent;
            trackName_label.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            trackName_label.ForeColor = Color.White;
            trackName_label.Location = new Point(145, 35);
            trackName_label.Margin = new Padding(2, 0, 2, 0);
            trackName_label.Name = "trackName_label";
            trackName_label.RightToLeft = RightToLeft.No;
            trackName_label.Size = new Size(0, 32);
            trackName_label.TabIndex = 6;
            // 
            // likelist_button
            // 
            likelist_button.BackColor = Color.Indigo;
            likelist_button.BackgroundImageLayout = ImageLayout.Stretch;
            likelist_button.Cursor = Cursors.Hand;
            likelist_button.FlatAppearance.BorderSize = 0;
            likelist_button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            likelist_button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            likelist_button.FlatStyle = FlatStyle.Flat;
            likelist_button.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            likelist_button.ForeColor = Color.White;
            likelist_button.Location = new Point(412, -2);
            likelist_button.Margin = new Padding(2, 4, 2, 4);
            likelist_button.Name = "likelist_button";
            likelist_button.Size = new Size(288, 60);
            likelist_button.TabIndex = 3;
            likelist_button.Text = "Любимые треки";
            likelist_button.UseVisualStyleBackColor = false;
            likelist_button.Click += Likelist_button_Click;
            // 
            // Start2_pictureBox
            // 
            Start2_pictureBox.BackColor = Color.Transparent;
            Start2_pictureBox.Cursor = Cursors.Hand;
            Start2_pictureBox.Image = (Image)resources.GetObject("Start2_pictureBox.Image");
            Start2_pictureBox.InitialImage = (Image)resources.GetObject("Start2_pictureBox.InitialImage");
            Start2_pictureBox.Location = new Point(788, 35);
            Start2_pictureBox.Margin = new Padding(2, 4, 2, 4);
            Start2_pictureBox.Name = "Start2_pictureBox";
            Start2_pictureBox.Size = new Size(92, 67);
            Start2_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            Start2_pictureBox.TabIndex = 36;
            Start2_pictureBox.TabStop = false;
            Start2_pictureBox.Click += Start2_pictureBox_Click;
            // 
            // Stop2_pictureBox
            // 
            Stop2_pictureBox.BackColor = Color.Transparent;
            Stop2_pictureBox.Cursor = Cursors.Hand;
            Stop2_pictureBox.Image = (Image)resources.GetObject("Stop2_pictureBox.Image");
            Stop2_pictureBox.Location = new Point(788, 35);
            Stop2_pictureBox.Margin = new Padding(2, 4, 2, 4);
            Stop2_pictureBox.Name = "Stop2_pictureBox";
            Stop2_pictureBox.Size = new Size(92, 67);
            Stop2_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            Stop2_pictureBox.TabIndex = 36;
            Stop2_pictureBox.TabStop = false;
            Stop2_pictureBox.Click += Stop2_pictureBox_Click;
            // 
            // Start_pictureBox
            // 
            Start_pictureBox.BackColor = Color.Transparent;
            Start_pictureBox.Cursor = Cursors.Hand;
            Start_pictureBox.Image = (Image)resources.GetObject("Start_pictureBox.Image");
            Start_pictureBox.Location = new Point(245, 72);
            Start_pictureBox.Margin = new Padding(2, 4, 2, 4);
            Start_pictureBox.Name = "Start_pictureBox";
            Start_pictureBox.Size = new Size(12, 12);
            Start_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            Start_pictureBox.TabIndex = 22;
            Start_pictureBox.TabStop = false;
            // 
            // accountname_label
            // 
            accountname_label.AutoSize = true;
            accountname_label.BackColor = Color.Transparent;
            accountname_label.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            accountname_label.ForeColor = Color.White;
            accountname_label.Location = new Point(1056, 28);
            accountname_label.Margin = new Padding(2, 0, 2, 0);
            accountname_label.Name = "accountname_label";
            accountname_label.Size = new Size(160, 20);
            accountname_label.TabIndex = 4;
            accountname_label.Text = "VictoriaMorozova678";
            // 
            // list_panel
            // 
            list_panel.BackColor = Color.MintCream;
            list_panel.Controls.Add(TracksTypelabel);
            list_panel.Controls.Add(listBoxTracks);
            list_panel.Controls.Add(backFromList_pictureBox);
            list_panel.ForeColor = Color.Black;
            list_panel.Location = new Point(705, 28);
            list_panel.Margin = new Padding(2);
            list_panel.Name = "list_panel";
            list_panel.Size = new Size(501, 219);
            list_panel.TabIndex = 11;
            // 
            // TracksTypelabel
            // 
            TracksTypelabel.AutoSize = true;
            TracksTypelabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TracksTypelabel.ForeColor = Color.Black;
            TracksTypelabel.Location = new Point(107, 19);
            TracksTypelabel.Margin = new Padding(4, 0, 4, 0);
            TracksTypelabel.Name = "TracksTypelabel";
            TracksTypelabel.Size = new Size(72, 41);
            TracksTypelabel.TabIndex = 3;
            TracksTypelabel.Text = "null";
            // 
            // listBoxTracks
            // 
            listBoxTracks.BackColor = Color.MintCream;
            listBoxTracks.BorderStyle = BorderStyle.None;
            listBoxTracks.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            listBoxTracks.ForeColor = Color.Black;
            listBoxTracks.FormattingEnabled = true;
            listBoxTracks.Location = new Point(33, 67);
            listBoxTracks.Margin = new Padding(2);
            listBoxTracks.Name = "listBoxTracks";
            listBoxTracks.Size = new Size(455, 144);
            listBoxTracks.TabIndex = 2;
            listBoxTracks.SelectedIndexChanged += ListBoxTracks_SelectedIndexChanged;
            // 
            // backFromList_pictureBox
            // 
            backFromList_pictureBox.Cursor = Cursors.Hand;
            backFromList_pictureBox.Image = (Image)resources.GetObject("backFromList_pictureBox.Image");
            backFromList_pictureBox.Location = new Point(15, 15);
            backFromList_pictureBox.Margin = new Padding(2);
            backFromList_pictureBox.Name = "backFromList_pictureBox";
            backFromList_pictureBox.Size = new Size(81, 48);
            backFromList_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            backFromList_pictureBox.TabIndex = 1;
            backFromList_pictureBox.TabStop = false;
            backFromList_pictureBox.Click += BackFromLike_pictureBox_Click;
            // 
            // lastlistened_listBox
            // 
            lastlistened_listBox.BackColor = Color.MintCream;
            lastlistened_listBox.BorderStyle = BorderStyle.FixedSingle;
            lastlistened_listBox.ForeColor = Color.Black;
            lastlistened_listBox.FormattingEnabled = true;
            lastlistened_listBox.Location = new Point(5, 41);
            lastlistened_listBox.Margin = new Padding(4);
            lastlistened_listBox.Name = "lastlistened_listBox";
            lastlistened_listBox.SelectionMode = SelectionMode.None;
            lastlistened_listBox.Size = new Size(274, 122);
            lastlistened_listBox.TabIndex = 0;
            // 
            // information_listBox
            // 
            information_listBox.BackColor = Color.MintCream;
            information_listBox.BorderStyle = BorderStyle.FixedSingle;
            information_listBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            information_listBox.ForeColor = Color.Black;
            information_listBox.FormattingEnabled = true;
            information_listBox.Location = new Point(343, 85);
            information_listBox.Margin = new Padding(2);
            information_listBox.Name = "information_listBox";
            information_listBox.SelectionMode = SelectionMode.None;
            information_listBox.Size = new Size(349, 102);
            information_listBox.TabIndex = 15;
            // 
            // raiting_panel
            // 
            raiting_panel.BackColor = Color.Transparent;
            raiting_panel.BackgroundImage = (Image)resources.GetObject("raiting_panel.BackgroundImage");
            raiting_panel.Controls.Add(acceptRaiting_label);
            raiting_panel.Controls.Add(label8);
            raiting_panel.Controls.Add(label4);
            raiting_panel.Controls.Add(raitingName_label);
            raiting_panel.Controls.Add(raiting_numericUpDown);
            raiting_panel.Controls.Add(raiting_listBox);
            raiting_panel.Controls.Add(pictureBox5);
            raiting_panel.Location = new Point(680, 85);
            raiting_panel.Margin = new Padding(4);
            raiting_panel.Name = "raiting_panel";
            raiting_panel.Size = new Size(12, 14);
            raiting_panel.TabIndex = 18;
            // 
            // acceptRaiting_label
            // 
            acceptRaiting_label.AutoSize = true;
            acceptRaiting_label.Cursor = Cursors.Hand;
            acceptRaiting_label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            acceptRaiting_label.ForeColor = Color.DarkTurquoise;
            acceptRaiting_label.Location = new Point(165, 294);
            acceptRaiting_label.Margin = new Padding(4, 0, 4, 0);
            acceptRaiting_label.Name = "acceptRaiting_label";
            acceptRaiting_label.Size = new Size(47, 32);
            acceptRaiting_label.TabIndex = 21;
            acceptRaiting_label.Text = "✔️";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label8.ForeColor = Color.White;
            label8.Location = new Point(65, 8);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(89, 28);
            label8.TabIndex = 17;
            label8.Text = "Рейтинг";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.White;
            label4.Location = new Point(24, 304);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 3;
            label4.Text = "Рейтинг:";
            // 
            // raitingName_label
            // 
            raitingName_label.AutoSize = true;
            raitingName_label.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            raitingName_label.ForeColor = Color.White;
            raitingName_label.Location = new Point(15, 265);
            raitingName_label.Margin = new Padding(4, 0, 4, 0);
            raitingName_label.Name = "raitingName_label";
            raitingName_label.Size = new Size(141, 23);
            raitingName_label.TabIndex = 2;
            raitingName_label.Text = "Название трека";
            // 
            // raiting_numericUpDown
            // 
            raiting_numericUpDown.BackColor = Color.FromArgb(37, 37, 37);
            raiting_numericUpDown.BorderStyle = BorderStyle.None;
            raiting_numericUpDown.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            raiting_numericUpDown.ForeColor = Color.White;
            raiting_numericUpDown.Location = new Point(104, 300);
            raiting_numericUpDown.Margin = new Padding(4);
            raiting_numericUpDown.Name = "raiting_numericUpDown";
            raiting_numericUpDown.Size = new Size(52, 28);
            raiting_numericUpDown.TabIndex = 1;
            // 
            // raiting_listBox
            // 
            raiting_listBox.BackColor = Color.FromArgb(37, 37, 37);
            raiting_listBox.BorderStyle = BorderStyle.None;
            raiting_listBox.ForeColor = Color.White;
            raiting_listBox.FormattingEnabled = true;
            raiting_listBox.Location = new Point(15, 46);
            raiting_listBox.Margin = new Padding(4);
            raiting_listBox.Name = "raiting_listBox";
            raiting_listBox.SelectionMode = SelectionMode.None;
            raiting_listBox.Size = new Size(12, 20);
            raiting_listBox.TabIndex = 0;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.InitialImage = null;
            pictureBox5.Location = new Point(-218, 60);
            pictureBox5.Margin = new Padding(4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(622, 462);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 21;
            pictureBox5.TabStop = false;
            // 
            // label_history
            // 
            label_history.AutoSize = true;
            label_history.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_history.Location = new Point(5, 9);
            label_history.Name = "label_history";
            label_history.Size = new Size(259, 28);
            label_history.TabIndex = 38;
            label_history.Text = "История прослушивания";
            // 
            // label_nowplaying
            // 
            label_nowplaying.AutoSize = true;
            label_nowplaying.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_nowplaying.Location = new Point(343, 41);
            label_nowplaying.Name = "label_nowplaying";
            label_nowplaying.Size = new Size(151, 28);
            label_nowplaying.TabIndex = 39;
            label_nowplaying.Text = "Сейчас играет";
            // 
            // MusicForMeApp
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.MintCream;
            ClientSize = new Size(1204, 389);
            Controls.Add(label_nowplaying);
            Controls.Add(label_history);
            Controls.Add(lastlistened_listBox);
            Controls.Add(information_listBox);
            Controls.Add(Start_pictureBox);
            Controls.Add(list_panel);
            Controls.Add(panel1);
            Controls.Add(raiting_panel);
            Controls.Add(accountname_label);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(2, 4, 2, 4);
            Name = "MusicForMeApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MusicForMe";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            search_panel.ResumeLayout(false);
            search_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Last_pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)Next_pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)Start2_pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)Stop2_pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)Start_pictureBox).EndInit();
            list_panel.ResumeLayout(false);
            list_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)backFromList_pictureBox).EndInit();
            raiting_panel.ResumeLayout(false);
            raiting_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)raiting_numericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label accountname_label;
        private Label trackAtrtist_label;
        private Label trackName_label;
        private Button likelist_button;
        private TextBox search_textBox;
        private Button search_button;
        private PictureBox Next_pictureBox;
        private PictureBox Last_pictureBox;
        private Label Exit_label;
        private PictureBox Start_pictureBox;
        private Panel list_panel;
        private PictureBox backFromList_pictureBox;
        private ListBox listBoxTracks;
        private ListBox information_listBox;
        private Label Dislike_label;
        private Label Like_label;
        private ListBox lastlistened_listBox;
        private Button blacklist_button;
        private Panel search_panel;
        private ListBox search_listBox;
        private Button close_search_button;
        private Panel raiting_panel;
        private ListBox raiting_listBox;
        private Label label4;
        private Label raitingName_label;
        private NumericUpDown raiting_numericUpDown;
        private PictureBox pictureBox5;
        private Label label8;
        private Label acceptRaiting_label;
        private PictureBox Start2_pictureBox;
        private PictureBox Stop2_pictureBox;
        private Label TracksTypelabel;
        private Label label_history;
        private Label label_nowplaying;
    }
}
