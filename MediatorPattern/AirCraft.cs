namespace MediatorPattern.AirTrafficControlSystem;

public class AirCraft : AbstractAirCraft
{
    public AirCraft(string model): base(model) {
        
    }
    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override string ToString()
    {
        return Model;
    }

    public override void Wait()
    {
        Console.WriteLine("Waiting for the runway to be clear...");
    }
}