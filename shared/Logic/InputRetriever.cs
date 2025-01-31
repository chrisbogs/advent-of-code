using AdventOfCodeShared.Extensions;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCodeShared.Logic
{
    public interface IInputRetriever
    {
        Task<string[]> GetInput(int year, int day);
        Task<string[]> GetInputFromUrl(string cookie, int year, int day);
    }

    public class InputRetriever : IInputRetriever
    {
        private readonly HttpClient _http;

        public InputRetriever(HttpClient http = null)
        {
            _http = http ?? new HttpClient();
        }

        public async Task<string[]> GetInput(int year, int day)
        {
            var filePath = Path.GetFullPath($"..\\shared\\PuzzleInput\\{year}\\{day}.txt");

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

        public async Task<string[]> GetInputFromUrl(string cookie, int year, int day)
        {
            _http.DefaultRequestHeaders.Add("Cookie", $"session={cookie}");

            var url = $"https://adventofcode.com/{year}/day/{day}/input";
            var response = await _http.GetAsync(url);

            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadAsStringAsync()).Split('\n');
        }
    }
}