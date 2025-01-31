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
}