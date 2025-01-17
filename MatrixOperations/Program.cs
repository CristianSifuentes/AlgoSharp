using System;
using System.Collections.Generic;
using System.Linq;




public class Program {
    public static void Main(){
        var matrix1 = new Matrix<int>(
            new int [,] {
                {1, 2},
                {3, 4}
            }
        );
        var matrix2 = new Matrix<int>(new int[,] {
            { 5, 6}, 
            { 7, 8}
        });

  
        
        Console.WriteLine("Matrix 1:");
        matrix1.Display();
        Console.WriteLine("\nMatrix 2:");
        matrix2.Display();
        Console.WriteLine("\nMatrix Multiplication");
        matrix1.Multiply(matrix2);

    }
}