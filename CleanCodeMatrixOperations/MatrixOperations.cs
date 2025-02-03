// Implementation of matrix operations
public class MatrixOperations : IMatrixOperations
{
    public Matrix Add(Matrix a, Matrix b)
    { 
        ValidateSameDimensions(a, b);
        var result = new Matrix(a.Rows , a.Columns);
        for (int i = 0; i < a.Rows; i++){
            for (int j = 0; j < a.Columns; j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        return result;
    }

    public double Determinant(Matrix matrix)
    {
        if (matrix.Rows != matrix.Columns)
            throw new InvalidOperationException("Determinant can only be calculated for square matrices.");
       return 0;
    }

    public Matrix Multiply(Matrix a, Matrix b)
    {
        if (a.Columns != b.Rows)
            throw new InvalidOperationException("Matrix multiplication dimensions mismatch.");

        var result = new Matrix(a.Rows, b.Columns);

        for (int i = 0; i < a.Rows; i++){
            for (int j = 0; j < b.Columns; j++){
                for (int k = 0; k < a.Columns; k++){
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        return result;
    }

    public Matrix Subtract(Matrix a, Matrix b)
    {
        ValidateSameDimensions(a, b);
        var result = new Matrix(a.Rows, a.Columns);

        for (int i = 0; i < a.Rows; i++){
            for (int j = 0; j < a.Columns; j++){
                result[i, j] = a[i, j] - b[i, j];
            }
        }

        return result;
    }

    public Matrix Transpose(Matrix matrix)
    {
        var result = new Matrix(matrix.Columns, matrix.Rows);

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                result[j, i] = matrix[i, j];
            }
        }
        return result;
    }

    private void ValidateSameDimensions(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new InvalidOperationException("Matrices must have the same dimensions.");
    }


}