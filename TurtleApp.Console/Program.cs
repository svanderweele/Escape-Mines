using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TurtleApp.Classes;
using TurtleApp.Classes.Actions;

namespace TurtleAppConsole
{
    class Program
    {

        static void Main(string[] args)
        {

            GameDataParser gameDataParser = new GameDataParser();
            GameData gameData = gameDataParser.GetGameData(GameData.FilePathSuccess);

            foreach (string[] sequence in gameData.ActionSequences)
            {
                GameSimulation simulation = new GameSimulation();
                simulation.Init(
                    gameData.BoardSize,
                    gameData.StartingPosition,
                    gameData.TurtleRotation,
                    gameData.EndPosition,
                    gameData.MinePositions,
                    sequence.ToList()
                    );

                System.Console.WriteLine("------Simulation Started------");
                simulation.RunSimulation();
                simulation.LogResult();
            }
        }
    }
}

