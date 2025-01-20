// Base class for a Matrix
using System.ComponentModel;

public class Matrix : MathematicalObject, IMatrixOperations
{
    private readonly double [,] _data;

    public int Rows { get; private set; }
    public int Columns { get; private set; }

    // Constructor
    public Matrix(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _data = new double[rows, columns];
    }

    public Matrix Add(Matrix other)
    {
        throw new NotImplementedException();
    }

    public double Determinant()
    {
        throw new NotImplementedException();
    }

    public Matrix Multiply(Matrix other)
    {
        throw new NotImplementedException();
    }

    public Matrix Substract(Matrix other)
    {
        throw new NotImplementedException();
    }

     // Display the matrix
    public override void Display() {
        for(int i = 0; i < Rows; i++){
            for(int j = 0; j < Columns; j++){
                Console.WriteLine($"{_data[i, j],8:F2}");
            }
            Console.WriteLine();
        }
    }

    // Method OverLoading: Populate matrix from 2D array
    public void Populate(double[,] data)
    {
        if(data.GetLength(0) != Rows || data.GetLength(1) != Columns)
           throw new ArgumentException("Dimension mismatch");

        for(int i = 0; i < Rows; i++){
            for(int j= 0; j < Columns; j++){
                _data[i, j] = data[i,j];
            }
        }
    }

    //Method Overloading: Populate with a constant value
    public void Populate(double value){
        for(int i = 0; i < Rows; i++){
            for(int j = 0; j< Columns; j++){
                _data[i, j] = value;
            }
        }
    }
}