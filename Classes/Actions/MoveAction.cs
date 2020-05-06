using System.Numerics;

namespace TurtleApp.Classes.Actions
{
    public class MoveAction : ITurtleAction
    {
        private readonly ITurtle _turtle;
        private readonly IGameBoard _gameBoard;
        public MoveAction(ITurtle turtle, IGameBoard gameBoard)
        {
            _turtle = turtle;
            _gameBoard = gameBoard;
        }

        public void Execute()
        {
            _turtle.Move(1);
            Vector2 turtlePos = _turtle.GetPosition();
            if (_gameBoard.IsPositionOnBoard((int)turtlePos.X, (int)turtlePos.Y) == false)
            {
                System.Console.WriteLine("Position is not on grid {0},{1}", turtlePos.X, turtlePos.Y);
                Revert();
            }

            turtlePos = _turtle.GetPosition();
            System.Console.WriteLine("Turtle Current Position {0},{1}", turtlePos.X, turtlePos.Y);
        }

        public void Revert()
        {
            _turtle.Move(-1);
        }
    }
}