using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using UserApp.Models;

namespace UserApp.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserResponse> GetUsersAsync(int page = 1, int results = 100, string seed = "e587a5c809495696", string version = "1.4")
        {
            var url = $"https://randomuser.me/api/?seed={seed}&results={results}&page={page}&version={version}";

            var response = await _httpClient.GetStringAsync(url);

            var users = JsonConvert.DeserializeObject<UserResponse>(response);

            return users ?? new UserResponse();
        }

        public async Task<User> GetUserAsync(string uuid)
        {
            var response = await _httpClient.GetStringAsync($"https://randomuser.me/api/?uuid={uuid}&seed=abc");
            var userResponse = JsonConvert.DeserializeObject<UserResponse>(response);

            throw new Exception("No se pudo encontrar el usuario.");
        }
    }

    public class UserResponse
    {
        public User[] Results { get; set; }
        public Info Info { get; set; }
    }

    public class Info
    {
        public string Seed { get; set; }
        public int Results { get; set; }
        public int Page { get; set; }
        public string Version { get; set; }
    }

}
