using System;

namespace SpatialCoordinates.Domain.CustomExceptions
{
    public class InvalidCoordXException: Exception
    {
        public InvalidCoordXException(string message) : base(message) { }
    }
}
