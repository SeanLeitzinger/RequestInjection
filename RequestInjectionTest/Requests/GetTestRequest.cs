using Microsoft.AspNetCore.Mvc;
using RequestInjectionTest.Data;
using RequestInjectionTest.Data.Injectables;
using RequestInjector.NetCore;

namespace RequestInjectionTest.Requests
{
    public class GetTestRequest : IRequest, IRequestHandler<GetTestRequest, IActionResult>
    {
        public int Id { get; set; }

        private readonly IContextExample context;
        private readonly IExampleRepository repository;
        private readonly IServiceExample service;
        private readonly RequestInjectionTestDbContext dbContext;

        public GetTestRequest()
        {

        }

        public GetTestRequest(IContextExample context, IExampleRepository repository, IServiceExample service, RequestInjectionTestDbContext dbContext)
        {
            this.context = context;
            this.repository = repository;
            this.service = service;
            this.dbContext = dbContext;
        }

        public IActionResult Handle()
        {
            return new OkObjectResult("C# is love! C# is life!");
        }
    }
}
