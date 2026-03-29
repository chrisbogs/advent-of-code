using AdventOfCodeShared.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Server.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Server.Controllers
{
    /// <summary>
    /// Controller for retrieving Advent of Code puzzle solutions.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class YearController : ControllerBase
    {
        private readonly ISolutionService _solutionService;
        private readonly ILogger<YearController> _logger;

        /// <summary>
        /// Initializes a new instance of the YearController with dependency injection.
        /// </summary>
        [ActivatorUtilitiesConstructor]
        public YearController(ISolutionService solutionService, ILogger<YearController> logger)
        {
            _solutionService = solutionService ?? throw new ArgumentNullException(nameof(solutionService));
            _logger = logger;
        }

        /// <summary>
        /// Initializes a new instance of the YearController with just an input retriever.
        /// This constructor is deprecated and exists for backwards compatibility with tests.
        /// </summary>
        public YearController(IInputRetriever inputRetriever)
        {
            if (inputRetriever == null) throw new ArgumentNullException(nameof(inputRetriever));
            _solutionService = new SolutionService(inputRetriever, new NullLogger<SolutionService>());
            _logger = null;
        }

        /// <summary>
        /// Gets the solution for a specific puzzle.
        /// </summary>
        /// <param name="year">The puzzle year (2015-2025)</param>
        /// <param name="day">The puzzle day (1-25)</param>
        /// <param name="part">The puzzle part (1-2)</param>
        /// <response code="200">Returns the puzzle solution result</response>
        /// <response code="400">Invalid puzzle parameters (year must be 2015-2025, day 1-25, part 1-2)</response>
        /// <response code="404">Puzzle input file not found</response>
        /// <response code="500">Error computing the solution</response>
        [HttpGet("{year:int}/{day:int}/{part:int}")]
        [Produces("text/plain")]
        public async Task<ActionResult<string>> GetSolution(int year, int day, int part)
        {
            try
            {
                if (!_solutionService.IsValidPuzzle(year, day, part))
                {
                    _logger?.LogWarning("Invalid puzzle parameters: year={Year}, day={Day}, part={Part}", year, day, part);
                    return BadRequest(new { error = "Invalid puzzle parameters. Year must be 2015-2025, day 1-25, part 1-2." });
                }

                var result = await _solutionService.GetSolutionAsync(year, day, part);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                _logger?.LogWarning(ex, "Invalid argument for puzzle {Year}/{Day}/{Part}", year, day, part);
                return BadRequest(new { error = ex.Message });
            }
            catch (DirectoryNotFoundException ex)
            {
                _logger?.LogWarning(ex, "Input file not found for puzzle {Year}/{Day}", year, day);
                return NotFound(new { error = $"Puzzle input not available for {year} day {day}" });
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error retrieving solution for {Year}/{Day}/{Part}", year, day, part);
                return StatusCode(500, new { error = "Error computing the solution", details = ex.Message });
            }
        }

        /// <summary>
        /// Gets the solution for a specific puzzle (deprecated Router method for backwards compatibility).
        /// </summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet(Name = "Router")]
        public async Task<string> Router(int year, int day, int part)
        {
            try
            {
                var result = await GetSolution(year, day, part);
                if (result.Result is OkObjectResult okResult && okResult.Value is string solution)
                {
                    return solution;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
