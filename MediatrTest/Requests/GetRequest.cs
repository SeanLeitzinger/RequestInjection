using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatrTest.Requests
{
    public class GetRequest : IRequest<IActionResult>
    {
        public int Id { get; set; }
    }
}
