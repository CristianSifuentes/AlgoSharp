// Generic class for a point in 2D space
public class Point2D<T> where T: struct{
    private T X;
    private T Y;

    public Point2D(T x, T y){
        X = x;
        Y = y;
    }

    public override string ToString() => $"({X}, {Y})";
}

    