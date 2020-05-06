using System.Numerics;

namespace TurtleApp.Classes
{
    public interface IGameBoard
    {
        void SetSize(int x, int y);
        void SetTile(int x, int y, TileType tileType);
        TileType GetTileType(int x, int y);
        Vector2 GetSize();

        string ToString();
        bool IsPositionOnBoard(int x, int y);
    }
}