namespace SimpleSnake.GameObjects.Foods
{
    using System;

    public class FoodAsterix : Food
    {
        private const char ASTERIX = '*';
        private const int POINTS = 1;
        private const ConsoleColor COLOR = ConsoleColor.Yellow;

        public FoodAsterix(Field field)
            : base(field, ASTERIX, POINTS, COLOR)
        {
        }
    }
}
