using MediatR;
using MediatrTest.Requests;
using Microsoft.AspNetCore.Mvc;
using RequestInjectionTest.Data;
using RequestInjectionTest.Data.Injectables;

namespace MediatrTest.Handler
{
    public class AddHandler : RequestHandler<AddRequest, IActionResult>
    {
        private readonly IContextExample context;
        private readonly IExampleRepository repository;
        private readonly IServiceExample service;
        private readonly RequestInjectionTestDbContext dbContext;

        public AddHandler(IContextExample context, IExampleRepository repository, IServiceExample service, RequestInjectionTestDbContext dbContext)
        {
            this.context = context;
            this.repository = repository;
            this.service = service;
            this.dbContext = dbContext;
        }

        protected override IActionResult Handle(AddRequest request)
        {
            return new OkResult();
        }
    }
}
