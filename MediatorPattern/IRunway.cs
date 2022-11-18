namespace MediatorPattern.AirTrafficControlSystem;

public interface IRunway {
    public bool IsClear();
    public void ReceiveAircraft(ILandableCraft craft);
}
