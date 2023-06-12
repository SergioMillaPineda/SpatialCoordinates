using SpatialCoordinates.Domain.DomainEntities;

namespace SpatialCoordinates.Domain.RepositoryContracts
{
    public interface ICoordinatesRepository
    {
        void Insert(Coordinates coords);
    }
}
