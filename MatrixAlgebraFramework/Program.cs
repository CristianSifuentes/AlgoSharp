using System.Numerics;

class Program {
        static void Main() { 

        // Create and populate matrices
        var matrixA = new Matrix(2, 2);
        matrixA.Populate(new double[,] { { 1, 2 }, { 3, 4 } });

        var matrixB = new Matrix(2, 2);
        matrixB.Populate(new double[,] { { 5, 6 }, { 7, 8 } });

        Console.WriteLine("Matrix A:");
        matrixA.Display();

        Console.WriteLine("\nMatrix B:");
        matrixB.Display();

        // Perform operations
        Console.WriteLine("\nMatrix A + Matrix B:");
        var addition = matrixA.Add(matrixB);
        addition.Display();

        Console.WriteLine("\nMatrix A - Matrix B:");
        var subtract = matrixA.Subtract(matrixB);
        subtract.Display();

        Console.WriteLine("\nMatrix A * Matrix B:");
        var multiplication = matrixA.Multiply(matrixB);
        multiplication.Display();

        Console.WriteLine("\nDeterminant of Matrix A:");
        Console.WriteLine(matrixA.Determinant());

        // Identity Matrix
        Console.WriteLine("\nIdentity Matrix (2x2):");
        var identity = new IdentityMatrix(2);
        identity.Display();


        }

 }