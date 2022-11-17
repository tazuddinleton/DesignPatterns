using Xunit;

using System.Collections.Generic;
using MediatorPattern.AirTrafficControlSystem;
using System.Linq;

namespace MediatorPattern.Test;

public class AirControlTowerTest
{
    [Fact]
    public void ShouldAddIncomingAircraftsToTheQueue()
    {
        var runWays = new List<IRunway>();
        runWays.Add(new Runway("Run way 1"));
        var controlTower = new AirControlTower(runWays);

        var plane1 = new AirCraft("Boyeing 737");
        controlTower.AddIncomingCraft(plane1);

        var allIncoing = controlTower.AllIncomingCrafts();
        Assert.Equal(1, allIncoing.Count);

        var plane2 = new AirCraft("Airbus A340");
        controlTower.AddIncomingCraft(plane2);
        allIncoing = controlTower.AllIncomingCrafts();

        
        Assert.Equal(plane2, allIncoing.ToList().Last());


    }
}