using MediatR;
using MediatrTest.Injectables;
using MediatrTest.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatrTest.Handler
{
    public class AddHandler : IAsyncRequestHandler<AddRequest, IActionResult>
    {
        IContextExample context;
        IExampleRepository repository;
        IServiceExample service;

        public AddHandler(IContextExample context, IExampleRepository repository, IServiceExample service)
        {
            this.context = context;
            this.repository = repository;
            this.service = service;
        }

        public async Task<IActionResult> Handle(AddRequest message)
        {
            return new OkResult();
        }
    }
}
