using ControllerInjectionTest.Injectables;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControllerInjectionTest.Controllers
{
    [Route("api/[controller]")]
    public class ExtraInjectablesController : Controller
    {
        IContextExample context;
        IExampleRepository repository;
        IServiceExample service;
        IExtraInjectable1 extraInjecatable1;
        IExtraInjectable2 extraInjectable2;
        IExtraInjectable3 extraInjectable3;
        IExtraInjectable4 extraInjectable4;

        public ExtraInjectablesController(IContextExample context,
        IExampleRepository repository,
        IServiceExample service,
        IExtraInjectable1 extraInjecatable1,
        IExtraInjectable2 extraInjectable2,
        IExtraInjectable3 extraInjectable3,
        IExtraInjectable4 extraInjectable4)
        {
            this.context = context;
            this.repository = repository;
            this.service = service;
            this.extraInjecatable1 = extraInjecatable1;
            this.extraInjectable2 = extraInjectable2;
            this.extraInjectable3 = extraInjectable3;
            this.extraInjectable4 = extraInjectable4;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return new OkObjectResult("C# is love! C# is life!");
        }
    }
}
