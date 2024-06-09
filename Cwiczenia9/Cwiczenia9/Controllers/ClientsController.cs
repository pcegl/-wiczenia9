using Cwiczenia9.Exceptions;
using Cwiczenia9.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia9.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    [HttpDelete("{idClient:int}")]
    public async Task<IActionResult> RemoveClient(int idClient, IClientService service, CancellationToken cancellationToken)
    {
        try
        {
            await service.RemoveClient(idClient);
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (BadRequestException exception)
        {
            return BadRequest(exception.Message);
        }

        return NoContent();
    }
}