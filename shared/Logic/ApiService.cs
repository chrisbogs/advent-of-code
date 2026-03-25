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
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }

        public async Task<string> GetResult(int year, int day, int part)
        {
            if (year < 2015 || year > 2025)
                throw new ArgumentOutOfRangeException(nameof(year), "Year must be between 2015 and 2025");
            if (day < 1 || day > 25)
                throw new ArgumentOutOfRangeException(nameof(day), "Day must be between 1 and 25");
            if (part != 1 && part != 2)
                throw new ArgumentOutOfRangeException(nameof(part), "Part must be 1 or 2");

            try
            {
                var response = await _http.GetAsync($"/Year/{year}/{day}/{part}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"HTTP {response.StatusCode}: {response.ReasonPhrase}");
                }

                var content = await response.Content.ReadAsStringAsync();
                return content ?? string.Empty;
            }
            catch (HttpRequestException ex)
            {
                throw new ApiException($"Failed to fetch result for {year} day {day} part {part}", ex);
            }
            catch (Exception ex)
            {
                throw new ApiException($"Unexpected error fetching result for {year} day {day} part {part}", ex);
            }
        }
    }

    public class ApiException : Exception
    {
        public ApiException(string message) : base(message) { }
        public ApiException(string message, Exception innerException) : base(message, innerException) { }
    }
}
