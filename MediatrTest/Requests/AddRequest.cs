using MediatR;
using Microsoft.AspNetCore.Mvc;
using RequestInjectionTest.Data.Models;

namespace MediatrTest.Requests
{
    public class AddRequest : IRequest<IActionResult>
    {
        public TestModel TestModel { get; set; }
    }
}
