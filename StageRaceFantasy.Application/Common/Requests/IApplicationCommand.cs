using MediatR;

namespace StageRaceFantasy.Application.Common.Requests
{
    public interface IApplicationCommand<T> : IRequest<ApplicationRequestResult<T>>, IApplicationRequest
    {
    }

    public interface IApplicationCommand : IRequest<ApplicationRequestResult>, IApplicationRequest
    {
    }
}
