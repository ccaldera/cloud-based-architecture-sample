using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ScalableTeams.HumanResourcesManagement.FunctionApp
{
    public class Endpoints
    {
        private readonly ILogger<Endpoints> _logger;

        public Endpoints(ILogger<Endpoints> logger)
        {
            _logger = logger;
        }

        [Function("Endpoints")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
