// Sealed class for special identity matrices
using System.ComponentModel.Design;

// Sealed class for special identity matrices
public sealed class IdentityMatrix : Matrix{
    public IdentityMatrix(int size) : base(size, size){
        for(int i = 0; i < size; i++){
            this[i, i] = 1.0;
        }
    }
    
    // Sealed method preventing further overriding
    public sealed override void Display(){
        Console.WriteLine("Identity Matrix:");
        base.Display();
    }
}