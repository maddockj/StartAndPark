using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Application.Common.Requests;
using System;
using System.Linq;

namespace StageRaceFantasy.Server.Controllers.Utils
{
    public static class ResponseHelpers
    {
        public static ActionResult<T> BuildRawContentResponse<T>(ControllerBase controller, ApplicationRequestResult<T> requestResult)
        {
            if (!RequestResultIsValid(controller, requestResult, out var actionResult))
            {
                return actionResult;
            }

            return requestResult.Content;
        }

        public static ActionResult BuildNoContentResponse(ControllerBase controller, ApplicationRequestResult requestResult)
        {
            if (!RequestResultIsValid(controller, requestResult, out var actionResult))
            {
                return actionResult;
            }

            return controller.NoContent();
        }

        public static ActionResult<T> BuildCreatedAtResponse<T>(ControllerBase controller,
                                                                ApplicationRequestResult<T> requestResult,
                                                                string actionName,
                                                                Func<object> buildRouteValues)
        {
            if (!RequestResultIsValid(controller, requestResult, out var actionResult))
            {
                return actionResult;
            }

            var routeValues = buildRouteValues();
            return controller.CreatedAtAction(actionName, routeValues, requestResult.Content);
        }

        public static ActionResult BuildStatusCodeResponse(ControllerBase controller,
                                                         ApplicationRequestResult requestResult,
                                                         int statusCode)
        {
            if (!RequestResultIsValid(controller, requestResult, out var actionResult))
            {
                return actionResult;
            }

            return controller.StatusCode(statusCode);
        }

        private static bool RequestResultIsValid<T>(ControllerBase controller,
                                                    ApplicationRequestResult<T> requestResult,
                                                    out ActionResult<T> actionResult)
        {
            if (requestResult.IsBadRequest)
            {
                actionResult = BuildBadRequestResponse(controller, requestResult);
                return false;
            }

            if (requestResult.IsNotFound)
            {
                actionResult = controller.NotFound();
                return false;
            }

            actionResult = null;
            return true;
        }

        private static bool RequestResultIsValid(ControllerBase controller,
                                                 ApplicationRequestResult requestResult,
                                                 out ActionResult actionResult)
        {
            if (requestResult.IsBadRequest)
            {
                actionResult = BuildBadRequestResponse(controller, requestResult);
                return false;
            }

            if (requestResult.IsNotFound)
            {
                actionResult = controller.NotFound();
                return false;
            }

            actionResult = null;
            return true;
        }

        private static ActionResult<T> BuildBadRequestResponse<T>(ControllerBase controller, ApplicationRequestResult<T> requestResult)
        {
            return requestResult.ValidationFailures.Any() ?
                    controller.BadRequest(requestResult.ValidationFailures) :
                    controller.BadRequest();
        }

        private static ActionResult BuildBadRequestResponse(ControllerBase controller, ApplicationRequestResult requestResult)
        {
            return requestResult.ValidationFailures.Any() ?
                    controller.BadRequest(requestResult.ValidationFailures) :
                    controller.BadRequest();
        }
    }
}
