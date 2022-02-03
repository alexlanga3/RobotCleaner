using RobotCleaner.Domain.Interfaces;
using RobotCleaner.Entities;
using RobotCleaner.ServiceLibrary.Interfaces;
using System.Threading.Tasks;

namespace RobotCleaner.ServiceLibrary.Implementations
{
    public class RobotLibrary : IRobotLibrary
    {
        /// <summary>
        /// User Robot Service.
        /// </summary>
        private readonly IRobotService _robotService;

        public RobotLibrary(IRobotService robotService)
        {
            _robotService = robotService;
        }

        public async Task<int> RunningThePlayAsync(Instructions instructions)
        {
            var robot = new Robot()
            {
                StartCoordinates = instructions.StartCoordinates,
                MovementsList = instructions.MovementsList
            };

            return await _robotService.RunningThePlay(robot);
        }
    }
}
