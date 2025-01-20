// Sealed class for special identity matrices
using System.ComponentModel.Design;

public sealed class IdentityMatrix : Matrix{
    public IdentityMatrix(int size) : base(size, size){
    }
    public sealed override void Display(){
        Console.WriteLine("Identity Matrix:");
        base.Display();
    }
}