// Generic class for a point in 2D space
public class Point2D<T> where T: struct{
    private T v1;
    private T v2;

    public Point2D(T v1, T v2){
        this.v1 = v1;
        this.v2 = v2;
    }
}