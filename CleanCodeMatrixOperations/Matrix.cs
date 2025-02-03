// Represents a mathematical matrix
public class Matrix
{
    public int Rows;
    public int Columns;
    private readonly double[,] _data;

    public Matrix(int rows, int columns){
        Rows = rows;
        Columns = columns;
        _data = new double[rows, columns];
    }

    // Access matrix elements
    public double this[int row, int col]{
        get {
             return _data[row, col];
        }
        set {
            _data[row, col] = value;
        }
    }

    // Clone the matrix
    public Matrix Clone()
    {
        var clone = new Matrix(Rows, Columns);
        for (int i = 0; i < Rows; i++){
            for (int j = 0; j < Columns; j++){
                clone[i, j] = _data[i, j];
            }
        }
        return clone;
    }

        // Validate indices
    private void ValidateIndices(int row, int col)
    {
        if (row < 0 || row >= Rows || col < 0 || col >= Columns)
            throw new IndexOutOfRangeException("Invalid matrix indices.");
    }


}