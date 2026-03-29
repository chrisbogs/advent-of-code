using AdventOfCodeShared.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Server.Controllers
{
    /// <summary>
    /// Controller for retrieving raw puzzle input files.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FileReaderController(IInputRetriever inputRetriever, ILogger<FileReaderController> logger) : ControllerBase
    {
        private readonly IInputRetriever _inputRetriever = inputRetriever;
        private readonly ILogger<FileReaderController> _logger = logger;

        /// <summary>
        /// Gets the puzzle input for a specific year and day.
        /// </summary>
        /// <param name="year">The puzzle year (2015-2025)</param>
        /// <param name="day">The puzzle day (1-25)</param>
        /// <response code="200">Returns the puzzle input lines</response>
        /// <response code="404">Puzzle input file not found</response>
        /// <response code="500">Error reading the puzzle input</response>
        [HttpGet("{year:int}/{day:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<string[]>> GetPuzzleInput(int year, int day)
        {
            try
            {
                if (year < 2015 || year > 2025 || day < 1 || day > 25)
                {
                    _logger.LogWarning("Invalid input parameters: year={Year}, day={Day}", year, day);
                    return BadRequest(new { error = "Invalid parameters. Year must be 2015-2025, day 1-25." });
                }

                _logger.LogInformation("Retrieving puzzle input for {Year} day {Day}", year, day);
                var input = await _inputRetriever.GetInput(year, day);
                return Ok(input);
            }
            catch (DirectoryNotFoundException ex)
            {
                _logger.LogWarning(ex, "Input file not found for {Year} day {Day}", year, day);
                return NotFound(new { error = $"Puzzle input not available for {year} day {day}" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving puzzle input for {Year} day {Day}", year, day);
                return StatusCode(500, new { error = "Error reading puzzle input", details = ex.Message });
            }
        }
    }
}
