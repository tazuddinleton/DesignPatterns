namespace MediatorPattern.AirTrafficControlSystem;

public class Runway : IRunway
{
    private ILandableCraft? _landingAirCraft;
    public Runway(string name) {
        Name = name;
    }

    public string Name { get;}

    public bool IsClear()
    {
        return this._landingAirCraft is null;
    }

    public void ReceiveAircraft(ILandableCraft craft)
    {
        this._landingAirCraft = craft;

        // We assume that an aircraft always lands safely
        this._landingAirCraft.StartLandingSequence();
    }
}