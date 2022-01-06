# Take Home Assessment - Tom O'Toole

### How to run and test
1. Download into folder
2. from that folder run `dotnet run`
3. You should have a server listening on `https://localhost:5001/api/robots/closest`
4. Use curl, postman or something similar to hit the endpoint with a JSON body formatted as such:

```
{
	"loadId": 100
	"x": 10,
	"y": 10
}
```

And you should receive a response in the format of:

```
{
	"robotId": 10,
	"distanceToGoal": 20.5
	"batteryLevel": 50
}
```

### Ideas for improvement or what to implement next
1. Deal with an array/list of input parameters
2. Determine optimal path when a single robot has to travel to multiple cargo destinations
3. Depending on resources available, multiple lists might be too expensive, so condense where possible if necessary 
4. Make the loop a Parallel.foreach 
5. Take into account the robots capacity and current load
6. Take into account the robots current direction of travel/task - is it already heading towards a load or carrying a load back or on it's way to recharge?
7. Take into account the dimensions of the load, is it too big for the robot?
8. Parameterize URL for getting robots
9. Methods that tell the robot to move to a location, recharge, retrieve and unload cargo etc.
10. Properties tied to events that tell robots to do things like move to the closest recharging station when at a specific batteryLevel (ensuring you have battery power to make the trip).
11. More robust parameter error handling
12. Logging