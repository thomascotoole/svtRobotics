using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using svtRobotics.Models;

namespace svtRobotics.Controllers
{
    [Route("api/robots")]
    [ApiController]
    public class RobotsController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();

        [HttpPost("closest")]
        public async Task<ActionResult<ClosestRobot>> Post([FromBody]RobotPayload payload)
        {
            //Get Robots
            List<ClosestRobot> closestRobots = new List<ClosestRobot>();
            var response = client.GetStreamAsync("https://60c8ed887dafc90017ffbd56.mockapi.io/robots");
            var robots = await JsonSerializer.DeserializeAsync<List<Robot>>(await response);

            //Calculate distances
            foreach(Robot robot in robots)
            {
                var distanceToGoal = Math.Sqrt(Math.Pow((robot.x - payload.x),2) + Math.Pow((robot.y - payload.y), 2));
                var closeRobot = new ClosestRobot { batteryLevel = robot.batteryLevel, robotId = robot.robotId, distanceToGoal = distanceToGoal };
                closestRobots.Add(closeRobot);
            }

            //Sort by distance and battery power
            List<ClosestRobot> returnValue = closestRobots.OrderBy(order => order.distanceToGoal).ThenBy(order => order.batteryLevel).ToList();
           
            //Return the top of the list
            return returnValue[0];
        }
    }
}