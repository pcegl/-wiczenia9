using Cwiczenia9.Data;
using Cwiczenia9.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia9.Services;

public class ClientService(MasterContext context) : IClientService
{
    public async Task RemoveClient(int idClient)
    {
        var assignedTrips = await context.ClientTrips.Where(e => e.IdClient == idClient).ToListAsync();

        if (assignedTrips.Count != 0)
        {
            throw new BadRequestException($"Cannot remove client object with id:{idClient}, because it is assigned to one or more trips");
        }

        var affectedRows = await context.Clients.Where(e => e.IdClient == idClient).ExecuteDeleteAsync();
        await context.SaveChangesAsync(); 

        if (affectedRows == 0)
        {
            throw new NotFoundException($"Client with id:{idClient} does not exist");
        }
    }
}