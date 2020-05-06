using System.Collections.Generic;
using System.Numerics;
using TurtleApp.Classes.Actions;

namespace TurtleApp.Classes
{
    public class GameSimulation : IGameSimulation
    {
        private GameBoard _gameBoard;
        public void Init(Vector2 boardSize, Vector2 startingPosition, Vector2 endPosition, List<Vector2> minePositions, List<string> actions)
        {
            ITurtle turtle = new Turtle();
            turtle.Init(0, 0, 0);

            _gameBoard = new GameBoard();
            _gameBoard.SetSize((int)boardSize.X, (int)boardSize.Y);

            foreach (Vector2 pos in minePositions)
            {
                _gameBoard.SetTile((int)pos.X, (int)pos.Y, TileType.Mine);
            }

            _gameBoard.SetTile((int)startingPosition.X, (int)startingPosition.Y, TileType.Start);
            _gameBoard.SetTile((int)endPosition.X, (int)endPosition.Y, TileType.End);
            System.Console.WriteLine(_gameBoard);

            List<ITurtleAction> turtleActions = new List<ITurtleAction>();
            foreach (string action in actions)
            {
                if (action == "L")
                {
                    turtleActions.Add(new RotateAction(turtle, RotationDirection.Left, RotationDirection.Right));
                }
                if (action == "R")
                {
                    turtleActions.Add(new RotateAction(turtle, RotationDirection.Right, RotationDirection.Left));
                }
                if (action == "M")
                {
                    turtleActions.Add(new MoveAction(turtle, _gameBoard));
                }
            }

            Vector2 turtlePosition = turtle.GetPosition();
            TileType tileType = TileType.Empty;
            foreach (ITurtleAction action in turtleActions)
            {
                action.Execute();

                turtlePosition = turtle.GetPosition();
                tileType = _gameBoard.GetTileType((int)turtlePosition.X, (int)turtlePosition.Y);
                if (tileType == TileType.Mine)
                {
                    break;
                }

                if (tileType == TileType.End)
                {
                    break;
                }
            }

            string result = "";
            switch (tileType)
            {
                case TileType.Empty:
                    result = "Still in Danger – it the turtle has not yet found the exit or hit a mine";
                    break;
                case TileType.End:
                    result = "Success – if the turtle finds the exit point";
                    break;
                case TileType.Mine:
                    result = "Mine Hit – if the turtle hits a mine";
                    break;
            }

            System.Console.WriteLine("Result: {0}", result);
        }
    }
}