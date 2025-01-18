using System.Collections.Generic;

public class Molecule { 
    public string Name { get; set; } // e.g., Water, Methane
    public List<Atom> Atoms { get; set; } = new List<Atom>();
}