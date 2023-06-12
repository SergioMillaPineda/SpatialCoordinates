using SpatialCoordinates.Domain.CustomExceptions;

namespace SpatialCoordinates.Domain.DomainEntities
{
    public class Coordinates
    {
        public decimal CoordX { get; set; }
        public decimal CoordY { get; set; }
        public decimal CoordZ { get; set; }

        public void Validate(Coordinates coords)
        {
            // validate CoordX
            if (false)
            {
                throw new InvalidCoordXException(CoordX.ToString());
            }

            // validate CoordY
            // validate CoordZ
        }
    }
}
