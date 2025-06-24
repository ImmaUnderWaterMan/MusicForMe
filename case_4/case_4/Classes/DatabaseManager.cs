using System.Data.SQLite;
using MusicForMe.AudioManagement;

namespace case_4
{

    public static class DatabaseManager
    {
        public static string ConnectionString { get; } = "Data Source=MusicForMe.db;Version=3;";

        public static bool ValidateUser(string login, string password)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            const string query = "SELECT COUNT(*) FROM accounts WHERE login = @login AND password = @password";
            using var command = new SQLiteCommand(query, connection);

            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        public static (string FullName, string Login) GetUserInfo(string login)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            const string query = "SELECT full_name, login FROM accounts WHERE login = @login";
            using var command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@login", login);
            using var reader = command.ExecuteReader();

            return reader.Read() ? (reader["full_name"].ToString(), reader["login"].ToString()) : (login, login);
        }

        public static int GetUserId(string login)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            const string query = "SELECT id FROM accounts WHERE login = @login";
            using var command = new SQLiteCommand(query, connection);

            command.Parameters.AddWithValue("@login", login);
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public static int GetTrackListCount(int accountId, string tableName)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            string query = $"SELECT COUNT(*) FROM {tableName} WHERE account_id = @accountId";
            using var command = new SQLiteCommand(query, connection);

            command.Parameters.AddWithValue("@accountId", accountId);
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public static List<Audio> GetUserTracks(int accountId, string tableName, int limit = 50)
        {
            var tracks = new List<Audio>();

            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            string query = $@"
            SELECT t.TrackID, m.*, p.* 
            FROM {tableName} lt
            JOIN Tracks t ON lt.track_id = t.TrackID
            JOIN Metadata m ON t.MetadataID = m.MetadataID
            JOIN Properties p ON t.PropertiesID = p.PropertiesID
            WHERE lt.account_id = @accountId
            ORDER BY lt.id DESC
            LIMIT @limit";

            using var command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@accountId", accountId);
            command.Parameters.AddWithValue("@limit", limit);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                tracks.Add(CreateAudioFromReader(reader));
            }
            return tracks;
        }

        public static Audio CreateAudioFromReader(SQLiteDataReader reader)
        {
            var metadata = new AudioMetadata
            {
                Artist = reader["Artist"].ToString(),
                Title = reader["Title"].ToString(),
                Album = reader["Album"].ToString(),
                Genre = reader["Genre"].ToString(),
                ReleaseYear = Convert.ToInt32(reader["ReleaseYear"])
            };
            var properties = new AudioProperties
            {
                BPM = reader["BPM"] != DBNull.Value ? (int?)Convert.ToInt32(reader["BPM"]) : null,
                Key = reader["Key"]?.ToString(),
                Acousticness = GetNullableDouble(reader["Acousticness"]),
                Energy = GetNullableDouble(reader["Energy"]),
                Instrumentalness = GetNullableDouble(reader["Instrumentalness"]),
                Speechiness = GetNullableDouble(reader["Speechiness"]),
                Valence = GetNullableDouble(reader["Valence"])
            };
            return new Audio(Convert.ToInt32(reader["TrackID"]),metadata,properties);
        }

        public static double? GetNullableDouble(object value) => value != DBNull.Value ? Convert.ToDouble(value) : null;
        public static Audio GetAudioById(int trackId, SQLiteConnection connection)
        {

            string trackQuery = @"
            SELECT t.TrackID, m.*, p.* 
            FROM Tracks t
            JOIN Metadata m ON t.MetadataID = m.MetadataID
            JOIN Properties p ON t.PropertiesID = p.PropertiesID
            WHERE t.TrackID = @trackId";

            using (var cmd = new SQLiteCommand(trackQuery, connection))
            {
                cmd.Parameters.AddWithValue("@trackId", trackId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var metadata = new AudioMetadata
                        {
                            Artist = reader["Artist"].ToString(),
                            Title = reader["Title"].ToString(),
                            Album = reader["Album"].ToString(),
                            Genre = reader["Genre"].ToString(),
                            ReleaseYear = Convert.ToInt32(reader["ReleaseYear"])
                        };
                        var properties = new AudioProperties
                        {
                            BPM = reader["BPM"] != DBNull.Value ? (int?)Convert.ToInt32(reader["BPM"]) : null,
                            Key = reader["Key"]?.ToString(),
                            Acousticness = reader["Acousticness"] != DBNull.Value ? (double?)Convert.ToDouble(reader["Acousticness"]) : null,
                            Energy = reader["Energy"] != DBNull.Value ? (double?)Convert.ToDouble(reader["Energy"]) : null,
                            Instrumentalness = reader["Instrumentalness"] != DBNull.Value ? (double?)Convert.ToDouble(reader["Instrumentalness"]) : null,
                            Speechiness = reader["Speechiness"] != DBNull.Value ? (double?)Convert.ToDouble(reader["Speechiness"]) : null,
                            Valence = reader["Valence"] != DBNull.Value ? (double?)Convert.ToDouble(reader["Valence"]) : null
                        };
                        return new Audio(
                            Convert.ToInt32(reader["TrackID"]),
                            metadata,
                            properties
                        );
                    }
                }
            }
            return null;
        }
        public static List<Audio> GetBlacklistedTracks(int accountId, int limit = 50)
        {
            return GetUserTracks(accountId, "black_list", limit);
        }
        public static int GetBlacklistCount(int accountId)
        {
            return GetTrackListCount(accountId, "black_list");
        }
        public static void AddToLastListened(int accountId, int trackId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();

            const string deleteQuery = "DELETE FROM last_listened WHERE account_id = @accountId AND track_id = @trackId";
            using var deleteCommand = new SQLiteCommand(deleteQuery, connection, transaction);
            deleteCommand.CommandTimeout = 30;
            deleteCommand.Parameters.AddWithValue("@accountId", accountId);
            deleteCommand.Parameters.AddWithValue("@trackId", trackId);
            deleteCommand.ExecuteNonQuery();

            const string insertQuery = "INSERT INTO last_listened (account_id, track_id) VALUES (@accountId, @trackId)";
            using var insertCommand = new SQLiteCommand(insertQuery, connection, transaction);
            insertCommand.CommandTimeout = 30;
            insertCommand.Parameters.AddWithValue("@accountId", accountId);
            insertCommand.Parameters.AddWithValue("@trackId", trackId);
            insertCommand.ExecuteNonQuery();

            transaction.Commit();
        }
        public static List<Audio> SearchTracks(string searchTerm)
        {
            var tracks = new List<Audio>();
            using var connection = new SQLiteConnection(DatabaseManager.ConnectionString);
            connection.Open();

            const string query = @"
            SELECT t.TrackID, m.*, p.* 
            FROM Tracks t
            JOIN Metadata m ON t.MetadataID = m.MetadataID
            JOIN Properties p ON t.PropertiesID = p.PropertiesID
            WHERE m.Title LIKE @searchTerm OR 
            m.Artist LIKE @searchTerm
            ORDER BY m.Artist, m.Title";

            using var command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                tracks.Add(DatabaseManager.CreateAudioFromReader(reader));
            }
            return tracks;
        }
        public static void AddOrUpdateRating(int accountId, int trackId, int rating)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();
            const string deleteQuery = "DELETE FROM rating_list WHERE account_id = @accountId AND track_id = @trackId";
            using var deleteCommand = new SQLiteCommand(deleteQuery, connection, transaction);
            deleteCommand.Parameters.AddWithValue("@accountId", accountId);
            deleteCommand.Parameters.AddWithValue("@trackId", trackId);
            deleteCommand.ExecuteNonQuery();

            const string insertQuery = "INSERT INTO rating_list (account_id, track_id, rating) VALUES (@accountId, @trackId, @rating)";
            using var insertCommand = new SQLiteCommand(insertQuery, connection, transaction);
            insertCommand.Parameters.AddWithValue("@accountId", accountId);
            insertCommand.Parameters.AddWithValue("@trackId", trackId);
            insertCommand.Parameters.AddWithValue("@rating", rating);
            insertCommand.ExecuteNonQuery();

            transaction.Commit();
        }
        public static int? GetTrackRating(int accountId, int trackId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            const string query = "SELECT rating FROM rating_list WHERE account_id = @accountId AND track_id = @trackId";
            using var command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@accountId", accountId);
            command.Parameters.AddWithValue("@trackId", trackId);

            var result = command.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : (int?)null;
        }

        public static List<(int TrackId, string Title, int Rating)> GetUserRatings(int accountId)
        {
            var ratings = new List<(int, string, int)>();

            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            const string query = @"
            SELECT t.TrackID, m.Title, r.rating 
            FROM rating_list r
            JOIN Tracks t ON r.track_id = t.TrackID
            JOIN Metadata m ON t.MetadataID = m.MetadataID
            WHERE r.account_id = @accountId
            ORDER BY r.rating DESC";

            using var command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@accountId", accountId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                ratings.Add((Convert.ToInt32(reader["TrackID"]), reader["Title"].ToString(), Convert.ToInt32(reader["rating"])));
            }
            return ratings;
        }
    }
}
