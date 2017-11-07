using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestInjectionTest.Requests
{
    public interface IRequestHandler<request, response>
    {
        Task<response> Handle();
    }

    public interface IRequestHandler<request>
    {
        Task Handle();
    }
}
