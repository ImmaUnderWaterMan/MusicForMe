using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicForMe.AudioManagement;

namespace case_4
{
    public class Recommendation
    {
        public int UserId;
        public List<Audio> Recommendations = new();
        public int CurrentIndex = -1;

        public Recommendation(int userId)
        {
            UserId = userId;
        }

        public void GenerateRecommendations()
        {
            var likedTracks = DatabaseManager.GetUserTracks(UserId, "like_list");
            var dislikedTracks = DatabaseManager.GetBlacklistedTracks(UserId);
            var ratedTracksInfo = DatabaseManager.GetUserRatings(UserId);

            List<Audio> ratedTracks = new List<Audio>();
            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                foreach (var ratedTrack in ratedTracksInfo)
                {
                    var audio = DatabaseManager.GetAudioById(ratedTrack.TrackId, connection);
                    if (audio != null)
                    {
                        ratedTracks.Add(audio);
                    }
                }
            }
            var preferences = AnalyzePreferences(likedTracks, dislikedTracks, ratedTracksInfo, ratedTracks);
            var allTracks = GetAllTracksFromDatabase();

            Recommendations = FilterTracks(allTracks, likedTracks, dislikedTracks, preferences);
            CurrentIndex = -1;
        }
        public List<Audio> GetAllTracksFromDatabase()
        {
            using var connection = new SQLiteConnection(DatabaseManager.ConnectionString);
            connection.Open();

            const string query = @"
            SELECT t.TrackID, m.*, p.* 
            FROM Tracks t
            JOIN Metadata m ON t.MetadataID = m.MetadataID
            JOIN Properties p ON t.PropertiesID = p.PropertiesID";

            var tracks = new List<Audio>();
            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tracks.Add(DatabaseManager.CreateAudioFromReader(reader));
                }
            }
            return tracks;
        }

        public Dictionary<string, double> AnalyzePreferences(List<Audio> likedTracks,List<Audio> dislikedTracks,List<(int TrackId, string Title, int Rating)> ratedTracksInfo, List<Audio> ratedTracks)
        {
            var preferences = new Dictionary<string, double>();
            if (likedTracks.Count > 0)
            {
                var avgLiked = CalculateAverageProperties(likedTracks);
                foreach (var prop in avgLiked)
                {
                    preferences[prop.Key] = prop.Value * 1.5;
                }
            }
            if (ratedTracks.Count > 0)
            {
                var avgRated = CalculateAverageProperties(ratedTracks);
                var avgRating = ratedTracksInfo.Average(r => r.Rating);
                var ratingWeight = avgRating / 10.0;

                foreach (var prop in avgRated)
                {
                    if (preferences.ContainsKey(prop.Key))
                        preferences[prop.Key] += prop.Value * ratingWeight;
                    else
                        preferences[prop.Key] = prop.Value * ratingWeight;
                }
            }
            if (dislikedTracks.Count > 0)
            {
                var avgDisliked = CalculateAverageProperties(dislikedTracks);
                foreach (var prop in avgDisliked)
                {
                    if (preferences.ContainsKey(prop.Key))
                        preferences[prop.Key] -= prop.Value * 0.5;
                }
            }
            return preferences;
        }

        public Dictionary<string, double> CalculateAverageProperties(List<Audio> tracks)
        {
            var properties = new Dictionary<string, double>();
            var count = tracks.Count;

            if (count == 0) return properties;

            var acousticness = tracks.Average(t => t.Properties.Acousticness ?? 0);
            var energy = tracks.Average(t => t.Properties.Energy ?? 0);
            var instrumentalness = tracks.Average(t => t.Properties.Instrumentalness ?? 0);
            var speechiness = tracks.Average(t => t.Properties.Speechiness ?? 0);
            var valence = tracks.Average(t => t.Properties.Valence ?? 0);
            var genres = tracks.GroupBy(t => t.Metadata.Genre).OrderByDescending(g => g.Count()).FirstOrDefault()?.Key;
            var artists = tracks.GroupBy(t => t.Metadata.Artist).OrderByDescending(g => g.Count()).FirstOrDefault()?.Key;
            var avgYear = tracks.Average(t => t.Metadata.ReleaseYear);

            properties.Add("Acousticness", acousticness);
            properties.Add("Energy", energy);
            properties.Add("Instrumentalness", instrumentalness);
            properties.Add("Speechiness", speechiness);
            properties.Add("Valence", valence);
            properties.Add("Genre", genres != null ? 1.0 : 0);
            properties.Add("Artist", artists != null ? 1.0 : 0);
            properties.Add("ReleaseYear", (double)avgYear);

            return properties;
        }


        public List<Audio> FilterTracks(List<Audio> allTracks, List<Audio> likedTracks, List<Audio> dislikedTracks, Dictionary<string, double> preferences)
        {
            var dislikedTrackIds = dislikedTracks.Select(t => t.ID).ToHashSet();
            var filteredTracks = allTracks.Where(t => !dislikedTrackIds.Contains(t.ID)).ToList();
            var scoredTracks = filteredTracks.Select(t => new
                {
                    Track = t,
                    Score = CalculateTrackScore(t, preferences)
                }).OrderByDescending(x => x.Score).Select(x => x.Track).ToList();

            return scoredTracks;
        }

        public double CalculateTrackScore(Audio track, Dictionary<string, double> preferences)
        {
            double score = 0;
            const double musicalWeight = 1.0;  
            const double metadataWeight = 0.7; 

            if (preferences.ContainsKey("Acousticness") && track.Properties.Acousticness.HasValue)
                score += (1 - Math.Abs(preferences["Acousticness"] - track.Properties.Acousticness.Value)) * musicalWeight;
            if (preferences.ContainsKey("Energy") && track.Properties.Energy.HasValue)
                score += (1 - Math.Abs(preferences["Energy"] - track.Properties.Energy.Value)) * musicalWeight;
            if (preferences.ContainsKey("Instrumentalness") && track.Properties.Instrumentalness.HasValue)
                score += 1 - Math.Abs(preferences["Instrumentalness"] - track.Properties.Instrumentalness.Value);
            if (preferences.ContainsKey("Speechiness") && track.Properties.Speechiness.HasValue)
                score += 1 - Math.Abs(preferences["Speechiness"] - track.Properties.Speechiness.Value);
            if (preferences.ContainsKey("Valence") && track.Properties.Valence.HasValue)
                score += 1 - Math.Abs(preferences["Valence"] - track.Properties.Valence.Value);
            if (preferences.ContainsKey("Genre") && !string.IsNullOrEmpty(track.Metadata.Genre))
                score += (track.Metadata.Genre.Equals(preferences["Genre"].ToString()) ? 1 : 0) * metadataWeight;
            if (preferences.ContainsKey("Artist") && !string.IsNullOrEmpty(track.Metadata.Artist))
                score += (track.Metadata.Artist.Equals(preferences["Artist"].ToString()) ? 1 : 0) * metadataWeight;
            if (preferences.ContainsKey("ReleaseYear"))
                score += (1 - Math.Min(1, Math.Abs((double)(preferences["ReleaseYear"] - track.Metadata.ReleaseYear)) / 50.0)) * 0.5;

            return score;
        }
        public Audio GetNextTrack()
        {
            if (Recommendations.Count == 0) return null;

            CurrentIndex = (CurrentIndex + 1) % Recommendations.Count;
            return Recommendations[CurrentIndex];
        }
        public Audio GetPreviousTrack()
        {
            if (Recommendations.Count == 0) return null;
            CurrentIndex = (CurrentIndex - 1 + Recommendations.Count) % Recommendations.Count;
            return Recommendations[CurrentIndex];
        }
        public Audio GetCurrentTrack()
        {
            if (CurrentIndex >= 0 && CurrentIndex < Recommendations.Count)
                return Recommendations[CurrentIndex];
            return null;
        }
    }
}
