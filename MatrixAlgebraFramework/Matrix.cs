// Base class for a Matrix
public class Matrix : MathematicalObject, IMatrixOperations
{
    private int v1;
    private int v2;

    public Matrix(int v1, int v2)
    {
        this.v1 = v1;
        this.v2 = v2;
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
        throw new NotImplementedException();
    }

    internal void Populate(double[,] doubles)
    {
        throw new NotImplementedException();
    }
}