using MediatR;

namespace StartAndPark.Application.Common.Requests
{
    public interface IApplicationQuery<T> : IRequest<ApplicationRequestResult<T>>, IApplicationRequest
    {
    }
}
