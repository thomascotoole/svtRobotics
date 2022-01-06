using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace svtRobotics.Models
{
    public class Robot
    {
        public string robotId { get; set; }
        public int batteryLevel { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }
}
