using SpatialCoordinates.Domain.CustomExceptions;
using SpatialCoordinates.Domain.DomainEntities;
using SpatialCoordinates.Domain.RepositoryContracts;
using SpatialCoordinates.Domain.ServiceContracts;
using System;

namespace SpatialCoordinates.Domain.ServiceImplementations
{
    public class CoordinatesService : ICoordinatesService
    {
        private readonly ICoordinatesRepository _repository;
        public CoordinatesService(ICoordinatesRepository rep)
        {
            _repository = rep;
        }
        public void Register(Coordinates coords)
        {
            coords.Validate(coords);

            try
            {
                _repository.Insert(coords);
            }
            catch (Exception ex)
            {
                throw new CannotSaveDataException(ex.Message);
            }
        }
    }
}
