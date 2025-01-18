public class Particle {
    public required string Type { get; set; } // e.g., Proton, Electron, Neutron
    public double Mass { get; set; } // in Mev/c^2
    public double Velocity { get; set; } // in m/s
    public double Energy => 0.5 * Mass * Velocity * Velocity; // E = 1/2 * m * v^2
}