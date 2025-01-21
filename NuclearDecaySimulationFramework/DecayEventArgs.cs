// Decay event arguments
public class DecayEventArgs {

   public Particle DecayedParticle { get; }
   public DateTime DecayTime { get; }

   public DecayEventArgs(Particle particle, DateTime time){
    DecayedParticle = particle;
    DecayTime = time;
    
   }
}