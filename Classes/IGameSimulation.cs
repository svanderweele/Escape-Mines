using System.Collections.Generic;
using System.Numerics;
using TurtleApp.Classes.Actions;

namespace TurtleApp.Classes
{
    public interface IGameSimulation
    {
        void Init(Vector2 boardSize, Vector2 startingPosition, Vector2 endPosition, List<Vector2> minePositions, List<string> actions);
    }
}