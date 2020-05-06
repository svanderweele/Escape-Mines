using System.Collections.Generic;
using System.Numerics;
using TurtleApp.Classes.Actions;

namespace TurtleApp.Classes
{
    public class GameData
    {

        public Vector2 BoardSize;
        public Vector2 StartingPosition;
        public Vector2 EndPosition;
        public int TurtleRotation;
        public List<Vector2> MinePositions;
        public List<string[]> ActionSequences;
    }
}