using MediatR;
using MediatrTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediatrTest.Requests
{
    public class AddRequest : IRequest<IActionResult>
    {
        public TestModel TestModel { get; set; }
    }
}
