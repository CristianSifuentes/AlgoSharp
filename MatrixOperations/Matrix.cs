/// <summary>
/// Class that calculate, matrix multiplication, matrix transpose, matrix determinant, using dynamic type handling and interfaces
/// Interfaces
/// </summary>
/// <typeparam name="T"></typeparam>
public class Matrix<T>: IMatrixOperations<T> where T : struct{
    private readonly T[,] _data;
    public int Rows { get;  }
    public int Columns { get; }
    public Matrix(T[,] ints)
    {
        this._data = ints;
        Rows = this._data.GetLength(0);
        Columns = this._data.GetLength(1);
    }

    public T this [int row, int col]{
        get => _data[row, col];
    }
     
    
    /// <summary>
    /// Uses recursion to calculate the determinant of square matrices.
    /// </summary>
    /// <returns>result to call 'CalculateDeterminant' method</returns>
    /// <exception cref="NotImplementedException"></exception>
    public double Determinant()
    {   
        if(Rows != Columns)
          throw new NotImplementedException();
        
        return CalculateDeterminant(_data);
    }

    /// <summary>
    /// Calculate determinant for a matrix generic
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    private double CalculateDeterminant(T[,] matrix)
    {
        int size = matrix.GetLength(0);
        if(size == 1) return Convert.ToDouble(matrix[0,0]);
        if(size == 2) return (dynamic)matrix[0,0] * matrix[1,1] - (dynamic)matrix[0,1] * matrix[1,0];
        double determinant = 0;

        for(int i = 0; i < size; i++){
            T[,] minor = GetMinor(matrix, 0, i);
            determinant  += Math.Pow(-1, i) * 
              Convert.ToDouble(matrix[0, i]) * 
              CalculateDeterminant(minor);

        }
        return determinant;

    }

    /// <summary>
    /// ???
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    private T[,] GetMinor(T[,] matrix, int row, int col)
    {
        int size = matrix.GetLength(0);
        T[,] minor = new T[size - 1, size - 1];
        for(int i = 0, m = 0; i < size; i++){
           if(i == row) continue;
           for(int j = 0, n = 0; j < size; j++){
              if(j == col) continue;
              minor[m, n++] = matrix[i,j];
           }
           m++;
        }
        return minor;
    }


    /// <summary>
    /// Method used for display all generic Matrices
    /// </summary>
    public void Display()
    {
        for(int i = 0; i < Rows; i++){
            for(int j = 0; j < Columns; j++){
              Console.WriteLine($"{_data[i, j]}");
          }   
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public Matrix<T> Multiply(Matrix<T> other)
    {
        if (Columns != other.Rows)
          throw new InvalidOperationException("Matrices cannot be multiplied");

        T[,] result = new T[Rows, other.Columns];

        for (int i = 0; i < Rows; i++) {
            for (int j = 0; j < other.Columns; j++) {
                dynamic sum = 0;
                for (int k = 0; k < Columns; k++) {
                    sum += (dynamic)_data[i, k] * other[k, j];
                }
                result[i, j] = sum;
            }
        }
        return new Matrix<T>(result);
    }
     
    /// <summary>
    /// Swaps rows and columns to produce the transpose. 
    /// </summary>
    /// <returns>T[,]</returns>
    public Matrix<T> Transpose()
    {
        T[,] result = new T[Columns, Rows];
        for(int i = 0; i < Rows; i++){
            for(int j = 0; j < Columns; j++){
                result[j, i] = _data[i, j];
            }
        }
        return new Matrix<T>(result);
    }
}