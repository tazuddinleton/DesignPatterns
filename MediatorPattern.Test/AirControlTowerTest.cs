using Xunit;

using System.Collections.Generic;
using MediatorPattern.AirTrafficControlSystem;
using System.Linq;
using Serilog.Sinks.TestCorrelator;
using Serilog;
using FluentAssertions;

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

    [Fact]
    public void ShouldAcceptCraftForLandingWhenGivenAirCraftAgainsAClearRunway() {

        Log.Logger = new LoggerConfiguration().WriteTo.TestCorrelator().CreateLogger();
        using (TestCorrelator.CreateContext()) {
            
            var runWays = new List<IRunway>();
            runWays.Add(new Runway("Run way 1"));

            var ctrlTower = new AirControlTower(runWays);
            
            
            var plane1 = new AirCraft("Boyeing 737");
            ctrlTower.AddIncomingCraft(plane1);
            ctrlTower.RequestLanding(plane1);


            TestCorrelator.GetLogEventsFromCurrentContext()
            .Should().HaveCount(2);
        }



    }
}