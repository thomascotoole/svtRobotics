using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace svtRobotics.Models
{
    public class ClosestRobot
    {
        public string robotId { get; set; }
        public double distanceToGoal { get; set; }
        public double batteryLevel { get; set; }
    }
}
