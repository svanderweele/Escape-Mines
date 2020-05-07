using System.Collections.Generic;
using System.Numerics;
using TurtleApp.Classes.Actions;

namespace TurtleApp.Classes
{
    public class GameSimulation : IGameSimulation
    {
        private GameBoard _gameBoard;
        private List<ITurtleAction> _turtleActions;
        private ITurtle _turtle;

        private SimulationResult _result;
        public void Init(Vector2 boardSize, Vector2 startingPosition, int startingRotation, Vector2 endPosition, List<Vector2> minePositions, List<string> actions)
        {
            _turtle = new Turtle();
            _turtle.Init((int) startingPosition.X, (int)startingPosition.Y, startingRotation);

            _gameBoard = new GameBoard();
            _gameBoard.SetSize((int)boardSize.X, (int)boardSize.Y);

            foreach (Vector2 pos in minePositions)
            {
                _gameBoard.SetTile((int)pos.X, (int)pos.Y, TileType.Mine);
            }

            _gameBoard.SetTile((int)startingPosition.X, (int)startingPosition.Y, TileType.Start);
            _gameBoard.SetTile((int)endPosition.X, (int)endPosition.Y, TileType.End);

            _turtleActions = new List<ITurtleAction>();
            foreach (string action in actions)
            {
                if (action == "L")
                {
                    _turtleActions.Add(new RotateAction(_turtle, RotationDirection.Left, RotationDirection.Right));
                }
                if (action == "R")
                {
                    _turtleActions.Add(new RotateAction(_turtle, RotationDirection.Right, RotationDirection.Left));
                }
                if (action == "M")
                {
                    _turtleActions.Add(new MoveAction(_turtle, _gameBoard));
                }
            }
        }

        public SimulationResult RunSimulation()
        {
            Vector2 turtlePosition = _turtle.GetPosition();
            TileType tileType = TileType.Empty;
            foreach (ITurtleAction action in _turtleActions)
            {
                action.Execute();

                turtlePosition = _turtle.GetPosition();
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

            switch (tileType)
            {
                case TileType.Empty:
                    _result = SimulationResult.StillInDanger;
                    break;
                case TileType.End:
                    _result = SimulationResult.ReachedEnd;
                    break;
                case TileType.Mine:
                    _result = SimulationResult.HitMine;
                    break;
            }

            return _result;
        }


        public void LogResult()
        {
            string resultString = "";
            switch (_result)
            {
                case SimulationResult.StillInDanger:
                    resultString = "Still in Danger – it the turtle has not yet found the exit or hit a mine";
                    break;
                case SimulationResult.ReachedEnd:
                    resultString = "Success – if the turtle finds the exit point";
                    break;
                case SimulationResult.HitMine:
                    resultString = "Mine Hit – if the turtle hits a mine";
                    break;
            }

            System.Console.WriteLine("Result: {0}", resultString);
        }
    }
}