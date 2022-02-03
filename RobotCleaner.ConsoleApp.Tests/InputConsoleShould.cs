using System;
using Xunit;
using Moq;
using RobotCleaner.ServiceLibrary.Interfaces;
using RobotCleaner.ConsoleApp.Implementations;
using RobotCleaner.ConsoleApp.Helpers.Interfaces;
using RobotCleaner.Entities;

namespace RobotCleaner.ConsoleApp.Tests
{
    public class InputConsoleShould
    {
        readonly Mock<IUserLibrary> mockUserLibrary;
        readonly Mock<IRobotLibrary> mockRobotLibrary;
        readonly Mock<IConsole> mockWrapperConsole;

        InputConsole inputConsole;

        public InputConsoleShould()
        {
            mockUserLibrary = new Mock<IUserLibrary>();
            mockRobotLibrary = new Mock<IRobotLibrary>();
            mockWrapperConsole = new Mock<IConsole>();
            inputConsole = new InputConsole(mockUserLibrary.Object, mockRobotLibrary.Object, mockWrapperConsole.Object);
        }

        [Fact]
        public void StartRobotCleanerAppAsync_CallsExternalMethodsMatch_WhenGivenInput()
        {
            mockWrapperConsole.SetupSequence(x => x.ReadLine())
                .Returns("2")
                .Returns("1 1")
                .Returns("E 10")
                .Returns("W 60");


            mockUserLibrary.Setup(x => x.SetStartParameters(It.IsAny<string[]>()));
            mockUserLibrary.Setup(x => x.SetMovements(It.IsAny<string[]>()));
            mockRobotLibrary.Setup(x => x.RunningThePlayAsync(It.IsAny<Instructions>())).ReturnsAsync(2);


            //Act
            var result = inputConsole.StartRobotCleanerAppAsync();

            //Assert
            mockUserLibrary.Verify(x => x.SetStartParameters(It.IsAny<string[]>()), Times.Once);
            mockUserLibrary.Verify(x => x.SetMovements(It.IsAny<string[]>()), Times.Exactly(2));
            mockRobotLibrary.Verify(x => x.RunningThePlayAsync(It.IsAny<Instructions>()), Times.Exactly(1));
        }

        [Fact]
        public void StartRobotCleanerAppAsync_CallsExternalMethodsMatch_WhenGivenInputNegative()
        {
            mockWrapperConsole.SetupSequence(x => x.ReadLine())
                .Returns("3")
                .Returns("-23 23")
                .Returns("E 10")
                .Returns("W 90").Returns("W 190");


            mockUserLibrary.Setup(x => x.SetStartParameters(It.IsAny<string[]>()));
            mockUserLibrary.Setup(x => x.SetMovements(It.IsAny<string[]>()));
            mockRobotLibrary.Setup(x => x.RunningThePlayAsync(It.IsAny<Instructions>())).ReturnsAsync(2);


            //Act
            var result = inputConsole.StartRobotCleanerAppAsync();

            //Assert
            mockUserLibrary.Verify(x => x.SetStartParameters(It.IsAny<string[]>()), Times.Once);
            mockUserLibrary.Verify(x => x.SetMovements(It.IsAny<string[]>()), Times.Exactly(3));
            mockRobotLibrary.Verify(x => x.RunningThePlayAsync(It.IsAny<Instructions>()), Times.Exactly(1));
        }
    }
}
