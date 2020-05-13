using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Hollan.Function
{
    public class Update_Marketing
    {
        private readonly IMarketingClient _marketingClient;
        public Update_Marketing(IMarketingClient marketingClient)
        {
            _marketingClient = marketingClient;
        }

        [FunctionName("Update_Marketing")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            
            var responseMessage = await _marketingClient.AddNewLeadAsync(requestBody);

            return new OkObjectResult(responseMessage);
        }
    }
}
