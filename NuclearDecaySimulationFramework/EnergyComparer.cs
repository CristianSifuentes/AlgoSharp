// Custom comparer for particles based on energy
public class EnergyComparer : IComparer<Particle>
{
    public int Compare(Particle? x, Particle? y){
        return x.Energy.CompareTo(y.Energy);
    }
}
