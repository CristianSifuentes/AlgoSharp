// Decay simulation class
public class DecaySimulator{
    private readonly Queue<Particle> _decayQueue = new ();
    private readonly Random _random = new();

    // Event triggered when a particle decays
    public event EventHandler<DecayEventArgs> ParticleDecayed;

    public void AddParticle(Particle particle)
    {
        _decayQueue.Enqueue(particle);
    }

    public void SimulateDecay(int steps)
    {
        for (int i = 0; i < steps && _decayQueue.Count > 0; i++) {
            var particle = _decayQueue.Dequeue();

            // Trigger decay event
            ParticleDecayed?.Invoke(this, new DecayEventArgs(particle, DateTime.Now));
            
            //Generate a new particle with Lower energy (simplified decay process)
            if(particle.Energy > 1){
                _decayQueue.Enqueue(new Particle {
                 Name = $"{particle.Name} (decayed)",
                 Energy = particle.Energy * 0.8,
                 HalfLife = TimeSpan.FromSeconds(particle.HalfLife.TotalSeconds * 0.9)
                });
            }
        }
    }
}
