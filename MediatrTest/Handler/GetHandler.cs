using MediatR;
using MediatrTest.Requests;
using Microsoft.AspNetCore.Mvc;
using RequestInjectionTest.Data;
using RequestInjectionTest.Data.Injectables;

namespace MediatrTest.Handler
{
    public class GetHandler : RequestHandler<GetRequest, IActionResult>
    {
        private readonly IContextExample context;
        private readonly IExampleRepository repository;
        private readonly IServiceExample service;
        private readonly RequestInjectionTestDbContext dbContext;

        public GetHandler(IContextExample context, IExampleRepository repository, IServiceExample service, RequestInjectionTestDbContext dbContext)
        {
            this.context = context;
            this.repository = repository;
            this.service = service;
            this.dbContext = dbContext;
        }

        protected override IActionResult Handle(GetRequest request)
        {
            return new OkObjectResult("C# is love! C# is life!");
        }
    }
}