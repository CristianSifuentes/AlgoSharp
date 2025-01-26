public class Program {
    public static async Task Main(string[] args) {
        
         
        // initialization physical objects
        var object1 = new PhysicalObject("Object 1", 5, new Point2D<double>(0, 0), new Point2D<double>(2, 3));
        var object2 = new PhysicalObject("Object 2", 10, new Point2D<double>(5, 5), new Point2D<double>(-1, 1));
         
        // Subscribe to events
        object1.ObjectUpdated += message => Console.WriteLine($"[Event] {message}");
        object2.ObjectUpdated += message => Console.WriteLine($"[Event] {message}");

        // Apply forces to objects
        object1.ApplyForce(new Point2D<double>(10, 15)); // 10 N in x, 15 N in y
        object2.ApplyForce(new Point2D<double>(-20, 5)); // -20 N in x, 5 in y
        
        // Create simulation
        var simulation = new PhysicsSimulation<PhysicalObject>();
        simulation.AddEntity(object1);
        simulation.AddEntity(object2);
        
        // Run simulation asynchronously
        Console.WriteLine("\nStarting Simulation...\n");
        await RunSimulationAsync(simulation, 0.1, 10);

    } 

    // Asynchronous simulation runner
    private static async Task RunSimulationAsync(PhysicsSimulation<PhysicalObject> simulation, double timeStep, int steps){
        for(int i = 0; i < steps; i++){
            Console.WriteLine($"\n--- Step {i + 1} ---");
            simulation.UpdateAll(timeStep);
            
            // Display current state
            foreach(var entity in simulation.GetEntities()){
                entity.DisplayState();
            }

            // Simulation delay (e.g., sensor collection)
            await Task.Delay(500);
        }
    }
}