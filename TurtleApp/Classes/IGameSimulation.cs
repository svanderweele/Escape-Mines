using System.Collections.Generic;
using System.Numerics;
using TurtleApp.Classes.Actions;

namespace TurtleApp.Classes
{
    public enum SimulationResult
    {
        StillInDanger = 0,
        ReachedEnd = 1,
        HitMine = 2
    }


    public interface IGameSimulation
    {
        void Init(Vector2 boardSize, Vector2 startingPosition,int startingRotation, Vector2 endPosition, List<Vector2> minePositions, List<string> actions);

        SimulationResult RunSimulation();
        void LogResult();
    }
}