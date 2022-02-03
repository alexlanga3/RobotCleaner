using RobotCleaner.Common.Entities;
using RobotCleaner.Entities;

namespace RobotCleaner.Domain.Interfaces
{
    public interface IUserService
    {
        void SaveMovements(Coordinates coordinatesEntity);
        void SaveParameters(Movements parametersEntity);
        Instructions GetInstructions();
    }
}
