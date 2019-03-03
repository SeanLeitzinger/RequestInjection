using Microsoft.AspNetCore.Mvc;
using RequestInjectionTest.Data;
using RequestInjectionTest.Data.Injectables;
using RequestInjectionTest.Data.Models;

namespace ControllerInjectionTest.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ControllerInjectionController : Controller
    {
        private readonly IContextExample context;
        private readonly IExampleRepository repository;
        private readonly IServiceExample service;
        private readonly RequestInjectionTestDbContext dbContext;

        public ControllerInjectionController(IContextExample context, IExampleRepository repository, IServiceExample service, RequestInjectionTestDbContext dbContext)
        {
            this.context = context;
            this.repository = repository;
            this.service = service;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int id) => new OkObjectResult("C# is love! C# is life!");

        [HttpPost]
        public IActionResult Add([FromBody] TestModel model) => new OkResult();
    }
}
