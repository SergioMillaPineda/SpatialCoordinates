using SpatialCoordinates.Domain.ServiceImplementations;
using SpatialCoordinates.Infrastructure.Data.RepositoryImplementations;
using Xunit;
using SpatialCoordinates.Domain.DomainEntities;

namespace SpatialCoordinates.Infrastructure.Tests.Domain
{
    public class CoordinatesServiceTestSuite
    {
        [Fact]
        public void IntegrationTest_Register_InputValid_ReturnsVoid()
        {
            // Arrange
            CoordinatesService service = new CoordinatesService(
                new CoordinatesRepository()
            );

            Coordinates input = new Coordinates
            {
                CoordX = 1,
                CoordY = 1,
                CoordZ = 1
            };

            // Act
            var exception = Record.Exception(() => service.Register(input));

            // Assert
            Assert.Null(exception);
        }
    }
}
