using Microsoft.AspNetCore.Mvc;
using RequestInjectionTest.Injectables;
using System.Threading.Tasks;

namespace RequestInjectionTest.Requests
{
    public class GetTestRequest : IRequest, IRequestHandler<GetTestRequest, IActionResult>
    {
        public int Id { get; set; }

        IContextExample context;
        IExampleRepository repository;
        IServiceExample service;

        public GetTestRequest(IContextExample context, IExampleRepository repository, IServiceExample service)
        {
            this.context = context;
            this.repository = repository;
            this.service = service;
        }

        public async Task<IActionResult> Handle()
        {

            return new OkObjectResult("C# is love! C# is life!");
        }
    }
}
