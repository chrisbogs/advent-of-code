using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCodeShared.Logic
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> GetResult(int year, int day, int part)
        {
            var response = await _http.GetAsync($"/Year/{year}/{day}/{part}");
            try
            {
                return await response.Content.ReadAsStringAsync() ?? default!;
            }
            catch (Exception)
            {
                return default!;
            }
        }
    }
}
