using System.Data;
using System.Data.SQLite;
using MusicForMe.AudioManagement;

namespace case_4
{
    public partial class MusicForMeApp : Form
    {
        public string CurrentUserLogin;
        public int CurrentUserId;
        public Audio CurrentTrack;
        public List<(int TrackId, string Title, int Rating)> RatedTracks = new();
        public List<Audio> ListeningHistory = new();
        private Recommendation _recommendationSystem;
        public MusicForMeApp(string login)
        {
            InitializeComponent();
            CurrentUserLogin = login;
            CurrentUserId = DatabaseManager.GetUserId(login);
            _recommendationSystem = new Recommendation(CurrentUserId);
            list_panel.Visible = false;
            search_panel.Visible = false;

            InitializeComponents();
            LoadUserData();
        }

        private void InitializeComponents()
        {
            lastlistened_listBox.DisplayMember = "Text";
            listBoxTracks.DisplayMember = "DisplayText";
            listBoxTracks.ValueMember = "Id";

            search_button.Click += Search_button_Click;
            search_listBox.SelectedIndexChanged += Search_listBox_SelectedIndexChanged;
            close_search_button.Click += Close_search_button_Click;
            search_panel.Visible = false;
            search_panel.AutoSize = false;
            search_listBox.IntegralHeight = false;
            acceptRaiting_label.Click += AcceptRaiting_label_Click;

            raiting_numericUpDown.Minimum = 0;
            raiting_numericUpDown.Maximum = 10;

            search_panel.Visible = false;
            search_panel.BringToFront();
        }

        public void LoadUserData()
        {
            var userInfo = DatabaseManager.GetUserInfo(CurrentUserLogin);
            accountname_label.Text = userInfo.Login;

            RefreshLastListenedTracks(); 
            RefreshRatingsList();     
            UpdateTrackCounts();       
        }
        public void RefreshLastListenedTracks()
        {
            ListeningHistory = DatabaseManager.GetUserTracks(CurrentUserId, "last_listened");
            lastlistened_listBox.DataSource = ListeningHistory.Select(t => $"{t.Metadata.Artist} - {t.Metadata.Title}").ToList();
        }

        public void UpdateTrackCounts()
        {
            likelist_button.Text = $"Любимые треки ({DatabaseManager.GetTrackListCount(CurrentUserId, "like_list")})";
        }

        public void DisplayTrackInfo(Audio audio)
        {
            if (audio == null) return;

            CurrentTrack = audio;
            trackName_label.Text = audio.Metadata.Title;
            trackAtrtist_label.Text = audio.Metadata.Artist;
            Like_label.ForeColor = IsTrackLiked(audio.ID) ? Color.DarkTurquoise : Color.White;
            Dislike_label.ForeColor = IsTrackBlacklisted(audio.ID) ? Color.DarkTurquoise : Color.White;

            var info = new List<string>
            {
                $"Исполнитель: {audio.Metadata.Artist}",
                $"Название: {audio.Metadata.Title}",
                $"Альбом: {audio.Metadata.Album}",
                $"Жанр: {audio.Metadata.Genre}",
                $"Год: {audio.Metadata.ReleaseYear}",
            };

            information_listBox.Items.Clear();
            information_listBox.Items.AddRange(info.ToArray());
        }

        public bool IsTrackLiked(int trackId)
        {
            using var connection = new SQLiteConnection(DatabaseManager.ConnectionString);
            connection.Open();

            const string query = "SELECT COUNT(*) FROM like_list WHERE account_id = @accountId AND track_id = @trackId";
            using var command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@accountId", CurrentUserId);
            command.Parameters.AddWithValue("@trackId", trackId);

            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        public void ToggleLikeStatus()
        {
            if (CurrentTrack == null) return;

            using var connection = new SQLiteConnection(DatabaseManager.ConnectionString);
            connection.Open();

            if (!IsTrackLiked(CurrentTrack.ID))
            {
                const string query = "INSERT INTO like_list (account_id, track_id) VALUES (@accountId, @trackId)";
                using var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@accountId", CurrentUserId);
                command.Parameters.AddWithValue("@trackId", CurrentTrack.ID);
                command.ExecuteNonQuery();
                Like_label.ForeColor = Color.DarkTurquoise;

                if (IsTrackBlacklisted(CurrentTrack.ID))
                {
                    const string deleteQuery = "DELETE FROM black_list WHERE account_id = @accountId AND track_id = @trackId";
                    using var deleteCommand = new SQLiteCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@accountId", CurrentUserId);
                    deleteCommand.Parameters.AddWithValue("@trackId", CurrentTrack.ID);
                    deleteCommand.ExecuteNonQuery();

                    Dislike_label.ForeColor = Color.White;
                }
            }
            else
            {
                const string query = "DELETE FROM like_list WHERE account_id = @accountId AND track_id = @trackId";
                using var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@accountId", CurrentUserId);
                command.Parameters.AddWithValue("@trackId", CurrentTrack.ID);
                command.ExecuteNonQuery();
                Like_label.ForeColor = Color.White;
            }
            UpdateTrackCounts();
        }

        public Audio GetTrackById(int trackId)
        {
            using var connection = new SQLiteConnection(DatabaseManager.ConnectionString);
            connection.Open();
            return DatabaseManager.GetAudioById(trackId, connection);
        }

        private void Exit_label_Click(object sender, EventArgs e)
        {
            new login().Show();
            Hide();
        }

        private void Like_label_Click(object sender, EventArgs e) => ToggleLikeStatus();
        private void Dislike_label_Click(object sender, EventArgs e) => ToggleBlacklistStatus();

        private void Likelist_button_Click(object sender, EventArgs e)
        {
            var likedTracks = DatabaseManager.GetUserTracks(CurrentUserId, "like_list");
            LoadTracksIntoListBox(likedTracks);
            ToggleListPanel(true);
            TracksTypelabel.Text = "Понравившиеся треки";
        }
        public bool IgnoreSelectionChanges = false;
        private void BackFromLike_pictureBox_Click(object sender, EventArgs e) => ToggleListPanel(false);

        public void ToggleListPanel(bool visible)
        {
            list_panel.Visible = visible;
            backFromList_pictureBox.Visible = visible;

            UpdateTrackCounts();
        }

        public void LoadTracksIntoListBox(List<Audio> tracks)
        {
            IgnoreSelectionChanges = true;

            listBoxTracks.DataSource = tracks.Select(t => new { Id = t.ID, DisplayText = $"{t.Metadata.Artist} - {t.Metadata.Title}" }).ToList();
            listBoxTracks.SelectedIndex = -1;

            IgnoreSelectionChanges = false;
        }
        public bool IsTrackBlacklisted(int trackId)
        {
            using var connection = new SQLiteConnection(DatabaseManager.ConnectionString);
            connection.Open();

            const string query = "SELECT COUNT(*) FROM black_list WHERE account_id = @accountId AND track_id = @trackId";
            using var command = new SQLiteCommand(query, connection);

            command.Parameters.AddWithValue("@accountId", CurrentUserId);
            command.Parameters.AddWithValue("@trackId", trackId);

            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }
        public void ToggleBlacklistStatus()
        {
            if (CurrentTrack == null) return;
            using var connection = new SQLiteConnection(DatabaseManager.ConnectionString);
            connection.Open();

            if (!IsTrackBlacklisted(CurrentTrack.ID))
            {
                const string query = "INSERT INTO black_list (account_id, track_id) VALUES (@accountId, @trackId)";
                using var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@accountId", CurrentUserId);
                command.Parameters.AddWithValue("@trackId", CurrentTrack.ID);
                command.ExecuteNonQuery();

                Dislike_label.ForeColor = Color.DarkTurquoise;

                if (IsTrackLiked(CurrentTrack.ID))
                {
                    const string deleteQuery = "DELETE FROM like_list WHERE account_id = @accountId AND track_id = @trackId";
                    using var deleteCommand = new SQLiteCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@accountId", CurrentUserId);
                    deleteCommand.Parameters.AddWithValue("@trackId", CurrentTrack.ID);
                    deleteCommand.ExecuteNonQuery();

                    Like_label.ForeColor = Color.White;
                }
            }
            else
            {
                const string query = "DELETE FROM black_list WHERE account_id = @accountId AND track_id = @trackId";
                using var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@accountId", CurrentUserId);
                command.Parameters.AddWithValue("@trackId", CurrentTrack.ID);
                command.ExecuteNonQuery();

                Dislike_label.ForeColor = Color.White;
            }
            UpdateTrackCounts();
        }
        private void Search_button_Click(object sender, EventArgs e)
        {
            string searchTerm = search_textBox.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            search_button.Enabled = false;

            Task.Run(() =>
            {
                List<Audio> foundTracks = DatabaseManager.SearchTracks(searchTerm);
                this.Invoke((MethodInvoker)delegate
                {
                    Cursor.Current = Cursors.Default;
                    search_button.Enabled = true;

                    if (foundTracks == null || foundTracks.Count == 0)
                    {
                        return;
                    }
                    SearchResults = foundTracks;
                    search_listBox.DataSource = foundTracks.Select(t => $"{t.Metadata.Artist} - {t.Metadata.Title}").ToList();
                    AdjustSearchPanelSize(foundTracks.Count);
                    search_panel.Visible = true;
                    search_panel.BringToFront();
                });
            });
        }
        public void AdjustSearchPanelSize(int itemsCount)
        {
            const int itemHeight = 20;
            const int padding = 20;
            const int minHeight = 0;
            const int maxHeight = 350;

            int listHeight = itemsCount * itemHeight;
            int panelHeight = Math.Clamp(listHeight + padding, minHeight, maxHeight);

            search_listBox.Height = listHeight;
            search_panel.Height = panelHeight;

        }
        public List<Audio> SearchResults = new();

        private async void Search_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (search_listBox.SelectedIndex >= 0 && search_listBox.SelectedIndex < SearchResults.Count)
            {
                CurrentTrack = SearchResults[search_listBox.SelectedIndex];
                await Task.Run(() => DatabaseManager.AddToLastListened(CurrentUserId, CurrentTrack.ID));
                RefreshLastListenedTracks();

                this.Invoke((MethodInvoker)(() =>
                {
                    DisplayTrackInfo(CurrentTrack);
                    UpdateCurrentTrackRating();
                }));
            }
        }
        private void Close_search_button_Click(object sender, EventArgs e)
        {
            search_panel.Visible = false;
            search_textBox.Clear();
            SearchResults.Clear();
        }
        public void StartStop(PictureBox pictureBox1, PictureBox pictureBox2)
        {
            if (pictureBox1.Visible = true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
            else
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
            }
        }

        public void UpdateCurrentTrackRating()
        {
            if (CurrentTrack != null)
            {
                raitingName_label.Text = CurrentTrack.Metadata.Title;
                var rating = DatabaseManager.GetTrackRating(CurrentUserId, CurrentTrack.ID);
            }
            else
            {
                raitingName_label.Text = "Трек не выбран";
                raiting_numericUpDown.Value = 5;
            }
        }
        public void RefreshRatingsList(int? keepSelectedTrackId = null)
        {
            RatedTracks = DatabaseManager.GetUserRatings(CurrentUserId);
            raiting_listBox.DataSource = RatedTracks.Select(t => $"{t.Title} - {t.Rating}").ToList();
        }

        private void AcceptRaiting_label_Click(object sender, EventArgs e)
        {
            if (CurrentTrack == null)
            {
                MessageBox.Show("Выберите трек для оценки");
                return;
            }
            int rating = (int)raiting_numericUpDown.Value;
            DatabaseManager.AddOrUpdateRating(CurrentUserId, CurrentTrack.ID, rating);
            DatabaseManager.AddToLastListened(CurrentUserId, CurrentTrack.ID);
            RefreshRatingsList(CurrentTrack.ID);
            raitingName_label.Text = CurrentTrack.Metadata.Title;
            DisplayTrackInfo(CurrentTrack);
        }

        private void ListBoxTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IgnoreSelectionChanges || listBoxTracks.SelectedIndex == -1 || listBoxTracks.SelectedValue == null) return;

            int trackId = (int)listBoxTracks.SelectedValue;
            CurrentTrack = GetTrackById(trackId);

            if (CurrentTrack != null)
            {
                DatabaseManager.AddToLastListened(CurrentUserId, trackId);
                RefreshLastListenedTracks();
                DisplayTrackInfo(CurrentTrack);
                UpdateCurrentTrackRating();
            }
        }
        private void Start2_pictureBox_Click(object sender, EventArgs e)
        {
            StartStop(Start2_pictureBox, Stop2_pictureBox);

            Cursor.Current = Cursors.WaitCursor;
            Task.Run(() =>
            {
                _recommendationSystem.GenerateRecommendations();
                var recommendedTrack = _recommendationSystem.GetNextTrack();

                this.Invoke((MethodInvoker)delegate
                {
                    CurrentTrack = recommendedTrack;
                    DisplayTrackInfo(CurrentTrack);
                    DatabaseManager.AddToLastListened(CurrentUserId, CurrentTrack.ID);
                    RefreshLastListenedTracks();
                });
            });
        }
        private void Stop2_pictureBox_Click(object sender, EventArgs e)
        {
            StartStop(Stop2_pictureBox, Start2_pictureBox);

        }

        private void Next_pictureBox_Click(object sender, EventArgs e)
        {
            var nextTrack = _recommendationSystem.GetNextTrack();
            if (nextTrack != null)
            {
                CurrentTrack = nextTrack;
                DisplayTrackInfo(CurrentTrack);
                DatabaseManager.AddToLastListened(CurrentUserId, CurrentTrack.ID);
                RefreshLastListenedTracks();
            }
        }
        private void Last_pictureBox_Click(object sender, EventArgs e)
        {
            var prevTrack = _recommendationSystem.GetPreviousTrack();
            if (prevTrack != null)
            {
                CurrentTrack = prevTrack;
                DisplayTrackInfo(CurrentTrack);
                DatabaseManager.AddToLastListened(CurrentUserId, CurrentTrack.ID);
                RefreshLastListenedTracks();
            }
        }
    }
}
