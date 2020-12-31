using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AdventOfCodeShared;
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
        private string? testFilePath;

        public InputRetriever(HttpClient http, string? testFilePath=null)
        {
            _http = http;
            this.testFilePath = testFilePath;
        }

        public async Task<string[]> GetInput(int year, int day)
        {
            var filePath = testFilePath ?? $"../shared/PuzzleInput/{year}/{day}.txt";
            return await filePath.ReadFile();
        }
    }
}