using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Aspose.Imaging.ImageOptions;
using BlobTriggerTest;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
namespace BlobTriggers
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(Function1))]
        public async Task Run([BlobTrigger("images/{name}", Connection = "AzureWebJobsStorage")] Stream stream, string name, FunctionContext context)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            //_logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");

            var metadata = context.BindingContext.BindingData;

            if (metadata.TryGetValue("Uri", out var blobUri))
            {
                _logger.LogInformation($"Blob Uri");
            }

            if (metadata.TryGetValue("Properties", out var properties))
            {
                var infoObj = JsonConvert.DeserializeObject<BlobItemInfo>(properties.ToString());
                _logger.LogInformation($"{infoObj?.LastModified}");
            }


        }


        [Function("OutputFunction")]
        [BlobOutput("images-original/{name}", Connection = "AzureWebJobsStorage")]
        public byte[] RunOut(
    [BlobTrigger("images/{name}", Connection = "AzureWebJobsStorage")] byte[] inputBytes,
    string name)
        {
            _logger.LogInformation("Triggered OutputFunction for: {name}", name);

            if (name.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
            {
                using (var inputStream = new MemoryStream(inputBytes))
                using (var image = Aspose.Imaging.Image.Load(inputStream))
                {
                    var exportOptions = new Aspose.Imaging.ImageOptions.JpegOptions();

                    using (var outputStream = new MemoryStream())
                    {
                        image.Save(outputStream, exportOptions);
                        return outputStream.ToArray();


                    }
                }
            }

            return null;
        }

    }
}
