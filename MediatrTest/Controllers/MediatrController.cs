using MediatR;
using MediatrTest.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatrTest.Controllers
{
    [Route("api/[controller]")]
    public class MediatrController : Controller
    {
        readonly IMediator mediator;

        public MediatrController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetRequest request)
        {
            return await mediator.Send(request);
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
