using System.Collections.Generic;

public class Molecule { 
    public string Name { get; set; } // e.g., Water, Methane
    public List<Atom> Atoms { get; set; } = new List<Atom>();

    // Calculate molecular weight dynamically
    public double MolecularWeight => Atoms.Sum(atom=> atom.AtomicWeight);
    
    //Calculate molecule complexity (number of atoms)
    public int Complexity => Atoms.Count;
    
    //Identify the dominant element (most frequently occurring atom)
    public string DominantElement  => 
      Atoms.GroupBy(atom=> atom.Symbol).OrderByDescending(group => group.Count()).First().Key;
}