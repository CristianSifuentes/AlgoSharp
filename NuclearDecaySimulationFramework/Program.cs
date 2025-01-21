public class Program {
        public static void Main() {
            // Initialize particles
            var particles = new List<Particle> {
                new Particle { Name = "Uranium-238", Energy = 4.2, HalfLife = TimeSpan.FromSeconds(60) },
                new Particle { Name = "Thorium-234", Energy = 3.8, HalfLife = TimeSpan.FromSeconds(45) },
                new Particle { Name = "Radium-226", Energy = 3.0, HalfLife = TimeSpan.FromSeconds(30) }
            };

            // LINQ Query: Filter high-energy particles
            var highEnergyParticles = particles.Where(p=> p.Energy > 3.5).ToList();
            Console.WriteLine("High-Energy Particles:");
            highEnergyParticles.ForEach(p=> Console.WriteLine($"{p.Name}: {p.Energy} MeV"));

            // LINQ Query: Group particles by half-life range
            var groupedParticles = particles.GroupBy(p=> p.HalfLife.TotalSeconds > 50 ? "Long": "Short");
            Console.WriteLine("\nParticles Grouped by Half-Life:");
            foreach(var group in groupedParticles){
                Console.WriteLine($"{group.Key} Half-Life:");
                foreach(var particle in group){
                    Console.WriteLine($"  - {particle.Name}: {particle.HalfLife.TotalSeconds} seconds");
                }
            }

            // Sort particles by energy using a custom comparer
            particles.Sort(new EnergyComparer());
            Console.WriteLine("\nParticles Sorted by Energy:");
            particles.ForEach(p=> Console.WriteLine($"{p.Name}: {p.Energy} MeV"));
            
            // Initialize decay simulator
            var simulator = new DecaySimulator();

            // Subscribe to decay event
            simulator.ParticleDecayed += (sender, args) => {
                Console.WriteLine($"\nDecay Event: { args.DecayedParticle.Name } decayed at {args.DecayTime}");   
            };

            // Add particles to decay simulator 
            foreach (var particle  in particles){
                simulator.AddParticle(particle);
            }

            // Simulated decay process
            Console.WriteLine("\nSimulating Decay...");
            simulator.SimulateDecay(5);
            
        }
}

