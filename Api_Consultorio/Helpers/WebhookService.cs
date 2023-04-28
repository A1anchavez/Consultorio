using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using ExecutionContext = Microsoft.Azure.WebJobs.ExecutionContext;

namespace Api_Consultorio.Helpers
{
    public class WebhookService
    {
        private static ILogger _logger = null;

        [FunctionName("Webhook")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route=null)] HttpRequest req,
            ILogger log,
            ExecutionContext context)
        {
            _logger = log;

            PrintLogHeader();

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            PrintLogPayload(data);

            return new OkResult();

        }
        private static void PrintLogHeader()
        {
            _logger.LogInformation("=================================");
            _logger.LogInformation("SaaS Webhook funcion disparandose");
        }
        private static void PrintLogPayload(dynamic data)
        {
            _logger.LogInformation("-------------------------------------");
            _logger.LogInformation($"ACTION: {data.action}");
            _logger.LogInformation("-------------------------------------");
            _logger.LogInformation((string)data.ToString());
        }
    }
}
