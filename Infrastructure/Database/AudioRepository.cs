using Microsoft.Data.Sqlite;
using AudioProcessingService.Core.Models;

namespace AudioProcessingService.Infrastructure.Database
{
    public class AudioRepository
    {
        private readonly string _connectionString = "Data Source=audio.db";

        public AudioRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS AudioFeatures (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                FileName TEXT,
                Duration REAL,
                SampleRate INTEGER
            );
            """;

            command.ExecuteNonQuery();
        }

        public void Save(AudioMetadata audio)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            """
            INSERT INTO AudioFeatures (FileName, Duration, SampleRate)
            VALUES ($fileName, $duration, $sampleRate);
            """;

            command.Parameters.AddWithValue("$fileName", audio.FileName);
            command.Parameters.AddWithValue("$duration", audio.Duration);
            command.Parameters.AddWithValue("$sampleRate", audio.SampleRate);

            command.ExecuteNonQuery();
        }
    }
}
