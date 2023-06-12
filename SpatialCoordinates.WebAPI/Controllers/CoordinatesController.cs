using SpatialCoordinates.Domain.CustomExceptions;
using SpatialCoordinates.Domain.DomainEntities;
using SpatialCoordinates.Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SpatialCoordinates.WebAPI.Controllers
{
    /// <summary>
    /// Actions to manage coordinates
    /// </summary>
    public class CoordinatesController : ApiController
    {
        private readonly ICoordinatesService _service;
        public CoordinatesController(ICoordinatesService service)
        {
            _service = service;
        }

        /// <summary>
        /// Action to register coordinates
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Register(List<decimal> coordinates)
        {
            if (coordinates.Count != 3)
            {
                return BadRequest("Only 3 coordinate list allowed");
            }

            Coordinates coords = new Coordinates
            {
                CoordX = coordinates[0],
                CoordY = coordinates[1],
                CoordZ = coordinates[2]
            };

            try
            {
                _service.Register(coords);

                return Ok();
            }

            catch (InvalidCoordXException ex)
            {
                return BadRequest($"Some problem found in X coordinate: {ex.Message}");
            }

            catch (CannotSaveDataException ex)
            {
                return BadRequest($"Some error occured while trying to save data: {ex.Message}");
            }

            catch (Exception)
            {
                return BadRequest($"Some unexpected error occured");
            }
        }
    }
}
