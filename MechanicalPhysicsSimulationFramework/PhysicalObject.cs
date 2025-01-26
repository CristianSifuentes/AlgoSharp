// Class representing a physical object in motion
public class PhysicalObject: IPhysicsEntity
{
    private string Name { get; set; }
    public double Mass { get; set; } // kg
    private Point2D<double> Position;
    private Point2D<double> Velocity;
    private Point2D<double> Acceleration;

    public PhysicalObject(string name, double mass, Point2D<double> point2D1, Point2D<double> point2D2)
    {
        Name = name;
        Mass = mass;
        Position = point2D1;
        Velocity = point2D2;
        Acceleration = new Point2D<double>(0,0);
    }

    public void DisplayState()
    {
        throw new NotImplementedException();
    }

    public void Update(double timeStep)
    {
        throw new NotImplementedException();
    }
}