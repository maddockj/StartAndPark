using MediatR;

namespace StageRaceFantasy.Application.Common.Requests
{
    interface IApplicationQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, ApplicationRequestResult<TResponse>>
        where TRequest : IRequest<ApplicationRequestResult<TResponse>>
    {
    }
}
