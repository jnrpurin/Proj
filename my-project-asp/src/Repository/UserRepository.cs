using System.Data;
using System.Data.SqlClient;
using my_dotnet_core_project.Interfaces;
using my_dotnet_core_project.Models;
using my_dotnet_core_project.Services;

namespace my_dotnet_core_project.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserService> _logger;

        public UserRepository(IConfiguration configuration, ILogger<UserService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            }

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                await using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();

                string query = "SELECT id, name, username FROM users WHERE username = @username";

                await using var command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar) { Value = username });

                await using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new User
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Username = reader.GetString(reader.GetOrdinal("username"))
                    };
                }

                return null; // User not found
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "An error occurred while querying the database for username: {Username}", username);
                throw new Exception("An error occurred while accessing the database. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing the request.");
                throw;
            }
        }
    }
}