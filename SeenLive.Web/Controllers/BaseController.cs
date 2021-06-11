using Microsoft.AspNetCore.Mvc;
using SeenLive.Infrastructure;

namespace SeenLive.Api.Controllers
{
    public class BaseController
        : ControllerBase
    {
        public ActionResult ProcessError(Error error)
            => error.Type switch
            {
                ErrorType.NotFound => NotFound(),
                _ => Problem()
            };
    }
}
