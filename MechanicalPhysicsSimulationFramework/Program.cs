public class Program {
    public static void Main(string [] args){
         
        // initialization physical objects
        var object1 = new PhysicalObject("Object 1", 5, new Point2D<double>(0, 0), new Point2D<double>(2, 3));
        var object2 = new PhysicalObject("Object 2", 10, new Point2D<double>(5, 5), new Point2D<double>(-1, 1));
         
        // Subscribe to events
        // object1.ObjectUpdated += message => Console.WriteLine("$"[Event] {message}"); 
        
        // Apply forces to objects
        object1.ApplyForce(new Point2D<double>(10, 15)); // 10 N in x, 15 N in y
        object2.ApplyForce(new Point2D<double>(-20, 5)); // -20 N in x, 5 in y
        
        // Create simulation
        var simulation = new PhysicsSimulation<PhysicalObject>();
    } 
}