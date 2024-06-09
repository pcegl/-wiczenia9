using Cwiczenia9.ResponseModels;

namespace Cwiczenia9.Services;

public interface ITripService
{
    public Task<PagedResult<GetTripsResponseModel>> GetTrips(int page, int pageSize, CancellationToken cancellationToken);
}