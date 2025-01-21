// Interface for matrix operations
public interface IMatrixOperations {
    Matrix Add (Matrix other);
    Matrix Subtract(Matrix other);
    Matrix Multiply(Matrix other);
    double Determinant();
}