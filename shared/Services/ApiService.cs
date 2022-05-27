using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdventOfCodeShared.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<T> GetResult<T>(int day, int part)
        {
            var response = await _http.GetAsync($"/Year/2020/{day}/{part}");
            try
            {
                return await response.Content.ReadFromJsonAsync<T>() ?? default!;
            }
            catch (Exception)
            {
                return default!;
            }
        }
    }
}
