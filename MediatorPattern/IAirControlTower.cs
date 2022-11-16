namespace MediatorPattern.AirTrafficControlSystem;

public interface IAirControlTower
{
   public void RequestLanding(IAirCraft airCraft); 
   public void AddIncomingCraft(IAirCraft airCraft);
   public IReadOnlyCollection<IAirCraft> AllIncomingCrafts();
}
