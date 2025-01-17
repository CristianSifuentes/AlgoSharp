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

    public void Multiply(Matrix<T> other)
    {
        if (Columns != other.Rows)
          throw new InvalidOperationException("Matrices cannot be multiplied");

        T[,] result = new T[Rows, other.Columns];

        
    }
}