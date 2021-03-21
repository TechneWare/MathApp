namespace MathApp.Shapes
{
    public abstract class Shape : IShape
    {
        private string _name;
        public string Name => _name;
        public string FullName => $"{_name} ({ShapeType}{(string.IsNullOrEmpty(SubType) ? "" : ":" + SubType)})";

        public double[] Sides { get; set; }
        public ShapeType ShapeType { get; set; }
        public string SubType { get; set; }

        public abstract double Perimeter { get; }
        public abstract double Area { get; }

        public Shape() { }
        public Shape(string name, double[] sides, ShapeType shapeType, string subType)
        {
            this._name = name;
            this.Sides = sides;
            this.ShapeType = shapeType;
            this.SubType = SubType;
        }
    }
}
