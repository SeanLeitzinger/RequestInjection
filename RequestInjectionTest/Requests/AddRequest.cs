using Microsoft.AspNetCore.Mvc;
using RequestInjectionTest.Data;
using RequestInjectionTest.Data.Injectables;
using RequestInjectionTest.Data.Models;
using RequestInjector.NetCore;

namespace RequestInjectionTest.Requests
{
    public class AddRequest : IRequest, IRequestHandler<AddRequest, IActionResult>
    {
        public TestModel TestModel { get; set; }

        private readonly IContextExample context;
        private readonly IExampleRepository repository;
        private readonly IServiceExample service;
        private readonly RequestInjectionTestDbContext dbContext;

        public AddRequest()
        {

        }

        public AddRequest(IContextExample context, IExampleRepository repository, IServiceExample service, RequestInjectionTestDbContext dbContext)
        {
            this.context = context;
            this.repository = repository;
            this.service = service;
            this.dbContext = dbContext;
        }

        public IActionResult Handle()
        {
            return new OkResult();
        }
    }
}
