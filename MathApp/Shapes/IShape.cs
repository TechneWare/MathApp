namespace MathApp.Shapes
{
    public interface IShape
    {
        string Name { get; }
        string FullName { get; }
        ShapeType ShapeType { get; }
        string SubType { get; }
        double Perimeter { get; }
        double Area { get; }
    }
}
