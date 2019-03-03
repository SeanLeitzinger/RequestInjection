using Microsoft.AspNetCore.Mvc;
using RequestInjectionTest.Data;
using RequestInjectionTest.Data.Injectables;

namespace ControllerInjectionTest.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ExtraInjectablesController : Controller
    {
        private readonly IContextExample context;
        private readonly IExampleRepository repository;
        private readonly IServiceExample service;
        private readonly IExtraInjectable1 extraInjecatable1;
        private readonly IExtraInjectable2 extraInjectable2;
        private readonly IExtraInjectable3 extraInjectable3;
        private readonly IExtraInjectable4 extraInjectable4;
        private readonly RequestInjectionTestDbContext dbContext;

        public ExtraInjectablesController(IContextExample context,
        IExampleRepository repository,
        IServiceExample service,
        IExtraInjectable1 extraInjecatable1,
        IExtraInjectable2 extraInjectable2,
        IExtraInjectable3 extraInjectable3,
        IExtraInjectable4 extraInjectable4,
        RequestInjectionTestDbContext dbContext)
        {
            this.context = context;
            this.repository = repository;
            this.service = service;
            this.extraInjecatable1 = extraInjecatable1;
            this.extraInjectable2 = extraInjectable2;
            this.extraInjectable3 = extraInjectable3;
            this.extraInjectable4 = extraInjectable4;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return new OkObjectResult("C# is love! C# is life!");
        }
    }
}
