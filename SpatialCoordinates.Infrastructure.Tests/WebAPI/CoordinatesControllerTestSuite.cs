using Moq;
using SpatialCoordinates.Domain.CustomExceptions;
using SpatialCoordinates.Domain.DomainEntities;
using SpatialCoordinates.Domain.ServiceContracts;
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
        #region private controller initializers
        private CoordinatesController InitController()
        {
            CoordinatesController controller =
                new CoordinatesController(
                    new CoordinatesService(
                        new CoordinatesRepository()));

            return controller;
        }

        private CoordinatesController InitControllerWithMockedService()
        {
            Mock<ICoordinatesService> serviceMock = new Mock<ICoordinatesService>();
            serviceMock.Setup(x => x.Register(It.IsAny<Coordinates>()));

            ICoordinatesService mockedService = serviceMock.Object;

            return new CoordinatesController(mockedService);
        }
        #endregion

        #region Register action tests
        [Fact]
        public void IntegrationTest_Register_InputValid_ReturnsOkResult()
        {
            // Arrange
            CoordinatesController controller = InitController();
            List<decimal> values = new List<decimal> { 0, 0, 0 };

            // Act
            IHttpActionResult result = controller.Register(values);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputValid_ReturnsOkResult()
        {
            // Arrange
            CoordinatesController controller = InitControllerWithMockedService();
            List<decimal> values = new List<decimal> { 0, 0, 0 };

            // Act
            IHttpActionResult result = controller.Register(values);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputSizeZero_ReturnsBadRequestResult()
        {
            // Arrange
            CoordinatesController controller = InitControllerWithMockedService();
            List<decimal> values = new List<decimal>();

            // Act
            IHttpActionResult result = controller.Register(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputSizeMoreThanThree_ReturnsBadRequestResult()
        {
            // Arrange
            CoordinatesController controller = InitControllerWithMockedService();
            List<decimal> values = new List<decimal> { 0, 0, 0, 0, 0, 0, 0 };

            // Act
            IHttpActionResult result = controller.Register(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputValid_InvalidCoordXExceptionCaught_ReturnsBadRequest()
        {
            // Arrange
            Mock<ICoordinatesService> serviceMock = new Mock<ICoordinatesService>();
            serviceMock.Setup(x => x.Register(It.IsAny<Coordinates>())).Throws<InvalidCoordXException>();

            ICoordinatesService mockedService = serviceMock.Object;

            CoordinatesController controller = new CoordinatesController(mockedService);

            List<decimal> values = new List<decimal> { 0, 0, 0 };

            // Act
            IHttpActionResult result = controller.Register(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void UnitTest_Register_InputValid_CannotSaveDataExceptionCaught_ReturnsBadRequest()
        {
            // Arrange
            Mock<ICoordinatesService> serviceMock = new Mock<ICoordinatesService>();
            serviceMock.Setup(x => x.Register(It.IsAny<Coordinates>())).Throws<CannotSaveDataException>();

            ICoordinatesService mockedService = serviceMock.Object;

            CoordinatesController controller = new CoordinatesController(mockedService);

            List<decimal> values = new List<decimal> { 0, 0, 0 };

            // Act
            IHttpActionResult result = controller.Register(values);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }
        #endregion
    }
}
