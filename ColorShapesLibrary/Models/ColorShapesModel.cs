namespace ColorShapesLibrary
{
    public class ColorShapesModel
    {
        public string Shape { get; set; }

        public string Color { get; set; }

        public ColorShapesModel()
        {
        }

        public ColorShapesModel(ColorShapesModel colorShapes)
        {
            this.Shape = colorShapes.Shape;
            this.Color = colorShapes.Color;
        }
    }
}
