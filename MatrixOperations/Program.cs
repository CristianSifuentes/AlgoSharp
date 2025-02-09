﻿using System;
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
        var product = matrix1.Multiply(matrix2);
        product.Display();
        Console.WriteLine("\nTranspose of Matrix 1:");
        var transpose = matrix1.Transpose();
        transpose.Display();
        Console.WriteLine("\nDeterminant of Matrix 1:");
        Console.WriteLine(matrix1.Determinant());

    }
}