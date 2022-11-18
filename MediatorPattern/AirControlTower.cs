using System.Linq;
namespace MediatorPattern.AirTrafficControlSystem;
public class AirControlTower : IAirControlTower
{
    private List<IAirCraft> _airCrafts;
    private List<IRunway> _runways;
    public AirControlTower(List<IRunway> runways) {
        this._airCrafts = new List<IAirCraft>();
        if (runways == null) {
            throw new Exception("Airport can't be functional without runway");
        }
        this._runways = new List<IRunway>();
        runways.ForEach(r => this._runways.Add(r));
    }

    // Detect the craft using radar, or whatever communication mechanism they use approaching an airport.
    public void AddIncomingCraft(IAirCraft airCraft)
    {
       this._airCrafts.Add(airCraft); 
    }

    public IReadOnlyCollection<IAirCraft> AllIncomingCrafts()
    {
        return this._airCrafts.AsReadOnly();
    }

    public void RequestLanding(IAirCraft craft) {
        // find the suitable runway based on the air craft, selecting a run way may involve 
        // other considerations but here for simplicity we assume that, first runway that is clear can receive a plane to land.
        if (this._airCrafts.Find(a => a.Equals(craft)) == null) {
            // Undetected craft.
            return;
        }
        var runway = this._runways.FirstOrDefault(r => r.IsClear());
        if (runway != null) {
            runway.ReceiveAircraft((ILandableCraft)craft);
        } else {
            // Tell the craft to wait, because no runway is clear to land.
            craft.Wait();
        }
    }
}
