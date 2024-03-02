using Flashloan.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Channels;

namespace Flashloan.Bot.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenerController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public ScreenerController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet("stream/{chainNetwork}")]
        public async Task GetStream([FromRoute] string chainNetwork)
        {
            var screener = _serviceProvider.GetRequiredKeyedService<IScreenerProvider>(chainNetwork);
            var response = Response;
            response.Headers.Append("Content-Type", "text/event-stream");

            var channel = Channel.CreateUnbounded<string>();
            var writer = channel.Writer;

            using (screener.GetStream().Subscribe(
                onNext: data =>
                {
                    var sseFormattedData = $"data: {JsonConvert.SerializeObject(data)}\n\n";
                    writer.TryWrite(sseFormattedData);
                },
                onError: error =>
                {
                    writer.TryComplete(error);
                },
                onCompleted: () =>
                {
                    writer.TryComplete();
                }))
            {
                await foreach (var message in channel.Reader.ReadAllAsync())
                {
                    try
                    {
                        await response.WriteAsync(message);
                        await response.Body.FlushAsync();
                    }
                    catch (Exception ex)
                    {
                        // Log the error or handle it as needed
                        break; // Break out of the loop if the client disconnects or an error occurs
                    }
                }
            }
        }
    }
}
