using Moq;
using RobotCleaner.Common.Entities;
using RobotCleaner.Domain.Interfaces;
using RobotCleaner.Entities;
using RobotCleaner.ServiceLibrary.Implementations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RobotCleaner.ServiceLibrary.Tests
{
    public class RobotLibraryShould
    {

        readonly Mock<IRobotService> mockRobotService;

        RobotLibrary robotLibrary;

        public RobotLibraryShould()
        {
            mockRobotService = new Mock<IRobotService>();
            robotLibrary = new RobotLibrary(mockRobotService.Object);
        }

        [Fact]
        public async Task SaveParameters_CallsExternalMethodsMatch_WhenGivenInputAsync()
        {
            var instructionsList = new Instructions()
            {
                MovementsList = new List<Movements>()
                {
                    new Movements()
                    {
                        Direction = new Direction(),
                        Steps = 50                        
                    }
                },
                StartCoordinates = new Coordinates()
            };

            mockRobotService.Setup(x => x.RunningThePlay(It.IsAny<Robot>()));

            //Act
            var result = await robotLibrary.RunningThePlayAsync(instructionsList);

            //Assert
            mockRobotService.Verify(x => x.RunningThePlay(It.IsAny<Robot>()), Times.Once);
        }
    }
}
