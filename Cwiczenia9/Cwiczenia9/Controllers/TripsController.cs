using Cwiczenia9.Data;
using Cwiczenia9.Exceptions;
using Cwiczenia9.RequestModels;
using Cwiczenia9.ResponseModels;
using Cwiczenia9.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia9.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTrips(ITripService service, 
        CancellationToken cancellationToken, int page = 1, int pageSize = 10)
    {
        return Ok(await service.GetTrips(page, pageSize, cancellationToken));
    }

    [HttpPost("{idTrip:int}/clients")]
    public async Task<IActionResult> AssignClientToTrip(int idTrip, AssignAClientToTheTripRequestModel requestModel, ITripService service, 
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(requestModel);
        }
        
        try
        {
            await service.AssignAClientToTheTripAsync(idTrip, requestModel, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }

        
    }
}