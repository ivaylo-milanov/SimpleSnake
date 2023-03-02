namespace SimpleSnake.GameObjects.Foods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private Random random;
        private Field field;
        private char foodSymbol;
        private ConsoleColor color;

        protected Food(Field field, char foodSymbol, int points, ConsoleColor color)
            : base(field.LeftX, field.TopY)
        {
            random = new Random();
            this.field = field;
            this.foodSymbol = foodSymbol;
            this.FoodPoint = points;
            this.color = color;
        }

        public int FoodPoint { get; private set; }

        public void SetRandomPosition(Queue<Point> snake)
        {
            this.LeftX = random.Next(2, field.LeftX - 2);
            this.TopY = random.Next(2, field.TopY - 2);

            bool isPointOfSnake = snake
                .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = random.Next(2, field.LeftX - 2);
                this.TopY = random.Next(2, field.TopY - 2);

                isPointOfSnake = snake
                    .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = this.color;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY && snake.LeftX == this.LeftX;
        }

    }
}
