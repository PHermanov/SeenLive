using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeenLive.Users;
using SeenLive.Visits;
using SeenLive.Visits.GetById;

namespace SeenLive.Api.Controllers;

[Route("api/visits")]
[ApiController]
[Authorize]
public class VisitsController
    : BaseController
{
    private readonly IMediator _mediator;
    
    public VisitsController(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, IMediator mediator) 
        : base(userManager, httpContextAccessor)
            => _mediator = mediator;
    
    // GET api/visits/5
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VisitViewModel>> GetById([FromRoute] GetVisitByIdQuery query)
    {
        var response = await _mediator.Send(query, HttpContext.RequestAborted);
        
        return response.Success
            ? Ok(response)
            : ProcessError(response.Error!);
    }
}