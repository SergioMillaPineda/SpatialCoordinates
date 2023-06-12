using SpatialCoordinates.Domain.DomainEntities;

namespace SpatialCoordinates.Domain.ServiceContracts
{
    public interface ICoordinatesService
    {
        void Register(Coordinates coords);
    }
}
