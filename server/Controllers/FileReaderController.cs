using AdventOfCodeShared.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileReaderController : ControllerBase
    {
        private readonly IInputRetriever inputRetriever;
        public FileReaderController(IInputRetriever inputRetriever)
        {
            this.inputRetriever = inputRetriever;
        }

        [HttpGet("{year:int}/{day:int}")]
        public Task<string[]> PuzzleInput(int year, int day)
        {
            return this.inputRetriever.GetInput(year, day);
        }
    }
}
