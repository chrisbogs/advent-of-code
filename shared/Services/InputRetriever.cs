using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AdventOfCodeShared.Extensions;

namespace AdventOfCodeShared.Services
{
    public interface IInputRetriever
    {
        Task<string[]> GetInput(int year, int day);
    }

    public class InputRetriever : IInputRetriever
    {
        private readonly HttpClient _http;

        public InputRetriever(HttpClient? http = null)
        {
            _http = http ?? new HttpClient();
        }

        public async Task<string[]> GetInput(int year, int day)
        {
            var filePath = $"../shared/PuzzleInput/{year}/{day}.txt";
            try
            {
                return await filePath.ReadFile();
            }
            catch (Exception)
            {
                // We are running tests.
                filePath = $"../../../../shared/PuzzleInput/{year}/{day}.txt";
                return await filePath.ReadFile();
            }
        }
    }
}