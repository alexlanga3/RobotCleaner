using RobotCleaner.Common.Entities;
using RobotCleaner.Domain.Implementations;
using RobotCleaner.Entities;
using System.Collections.Generic;
using Xunit;

namespace RobotCleaner.Domain.Tests
{
    public class RobotServiceShould
    {
        RobotService robotService;

        public RobotServiceShould()
        {
            robotService = new RobotService();
        }

        [Fact]
        public void RunningThePlay_ReturnsRoomsCleaned_WhenGivenSameRoomInput()
        {
            var testRobot = new Robot()
            {
                MovementsList = new List<Movements>()
                {
                    new Movements()
                    {
                        Direction = Direction.North,
                        Steps = 199
                    }
                },
                StartCoordinates = new Coordinates()
                {
                    CoordinateX = 50,
                    CoordinateY = 20
                }
            };

            //Act
            var result = robotService.RunningThePlay(testRobot).Result;

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void RunningThePlay_ReturnsRoomsCleaned_WhenGivenNextDoorRoomInput()
        {
            var testRobot = new Robot()
            {
                MovementsList = new List<Movements>()
                {
                    new Movements()
                    {
                        Direction = Direction.West,
                        Steps = 199
                    }
                },
                StartCoordinates = new Coordinates()
                {
                    CoordinateX = 1,
                    CoordinateY = 1
                }
            };

            //Act
            var result = robotService.RunningThePlay(testRobot).Result;

            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void RunningThePlay_ReturnsRoomsCleaned_WhenGivenAllRoomsInput()
        {
            var testRobot = new Robot()
            {
                MovementsList = new List<Movements>()
                {
                    new Movements()
                    {
                        Direction = Direction.West,
                        Steps = 20
                    },
                    new Movements()
                    {
                        Direction = Direction.South,
                        Steps = 200
                    },
                      new Movements()
                    {
                        Direction = Direction.East,
                        Steps = 400
                    }
                },
                StartCoordinates = new Coordinates()
                {
                    CoordinateX = 1,
                    CoordinateY = 1
                }
            };

            //Act
            var result = robotService.RunningThePlay(testRobot).Result;

            //Assert
            Assert.Equal(4, result);
        }
    }
}
