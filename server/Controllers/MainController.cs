using AdventOfCodeShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using CMSRRUIContracts.WorkOrders;
using CMSRRUIContracts.General;
using Microsoft.Extensions.Options;

namespace Server
{

    [Route("api/[controller]")]
    [ApiController]
    public class MainController : Controller
    {
        private JsonSerializerOptions _jsonSerializerOptions;
        private HttpClient _http { get; set; }


        public MainController(HttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));

            // register this serialize on app startup so you don't need to specify it on every http call when deserializing
            _jsonSerializerOptions = new JsonSerializerOptions
            {
            };

            var c = new AdventOfCodeShared.Converters.DateTimeConverter { };
            _jsonSerializerOptions.Converters.Add(c);

        }

    }
}
