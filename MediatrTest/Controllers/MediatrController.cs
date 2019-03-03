using MediatR;
using MediatrTest.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatrTest.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MediatrController : Controller
    {
        readonly IMediator mediator;

        public MediatrController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetRequest request) => await mediator.Send(request);

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddRequest request) => await mediator.Send(request);
    }
}
