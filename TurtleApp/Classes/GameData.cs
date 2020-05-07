using System.Collections.Generic;
using System.Numerics;
using TurtleApp.Classes.Actions;

namespace TurtleApp.Classes
{
    public class GameData
    {

        public const string FilePathIncomplete = "/Users/simonvanderweelepersonal/src/NET/TurtleApp/TurtleApp/Incomplete.txt";
        public const string FilePathSuccess = "/Users/simonvanderweelepersonal/src/NET/TurtleApp/TurtleApp/ReachedEnd.txt";
        public const string FilePathHitMine = "/Users/simonvanderweelepersonal/src/NET/TurtleApp/TurtleApp/HitMine.txt";

        public Vector2 BoardSize;
        public Vector2 StartingPosition;
        public Vector2 EndPosition;
        public int TurtleRotation;
        public List<Vector2> MinePositions;
        public List<string[]> ActionSequences;
    }
}