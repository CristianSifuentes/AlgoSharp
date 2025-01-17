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

    public double Determinant()
    {
        throw new NotImplementedException();
    }

    public void Display()
    {
        for(int i = 0; i < Rows; i++){
            for(int j = 0; j < Columns; j++){
              Console.WriteLine($"{_data[i, j]}");
          }   
        }
    }


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