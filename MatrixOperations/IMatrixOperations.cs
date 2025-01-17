public interface IMatrixOperations<T> where T: struct {
   
   Matrix<T> Multiply(Matrix<T> other);
   Matrix<T> Transpose();
   double Determinant();

}