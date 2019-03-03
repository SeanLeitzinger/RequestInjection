using System.Threading.Tasks;

namespace RequestInjectionTest.Requests
{
    public interface IRequestHandlerAsync<request, response>
    {
        Task<response> HandleAsync();
    }

    public interface IRequestHandlerAsync<request>
    {
        Task HandleAsync();
    }

    public interface IRequestHandler<request, response>
    {
        response Handle();
    }

    public interface IRequestHandler<request>
    {
        void Handle();
    }
}
