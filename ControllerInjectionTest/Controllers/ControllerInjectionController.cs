using ControllerInjectionTest.Injectables;
using ControllerInjectionTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControllerInjectionTest.Controllers
{
    [Route("api/[controller]")]
    public class ControllerInjectionController : Controller
    {
        IContextExample context;
        IExampleRepository repository;
        IServiceExample service;

        public ControllerInjectionController(IContextExample context, IExampleRepository repository, IServiceExample service)
        {
            this.context = context;
            this.repository = repository;
            this.service = service;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            return new OkObjectResult("C# is love! C# is life!");
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TestModel model)
        {
            return new OkResult();
        }
    }
}
