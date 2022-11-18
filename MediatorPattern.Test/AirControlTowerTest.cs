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

        var ctrlTower = new AirControlTower(runWays);

        var plane1 = new AirCraft("Boyeing 737");
        ctrlTower.AddIncomingCraft(plane1);
        var incomingPlanes = ctrlTower.AllIncomingCrafts();
        Assert.Equal(1, incomingPlanes.Count);

        var plane2 = new AirCraft("Airbus A340");
        ctrlTower.AddIncomingCraft(plane2);
        incomingPlanes = ctrlTower.AllIncomingCrafts();
        Assert.Equal(plane2, incomingPlanes.ToList().Last());
    }
}