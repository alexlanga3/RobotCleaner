using RobotCleaner.Common.Entities;
using System.Collections.Generic;

namespace RobotCleaner.Entities
{
    public class Robot
    {
        /// Gets or sets the movements.
        /// </summary>
        public List<Movements> MovementsList { get; set; }

        /// Gets or sets the coordinates.
        /// </summary>
        public Coordinates StartCoordinates { get; set; }
    }
}
