using RobotCleaner.Entities;
using System.Threading.Tasks;

namespace RobotCleaner.Domain.Interfaces
{
    public interface IRobotService
    {
        Task<int> RunningThePlay(Robot robot);
    }
}
