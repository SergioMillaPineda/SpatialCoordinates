using Moq;
using SpatialCoordinates.Domain.DomainEntities;
using SpatialCoordinates.Domain.RepositoryContracts;
using SpatialCoordinates.Domain.ServiceImplementations;
using SpatialCoordinates.Infrastructure.Data.RepositoryImplementations;
using SpatialCoordinates.WebAPI.Controllers;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace SpatialCoordinates.Infrastructure.Tests.WebAPI
{
    public class CoordinatesControllerTestSuite
    {
        #region Register
        [Fact]
        public void IntegrationTest_Register_InputValid_ReturnsOkResult()
        {
            // Arrange
            CoordinatesController controller = new CoordinatesController(
                new CoordinatesService(
                    new CoordinatesRepository()
                    ));

            List<decimal> values = new List<decimal> { 0, 0, 0 };

            // Act
            IHttpActionResult result = controller.Register(values);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputValid_ReturnsOkResult()
        {
            // TODO smilla -> complete code with correct Mocking
            // Arrange
            Mock<CoordinatesService> serviceMock = new Mock<CoordinatesService>();
            serviceMock.Setup(x => x.Register(new Coordinates()
            {
                CoordX = 0,
                CoordY = 0,
                CoordZ = 0
            }));

            CoordinatesService mockedService = serviceMock.Object;
            CoordinatesController controller = new CoordinatesController(mockedService);

            List<decimal> values = new List<decimal> { 0, 0, 0 };

            // Act
            IHttpActionResult result = controller.Register(values);

            // Assert
            Assert.IsType<OkResult>(result);
        }
        #endregion
    }
}
