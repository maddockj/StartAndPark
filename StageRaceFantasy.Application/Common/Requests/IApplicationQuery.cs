using MediatR;

namespace StageRaceFantasy.Application.Common.Requests
{
    public interface IApplicationQuery<T> : IRequest<ApplicationRequestResult<T>>, IApplicationRequest
    {
    }
}
