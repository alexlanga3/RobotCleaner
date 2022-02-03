using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner.ServiceLibrary.Interfaces
{
    public interface IRobotLibrary
    {
        Task<int> RunningThePlayAsync(Entities.Instructions instructions);
    }
}
