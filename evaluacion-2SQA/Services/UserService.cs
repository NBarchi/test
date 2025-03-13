using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using UserApp.Models;

namespace UserApp.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://randomuser.me/api/";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsersAsync(int page, int pageSize)
        {
            try
            {
                string apiUrl = $"https://randomuser.me/api/?page={page}&results={pageSize}&seed=abc";

                var response = await _httpClient.GetStringAsync(apiUrl);
                var usersResponse = JsonSerializer.Deserialize<UserResponse>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return usersResponse?.Results ?? new List<User>(); // Evita retornar null
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener usuarios: {ex.Message}");
                return new List<User>(); // Retorna una lista vacía en caso de error
            }
        }
    }
}
