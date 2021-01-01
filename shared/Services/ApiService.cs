using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AdventOfCodeShared;

namespace AdventOfCodeShared.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<T> GetResult<T>(int day, int part){
            var response = await _http.GetAsync($"/Year/2020/{day}/{part}");
            return await response.Content.ReadFromJsonAsync<T>();
        }

    }
}
