namespace SimpleSnake.GameObjects.Foods
{
    using System;

    public class FoodDollar : Food
    {
        private const char DOLLAR = '$';
        private const int POINTS = 2;
        private const ConsoleColor COLOR = ConsoleColor.Green;

        public FoodDollar(Field field)
            : base(field, DOLLAR, POINTS, COLOR)
        {
        }
    }
}
