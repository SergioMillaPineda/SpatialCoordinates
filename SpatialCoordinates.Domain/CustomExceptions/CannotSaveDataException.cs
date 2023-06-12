using System;

namespace SpatialCoordinates.Domain.CustomExceptions
{
    public class CannotSaveDataException : Exception
    {
        public CannotSaveDataException(string message) : base(message) { }
    }
}
