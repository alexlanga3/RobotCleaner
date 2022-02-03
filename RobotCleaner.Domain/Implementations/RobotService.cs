using RobotCleaner.Common.Entities;
using RobotCleaner.Domain.Interfaces;
using RobotCleaner.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotCleaner.Domain.Implementations
{
    public class RobotService : IRobotService
    {
        private const int positiveLimit = 100000; 
        private const int negativeLimit = -100000; 

        private Coordinates _robotPosition;
        private List<int> _roomCleaned;


        public RobotService()
        {
            _robotPosition = new Coordinates();
            _roomCleaned = new List<int>();
        }

        public Task<int> RunningThePlay(Robot robot)
        {
            _robotPosition.CoordinateX = robot.StartCoordinates.CoordinateX;
            _robotPosition.CoordinateY = robot.StartCoordinates.CoordinateY;

            SetRoomCleaned(_robotPosition.CoordinateX, _robotPosition.CoordinateY);

            foreach (var movement in robot.MovementsList)
            {
                switch (movement.Direction)
                {
                    case Direction.North:
                        UpdateCurrentPostion(0, movement.Steps);
                        break;
                    case Direction.South:
                        UpdateCurrentPostion(0, -movement.Steps);
                        break;
                    case Direction.East:
                        UpdateCurrentPostion(movement.Steps, 0);
                        break;                   
                    case Direction.West:
                        UpdateCurrentPostion(-movement.Steps, 0);
                        break;
                }
            }

            return Task.FromResult(_roomCleaned.Distinct().Count());
        }

        private void UpdateCurrentPostion(int newMovementX, int newMovementY)
        {
            var nextPositionX = _robotPosition.CoordinateX + newMovementX;
            var nextPositionY = _robotPosition.CoordinateY + newMovementY;

            if (nextPositionX < negativeLimit)
            {
                nextPositionX = negativeLimit;
            }
            else if(nextPositionX > positiveLimit)
            {
                nextPositionX = positiveLimit;
            }

            if (nextPositionY < negativeLimit)
            {
                nextPositionY = negativeLimit;
            }
            else if(nextPositionY > positiveLimit)
            {
                nextPositionY = positiveLimit;
            }

            _robotPosition.CoordinateX = nextPositionX;
            _robotPosition.CoordinateY = nextPositionY;

            SetRoomCleaned(_robotPosition.CoordinateX, _robotPosition.CoordinateY);
        }

        private void SetRoomCleaned(int currentPositionX, int currentPositionY)
        {
            if (currentPositionX > 0)
            {
                if (currentPositionY > 0)
                {
                    _roomCleaned.Add(1);
                }
                else
                {
                    _roomCleaned.Add(2);
                }

            }
            else if (currentPositionY > 0)
            {
                _roomCleaned.Add(3);
            }
            else
            {
                _roomCleaned.Add(4);
            }
        }

    }
}
