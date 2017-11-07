using Microsoft.AspNetCore.Mvc;
using RequestInjectionTest.Injectables;
using RequestInjectionTest.Models;
using System.Threading.Tasks;

namespace RequestInjectionTest.Requests
{
    public class AddRequest : IRequest, IRequestHandler<AddRequest, IActionResult>
    {
        public TestModel TestModel { get; set; }

        IContextExample context;
        IExampleRepository repository;
        IServiceExample service;

        public AddRequest(IContextExample context, IExampleRepository repository, IServiceExample service)
        {
            this.context = context;
            this.repository = repository;
            this.service = service;
        }

        public async Task<IActionResult> Handle()
        {
            return new OkResult();
        }
    }
}
