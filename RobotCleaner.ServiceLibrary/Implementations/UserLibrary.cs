using Microsoft.Extensions.Logging;
using RobotCleaner.Common.Entities;
using RobotCleaner.Domain.Interfaces;
using RobotCleaner.Entities;
using RobotCleaner.ServiceLibrary.Interfaces;
using System;

namespace RobotCleaner.ServiceLibrary.Implementations
{
    public class UserLibrary : IUserLibrary
    {
        /// <summary>
        /// User service init.
        /// </summary>
        private readonly IUserService _userService;

        public UserLibrary(IUserService userService)
        {
            _userService = userService;
        }

        public void SetMovements(string[] coordinates)
        {
            var parametersEntity = new Movements()
            {
                Direction = AssignDirection(coordinates[0]),
                Steps = Int32.Parse(coordinates[1])
            };

            _userService.SaveParameters(parametersEntity);
        }

        public void SetStartParameters(string[] parameters)
        {
            var coordinatesEntity = new Coordinates()
            {
                CoordinateX = Int32.Parse(parameters[0]),
                CoordinateY = Int32.Parse(parameters[1])
            };

            _userService.SaveMovements(coordinatesEntity);           
        }

        public Instructions GetInstructions()
        {
            return _userService.GetInstructions();
        }

        private Direction AssignDirection(string direction)
        {
            switch (direction.ToUpper())
            {
                case "N":
                    return Direction.North;
                case "S":
                    return Direction.South;
                case "E":
                    return Direction.East;
                case "W":
                    return Direction.West;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
