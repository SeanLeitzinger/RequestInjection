using Microsoft.AspNetCore.Mvc;
using RequestInjectionTest.Requests;

namespace RequestInjectionTest.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RequestInjectionController : Controller
    {
        [HttpGet]
        public IActionResult Get([FromQuery][FromServices] GetTestRequest request) => request.Handle();

        [HttpPost]
        public IActionResult Add([FromBody][FromServices] AddRequest request) => request.Handle();
    }
}
