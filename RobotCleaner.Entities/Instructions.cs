using RobotCleaner.Common.Entities;
using System.Collections.Generic;

namespace RobotCleaner.Entities
{
    public class Instructions
    {
       public Coordinates StartCoordinates { get; set; }
       public List<Movements> MovementsList { get; set; }
    }
}
