using MediatR;
using MediatrTest.Injectables;
using MediatrTest.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatrTest.Handler
{
    public class GetHandler : IAsyncRequestHandler<GetRequest, IActionResult>
    {
        IContextExample context;
        IExampleRepository repository;
        IServiceExample service;

        public GetHandler(IContextExample context, IExampleRepository repository, IServiceExample service)
        {
            this.context = context;
            this.repository = repository;
            this.service = service;
        }

        public async Task<IActionResult> Handle(GetRequest message)
        {
            return new OkObjectResult("C# is love! C# is life!");
        }
    }
}