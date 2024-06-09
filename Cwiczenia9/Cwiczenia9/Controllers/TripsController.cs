using Cwiczenia9.Data;
using Cwiczenia9.ResponseModels;
using Cwiczenia9.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia9.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    [HttpGet]
    public async Task<PagedResult<GetTripsResponseModel>> GetTrips(ITripService service, 
        CancellationToken cancellationToken, int page = 1, int pageSize = 10)
    {
        return await service.GetTrips(page, pageSize, cancellationToken);
    }
    
}