using Microsoft.AspNetCore.Mvc;
using RequestInjectionTest.Requests;
using System.Threading.Tasks;

namespace RequestInjectionTest.Controllers
{
    [Route("api/[controller]")]
    public class RequestInjectionController : Controller
    {
        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetTestRequest request)
        {
            return await request.Handle();
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddRequest request)
        {
            return await request.Handle();
        }
    }
}
