using Cwiczenia9.Data;
using Cwiczenia9.ExtensionMethods;
using Cwiczenia9.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia9.Services;

public class TripService(MasterContext context) : ITripService
{
    public async Task<PagedResult<GetTripsResponseModel>> GetTrips(int page, int pageSize, CancellationToken cancellationToken)
    {
        var totalTrips = await context.Trips.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalTrips / (double)pageSize);

        var trips = await context.Trips
            .Select(trip => new GetTripsResponseModel
            {
                Name = trip.Name,
                Description = trip.Description,
                DateFrom = trip.DateFrom,
                DateTo = trip.DateTo,
                MaxPeople = trip.MaxPeople,
                Countries = trip.IdCountries.Select(country => new CountryDetails
                {
                    Name = country.Name
                }).ToList(),
                Clients = trip.ClientTrips.Select(clientTrip => new ClientDetails
                {
                    FirstName = clientTrip.IdClientNavigation.FirstName,
                    LastName = clientTrip.IdClientNavigation.LastName
                }).ToList()
            })
            .OrderByDescending(e => e.DateFrom)
            .Paginate(page, pageSize)
            .ToListAsync(cancellationToken);
        return new PagedResult<GetTripsResponseModel>
        {
            PageNum = page,
            PageSize = pageSize,
            AllPages = totalPages,
            Trips = trips
        };
    }
}