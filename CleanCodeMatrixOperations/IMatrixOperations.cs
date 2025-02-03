// Interface for matrix operations
public interface IMatrixOperations{  
    Matrix Add(Matrix a, Matrix b);
    Matrix Subtract(Matrix a, Matrix b);
    Matrix Multiply(Matrix a, Matrix b);
    double Determinant(Matrix matrix);
    Matrix Transpose(Matrix matrix);
}