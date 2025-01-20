using System.Linq.Expressions;

public class ChemestryLab {
    public static void Main(){
        //Define atoms
        var hydrogen = new Atom{ Symbol = "H", AtomicWeight = 1.008 };
        var oxygen = new Atom { Symbol = "0", AtomicWeight = 16.00 };
        var carbon = new Atom { Symbol = "C", AtomicWeight = 12.011 };

        // Define molecules 
        var molecules = new List<Molecule> {
            new Molecule { Name = "Water", Atoms = { hydrogen, hydrogen, oxygen } },
            new Molecule { Name = "Methane", Atoms = { carbon, hydrogen, hydrogen, hydrogen, hydrogen } },
            new Molecule { Name = "Carbon Dioxide", Atoms = { carbon, oxygen, oxygen } },
            new Molecule { Name = "Oxygen Gas", Atoms = { oxygen, oxygen } }
        };

        // 1. Filter molecules with molecular weight above 18
        double weightThreshold = 18.0;
        var heavyMolecules = molecules.Where(m=> m.MolecularWeight > weightThreshold);
        Console.WriteLine("Molecules with Molecular Weigh > 18:");
        foreach(var molecule in heavyMolecules){
            Console.WriteLine($"{molecule.Name} ({molecule.MolecularWeight:F2} g/mol)");
        } 

        // 2. Group molecules by dominant element
        var groupedByElement = molecules.GroupBy(m => m.DominantElement).Select(group => new {
            Element = group.Key,
            Molecules  = group.ToList(),
            AverageWeight = group.Average(m => m.MolecularWeight)
        });
        Console.WriteLine("\nMolecules Grouped by Dominant Element:");
        foreach(var group in groupedByElement){
            Console.WriteLine($"Element: {group.Element}, Average Weight: {group.AverageWeight:F2} g/mol" );
            foreach (var molecule in group.Molecules) { 
                Console.WriteLine($"  - {molecule.Name}");
            }
        }

        // 3. Find molecules containing Oxygen and Hydrogen
        var oxygenHydrogenMolecules = 
        molecules.Where(m=> m.Atoms.Any(a => a.Symbol == "O") && 
        m.Atoms.Any(a => a.Symbol == "H"));
        foreach (var molecule in oxygenHydrogenMolecules) {
            Console.WriteLine($"{molecule.Name}");
        }

        // 4. Sort molecules by complexity and molecular weight
        var sortedMolecules = molecules.OrderByDescending(m => m.Complexity)
                                       .ThenByDescending(m => m.MolecularWeight);
        Console.WriteLine("\nMolecules Sorted by Complexity and Molecular Weight:");
        foreach (var molecule in sortedMolecules) {
            Console.WriteLine($"{molecule.Name}: Complexity = {molecule.Complexity}, Weight = {molecule.MolecularWeight:F2} g/mol");
        }

        // 5. Custom Aggregation: Calculate total molecular weight for all molecules
        double totalWeight = molecules.Aggregate(0.0, (sum, molecule) => sum + molecule.MolecularWeight);
        Console.WriteLine($"\nTotal Molecular Weight of All Molecules: {totalWeight:F2} g/mol");

        // 6. Dynamic Filtering using Expression Trees
        Console.WriteLine("\nDynamic Filter: Molecules with Name Containing 'Carbon':");
        var filter = BuildDynamicFilter<Molecule>("Name", "Carbon");
        var filteredMolecules = molecules.Where(filter.Compile());
        foreach (var molecule in filteredMolecules) {
            Console.WriteLine($"{molecule.Name}");
        }
    }
    
    // Dynamic filter builder using Expression Trees
    public static Expression<Func<T, bool>> BuildDynamicFilter<T>(string propertyName, string value) {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, propertyName);
        var constant = Expression.Constant(value);
        var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        var containsCall = Expression.Call(property, containsMethod, constant);
        return Expression.Lambda<Func<T, bool>>(containsCall, parameter);
    }

}