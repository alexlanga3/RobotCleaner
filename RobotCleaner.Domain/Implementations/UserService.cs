using RobotCleaner.Common.Entities;
using RobotCleaner.Domain.Interfaces;
using RobotCleaner.Entities;
using System.Collections.Generic;

namespace RobotCleaner.Domain.Implementations
{
    public class UserService : IUserService
    {
        internal readonly Instructions _instructions;

        public UserService()
        {
            _instructions = new Instructions()
            {
                MovementsList = new List<Movements>()
            };
        }

        public void SaveMovements(Coordinates startCoordinates)
        {
            _instructions.StartCoordinates = startCoordinates;
        }

        public void SaveParameters(Movements movementParameters)
        {
            _instructions.MovementsList.Add(movementParameters);
        }

        public Instructions GetInstructions() => _instructions;
    }
}
