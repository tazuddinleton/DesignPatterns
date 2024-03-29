using Serilog;

namespace MediatorPattern.AirTrafficControlSystem;

public abstract class AbstractAirCraft : IAirCraft, ILandableCraft {
    public AbstractAirCraft(string model)
    {
        this.Model =  model;
        AircraftId = Guid.NewGuid();
    }

    public abstract void Wait();

    public Guid AircraftId { get; }
    public string Model { get; }

    public override bool Equals(object? obj)
    {
        return obj is AbstractAirCraft craft &&
               System.Collections.Generic.EqualityComparer<Guid>.Default.Equals(AircraftId, craft.AircraftId) &&
               Model == craft.Model;
    }

    public override int GetHashCode()
    {
       return AircraftId.GetHashCode();
    }

    public void StartLandingSequence()
    {
        Log.Information("Landing...");
        Thread.Sleep(1000);
        Log.Information("Done.");
    }
}
