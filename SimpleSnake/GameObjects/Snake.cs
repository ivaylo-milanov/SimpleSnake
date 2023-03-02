namespace SimpleSnake.GameObjects
{
    using Foods;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Snake
    {
        private readonly Queue<Point> snake;
        private readonly IList<Food> foods;
        private readonly Field field;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
        private int points;

        private const char SNAKE_SYMBOL = '\u25CF';
        private const char EMPTY_SPACE = ' ';

        private Snake()
        {
            this.snake = new Queue<Point>();
            foods = new List<Food>();
            this.foodIndex = RandomFoodNumber;
        }

        public Snake(Field field):this()
        {
            this.field = field;
            GetFoods();
            CreateSnake();
        }

        public int RandomFoodNumber => new Random().Next(0, foods.Count);

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                snake.Enqueue(new Point(2, topY));
            }

            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snake);
        } 

        private void GetFoods()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] foodTypes = assembly
                .GetTypes()
                .Where(x => x.Name.ToLower().StartsWith("food") && !x.IsAbstract)
                .ToArray();

            foreach (Type type in foodTypes)
            {
                Food food = (Food)Activator.CreateInstance(type, new object[] { field });
                this.foods.Add(food);
            }
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = direction.LeftX + snakeHead.LeftX;
            this.nextTopY = direction.TopY + snakeHead.TopY;
        }

        public bool IsMoving(Point direction)
        {
            Point currSnakeHead = this.snake.Last();

            GetNextPoint(direction, currSnakeHead);

            bool isPointOfSnake = this.snake.Any(x => x.LeftX == this.nextLeftX && x.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point nexSnakeHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.field.IsPointOfField(nexSnakeHead))
            {
                return false;
            }

            this.snake.Enqueue(nexSnakeHead);
            nexSnakeHead.Draw(SNAKE_SYMBOL);

            if (foods[foodIndex].IsFoodPoint(nexSnakeHead))
            {
                this.Eat(direction, currSnakeHead);
            }

            Point snakeTail = this.snake.Dequeue();
            snakeTail.Draw(EMPTY_SPACE);

            return true;
        }

        private void Eat(Point direction, Point currSnakeHead)
        {
            int length = foods[foodIndex].FoodPoint;
            points += length;
            
            for (int i = 0; i < length; i++)
            {
                this.snake.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currSnakeHead);
            }

            VisualisePoints();
            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snake);
            
        }

        private void VisualisePoints()
        {
            Console.SetCursorPosition(this.field.LeftX + 2, 1);
            Console.Write($"Player points: {this.points}");
        }
    }
}
