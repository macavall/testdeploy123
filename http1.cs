using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;

namespace TestFunc
{
    public class http1
    {
        private readonly ILogger<http1> _logger;

        public http1(ILogger<http1> logger)
        {
            _logger = logger;
        }

        [Function("http1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            for(int i = 0; i < Convert.ToInt32(Environment.GetEnvironmentVariable("loopCount")); i++)
            {
                _logger.LogInformation("C# HTTP trigger function processed a request." + DateTime.UtcNow.Ticks);
            }
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
