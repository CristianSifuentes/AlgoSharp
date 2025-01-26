// Class representing a physical object in motion
public class PhysicalObject: IPhysicsEntity
{
    private string Name { get; set; }
    public double Mass { get; set; } // kg
    public Point2D<double> Position { get; private set; } // m
    public Point2D<double> Velocity { get; private set; } // m
    public Point2D<double> Acceleration { get; private set; } // m/s^2;
    public event Action<string> ObjectUpdated; // Event for state updates 
    public PhysicalObject(string name, double mass, Point2D<double> initialPosition, Point2D<double> initialVelocity){
        Name = name;
        Mass = mass;
        Position = initialPosition;
        Velocity = initialVelocity;
        Acceleration = new Point2D<double>(0,0);
    }

    public void DisplayState(){
        Console.WriteLine($"{Name}: Position {Position}, Velocity {Velocity}, Acceleration {Acceleration}");
    }

    // Apply a force to the object
    public void ApplyForce(Point2D<double> force) {
        Acceleration = new Point2D<double>(force.X / Mass, force.Y / Mass);
    }

    // Update the object´s state based on acceleration
    public void Update(double timeStep){
        Velocity = new Point2D<double>(
            Velocity.X + Acceleration.X * timeStep,
            Velocity.Y + Acceleration.Y * timeStep
        );
        Position = new Point2D<double>(
           Position.X + Velocity.X * timeStep,
           Position.Y + Velocity.Y * timeStep
        );
        
        ObjectUpdated?.Invoke($"{Name} updated: Position {Position}, Velocity {Velocity}");
    }
}