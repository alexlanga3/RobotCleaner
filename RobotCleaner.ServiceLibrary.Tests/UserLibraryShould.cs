using Moq;
using RobotCleaner.Common.Entities;
using RobotCleaner.Domain.Interfaces;
using RobotCleaner.ServiceLibrary.Implementations;
using System;
using Xunit;

namespace RobotCleaner.ServiceLibrary.Tests
{
    public class UserLibraryShould
    {

        readonly Mock<IUserService> mockUserService;

        UserLibrary userLibrary;

        public UserLibraryShould()
        {
            mockUserService = new Mock<IUserService>();
            userLibrary = new UserLibrary(mockUserService.Object);
        }

        [Fact]
        public void SaveParameters_CallsExternalMethodsMatch_WhenGivenInput()
        {
            var movementsArray = new string[2] {"N","50"};

            mockUserService.Setup(x => x.SaveParameters(It.IsAny<Movements>()));

            //Act
            userLibrary.SetMovements(movementsArray);

            //Assert
            mockUserService.Verify(x => x.SaveParameters(It.IsAny<Movements>()), Times.Once);

        }

        [Fact]
        public void SetStartParameters_CallsExternalMethodsMatch_WhenGivenInput()
        {
            var movementsArray = new string[2] { "N", "50" };

            mockUserService.Setup(x => x.SaveMovements(It.IsAny<Coordinates>()));

            //Act
            userLibrary.SetMovements(movementsArray);

            //Assert
            mockUserService.Verify(x => x.SaveMovements(It.IsAny<Coordinates>()), Times.Once);

        }
    }
}
