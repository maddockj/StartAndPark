using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Common.Requests
{
    public abstract class ApplicationRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, ApplicationRequestResult<TResponse>>
        where TRequest : IRequest<ApplicationRequestResult<TResponse>>
    {
        public abstract Task<ApplicationRequestResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);

        protected ApplicationRequestResult<TResponse> Success(TResponse response)
        {
            return ApplicationRequestResult.Success(response);
        }

        protected ApplicationRequestResult<TResponse> BadRequest()
        {
            return ApplicationRequestResult.BadRequest<TResponse>();
        }

        protected ApplicationRequestResult<TResponse> NotFound()
        {
            return ApplicationRequestResult.NotFound<TResponse>();
        }
    }

    public abstract class ApplicationRequestHandler<TRequest> : IRequestHandler<TRequest, ApplicationRequestResult>
        where TRequest : IRequest<ApplicationRequestResult>
    {
        public abstract Task<ApplicationRequestResult> Handle(TRequest request, CancellationToken cancellationToken);

        protected ApplicationRequestResult Success()
        {
            return ApplicationRequestResult.Success();
        }

        protected ApplicationRequestResult BadRequest()
        {
            return ApplicationRequestResult.BadRequest();
        }

        protected ApplicationRequestResult NotFound()
        {
            return ApplicationRequestResult.NotFound();
        }
    }
}
