namespace SimpleSnake.GameObjects.Foods
{
    using System;

    public class FoodHash : Food
    {
        private const char HASH = '#';
        private const int POINTS = 3;
        private const ConsoleColor COLOR = ConsoleColor.Red;

        public FoodHash(Field field)
            : base(field, HASH, POINTS, COLOR)
        {
        }
    }
}
