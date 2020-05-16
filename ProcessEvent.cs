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
    public class ProcessEvent
    {
        private readonly IEventClient _eventClient;
        public ProcessEvent(IEventClient eventClient)
        {
            _eventClient = eventClient;
        }

        [FunctionName("Process_Event")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            
            var responseMessage = await _eventClient.ProcessEvent(requestBody);

            return new OkObjectResult(responseMessage);
        }
    }
}
