namespace SimpleSnake
{
    using GameObjects;
    using Core;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            
            Field field = new Field(60, 20);
            Snake snake = new Snake(field);

            IEngine engine = new Engine(field, snake);
            engine.Start();
        }
    }
}
