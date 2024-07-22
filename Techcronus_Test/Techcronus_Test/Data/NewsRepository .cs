using Microsoft.Data.SqlClient;
using Techcronus_Test.Models;

namespace Techcronus_Test.DataLayer
{
    public class NewsRepository : INewsRepository
    {
        private readonly string _connectionString;

        public NewsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<NewsItemModel>> GetAllNewsAsync()
        {
            var newsItems = new List<NewsItemModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT Title, Abstract FROM NewsItems", connection);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        newsItems.Add(new NewsItemModel
                        {
                            Title = reader["Title"].ToString(),
                            Abstract = reader["Abstract"].ToString()
                        });
                    }
                }
            }
            return newsItems;
        }

        public async Task AddNewsAsync(NewsItemModel newsItem)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO NewsItems (Title, Abstract) VALUES (@Title, @Abstract)", connection);
                command.Parameters.AddWithValue("@Title", newsItem.Title);
                command.Parameters.AddWithValue("@Abstract", newsItem.Abstract);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
