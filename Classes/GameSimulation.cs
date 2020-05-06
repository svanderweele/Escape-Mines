using System.Collections.Generic;
using System.Numerics;
using TurtleApp.Classes.Actions;

namespace TurtleApp.Classes
{
    public class GameSimulation : IGameSimulation
    {
        private GameBoard _gameBoard;
        public void Init(Vector2 boardSize, Vector2 startingPosition, Vector2 endPosition, List<Vector2> minePositions, IActionSequence actionSequence)
        {
            _gameBoard = new GameBoard();
            _gameBoard.SetSize((int)boardSize.X, (int)boardSize.Y);

            foreach (Vector2 pos in minePositions)
            {
                _gameBoard.SetTile((int)pos.X, (int)pos.Y, TileType.Mine);
            }

            _gameBoard.SetTile((int)startingPosition.X, (int)startingPosition.Y, TileType.Start);
            _gameBoard.SetTile((int)endPosition.X, (int)endPosition.Y, TileType.End);

            System.Console.WriteLine(_gameBoard);
        }
    }
}