

using RobotCleaner.Entities;

namespace RobotCleaner.ServiceLibrary.Interfaces
{
    public interface IUserLibrary
    {
        void SetStartParameters(string[] parameters);
        void SetMovements(string[] coordinates);
        Instructions GetInstructions();
    }
}
