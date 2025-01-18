using System.Globalization;

public class ParticlePhysics   {
    public static void Main() {
        var particles = new List<Particle> {
            new Particle { Type = "Proton", Mass = 1.67e-27, Velocity = 3e7 },
            new Particle { Type = "Electron", Mass = 9.11e-31, Velocity = 2.5e8 },
            new Particle { Type = "Neutron", Mass = 1.67e-27, Velocity = 2.8e7 },
            new Particle { Type = "Proton", Mass = 1.67e-27, Velocity = 2.9e7 },
            new Particle { Type = "Electron", Mass = 9.11e-31, Velocity = 2.7e8 },
            new Particle { Type = "Neutron", Mass = 1.67e-27, Velocity = 3e7  },
        };

        // 1 . Calculate the average speed of all particles
        var averageSpeed = particles.Average(p => p.Velocity);
        Console.WriteLine($"Average Speed: {averageSpeed:N2} m/s");
        
        // 2. Find particles with energy above a certain threshold
        double energyThreshold = 1e-13;
        var highEnergyParticles = particles.Where(p=> p.Energy > energyThreshold);
        Console.WriteLine("\nParticles with Energy > Threshold:");
        foreach (var particle in highEnergyParticles){
            Console.WriteLine($"{particle.Type} | energyThreshold: {particle.Energy:E2} J");
        }
        // 3. Group particles by type and calculate total energy for each group
        var groupedByType = particles.GroupBy(p => p.Type)
               .Select(group => new {
                  Type = group.Key,
                  TotalEnergy = group.Sum(p => p.Energy),
                  Count = group.Count()
               });
        Console.WriteLine("\nTotal Energy by Particle Type:");
        foreach(var group in groupedByType){
            Console.WriteLine($"{group.Type}: Total Energy = {group.TotalEnergy:E2} J, Count = { group.Count} ");
        }

        // 4. Identify the fastest particle in each group
        var fastestInEachGroup = particles.GroupBy(p=> p.Type)
             .Select(group => group.OrderByDescending(p=> p.Velocity).First());
        
        Console.WriteLine("\nFastest Particle in Each Group:");
        foreach (var particle in fastestInEachGroup) {
            Console.WriteLine($"{particle.Type}: Velocity = {particle.Velocity:E2} m/s");
        }      
       
        // 5. Sort particles by energy and velocity in descending order
         var sortedParticles = particles.OrderByDescending(p => p.Energy)
                                       .ThenByDescending(p => p.Velocity);
                                       
        Console.WriteLine("\nParticles Sorted by Energy and Velocity:");
        foreach (var particle in sortedParticles) {
            Console.WriteLine($"{particle.Type}: Energy = {particle.Energy:E2} J, Velocity = {particle.Velocity:E2} m/s");
        }

    }

}