namespace MediatorPattern.AirTrafficControlSystem;

public interface IRunway {
    public bool IsClear();
    public void ReceiveAircraft(IAirCraft craft);
}

public class Runway : IRunway
{
    public Runway(string name) {
        Name = name;
    }
    public string Name { get;}

    public bool IsClear()
    {
        throw new NotImplementedException();
    }

    public void ReceiveAircraft(IAirCraft craft)
    {
        throw new NotImplementedException();
    }
}