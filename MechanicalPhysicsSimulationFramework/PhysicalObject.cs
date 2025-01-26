// Class representing a physical object in motion
public class PhysicalObject
{
    private string v1;
    private int v2;
    private Point2D<double> point2D1;
    private Point2D<double> point2D2;

    public PhysicalObject(string v1, int v2, Point2D<double> point2D1, Point2D<double> point2D2)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.point2D1 = point2D1;
        this.point2D2 = point2D2;
    }
}