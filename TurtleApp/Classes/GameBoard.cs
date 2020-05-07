using System.Numerics;
namespace TurtleApp.Classes
{
    public class GameBoard : IGameBoard
    {
        private TileType[,] _tiles;

        public Vector2 GetSize()
        {
            return new Vector2(_tiles.GetLength(0), _tiles.GetLength(1));
        }

        public TileType GetTileType(int x, int y)
        {
            if (x < 0 || x >= _tiles.GetLength(0) || y < 0 || y >= _tiles.GetLength(1))
            {
                throw new System.IndexOutOfRangeException("Position {x,y} is out of range");
            }

            return _tiles[x, y];
        }

        public bool IsPositionOnBoard(int x, int y)
        {
            return (x >= 0 && x < _tiles.GetLength(0) && y >= 0 && y < _tiles.GetLength(1));
        }

        public void SetSize(int x, int y)
        {
            _tiles = new TileType[x, y];

            for (int tileX = 0; tileX < x; tileX++)
            {
                for (int tileY = 0; tileY < y; tileY++)
                {
                    SetTile(tileX, tileY, TileType.Empty);
                }
            }
        }

        public void SetTile(int x, int y, TileType tileType)
        {
            _tiles[x, y] = tileType;
        }

        public override string ToString()
        {
            Vector2 size = GetSize();
            string s = "";
            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    s += _tiles[x, y].ToString() + ", ";
                }

                s += System.Environment.NewLine;
            }

            return s;
        }
    }
}