using Infrastructure.IA;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class IAController : ControllerBase
    {
        private IAService _service { get; set; }
        public IAController(ILogger<IAController> logger,
            IAService service) : base()
        {
            _service = service;
        }

        [HttpGet("/chat")]
        public async Task<string> GetById([FromQuery] string prompt)
        {
            return await _service.Chat(prompt);
        }
    }
}