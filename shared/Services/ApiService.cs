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

        public async Task<int> Day1Part1(){
            var response = await _http.GetAsync("/Day1/1");
            return await response.Content.ReadFromJsonAsync<int>();
        }
        public async Task<int> Day1Part2(){
            var response = await _http.GetAsync("/Day1/2");
            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}
