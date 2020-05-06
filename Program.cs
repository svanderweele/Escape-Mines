using System;
using System.Collections.Generic;
using System.Numerics;
using TurtleApp.Classes;
using TurtleApp.Classes.Actions;

namespace TurtleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSimulation simulation = new GameSimulation();
            simulation.Init(
                new Vector2(5, 4),
                new Vector2(0, 1),
                new Vector2(4, 3),
                new List<Vector2> { new Vector2(1, 1), new Vector2(3, 2) },
                new ActionSequence(new ITurtleAction[] { })
                );
        }
    }
}
