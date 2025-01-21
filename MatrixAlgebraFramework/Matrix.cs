// Base class for a Matrix
using System.ComponentModel;

public class Matrix : MathematicalObject, IMatrixOperations
{
    private readonly double [,] _data;
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    // Constructor
    public Matrix(int rows, int columns){
        Rows = rows;
        Columns = columns;
        _data = new double[rows, columns];
    }

    // Indexer for accessing matrix elements 
    public double this[int row, int column]{
        get => _data[row, column];
        set => _data[row, column] = value;
    }

    // Subtract  matrices 
    public Matrix Subtract(Matrix other){
       ValidateDimensionMatch(other);
       var result = new Matrix(Rows, Columns);
       for(int i = 0; i < Rows; i++){
        for(int j = 0; j < Columns; j++){
            result[i, j] = this[i, j] - other[i, j];
        }
       }
       return result; 
    }

    // Static method for creating an identity matrix
    public static Matrix Identity(int size){
        var matrix = new Matrix(size, size);
        for(int i = 0; i < size; i++){
            matrix[i, i] = 1.0;
        }
        return matrix;
    }




    public Matrix Add(Matrix other){
        ValidateDimensionMatch(other);
        var result = new Matrix(Rows, Columns);
        for (int i = 0; i < Rows; i++) {
            for (int j = 0; j < Columns; j++) {
                result[i, j] = this[i, j] + other[i, j];
            }
        }
        return result;
    }

    // Protected method for validation
    private void ValidateDimensionMatch(Matrix other){
        if(Rows != other.Rows || Columns != other.Columns)
            throw new InvalidOperationException("Matrix dimensions must match.");
    }

    //Determinant calculation (recursive)
    public double Determinant(){
        if (Rows != Columns)
          throw new InvalidOperationException("Determinant can only be calculated for square matrices.");
        return CalculateDeterminant(_data);
    }

    private double CalculateDeterminant(double[,] matrix){
        int size = matrix.GetLength(0);
        if (size == 1) return matrix[0,0];
        if (size == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
         
        double determinant = 0;
        for (int i = 0; i < size; i++) {
            determinant += Math.Pow(-1, i) * matrix[0, i] * CalculateDeterminant(GetMinor(matrix, 0, i));
        }
        return determinant;
 
    }

    private double[,] GetMinor(double[,] matrix, int row, int col) {
        int size = matrix.GetLength(0);
        var minor = new double[size - 1, size - 1];
        for (int i = 0, mi = 0; i < size; i++) {
            if(i == row) continue;
            for(int j = 0, mj = 0; j < size; j++){
                if(j == col) continue;
                minor[mi, mj++] = matrix[i, j];
            }
            mi++;
        }
        return minor;
    }

    // Multiply matrices
    public Matrix Multiply(Matrix other){
        if(Columns != other.Rows)
           throw new InvalidOperationException("Invalid dimensions for multiplication.");
        
        var result = new Matrix(Rows, other.Columns);
        for(int i = 0; i < Rows; i++){
            for(int j = 0; j < other.Columns; j++){
                for(int k = 0; k < Columns; k++){
                    result [i, j] += this[i,k] * other[k,j];
                }
            }
        }
        return result; 
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