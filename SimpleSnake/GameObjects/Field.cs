namespace SimpleSnake.GameObjects
{
    public class Field : Point
    {
        private const char FIELD_SYMBOL = '\u25A0';

        public Field(int leftX, int topY)
            : base(leftX, topY)
        {
            InitializeFieldBorders();
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, FIELD_SYMBOL);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, FIELD_SYMBOL);
            }
        }

        private void InitializeFieldBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);

            SetVerticalLine(0);
            SetVerticalLine(this.LeftX - 1);
        }

        public bool IsPointOfField(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 0 || snake.LeftX == this.LeftX - 1 || snake.TopY == this.TopY;
        }
    }
}
