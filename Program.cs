using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TurtleApp.Classes;
using TurtleApp.Classes.Actions;

namespace TurtleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            GameDataParser gameDataParser = new GameDataParser();
            GameData gameData = gameDataParser.GetGameData("Text.txt");
            System.Console.WriteLine(gameData.ActionSequences[0]);

            GameSimulation simulation = new GameSimulation();
            simulation.Init(
                gameData.BoardSize,
                gameData.StartingPosition,
                gameData.EndPosition,
                gameData.MinePositions,
            gameData.ActionSequences[0].ToList()
                );
        }
    }
}


//Mine Hit Sequence 
// new List<string>{"R", "M", "R", "M","L","M", "R", "M", "M", "L", "M", "R", "M", "M"} //2,3

//Success Sequence 
// new List<string> { "R", "M", "M", "M", "R", "M", "M", "L", "M", "R", "M", "M" } //2,3

//Fail Sequence
// new List<string> { "R", "M", "M", "M", "R", "M", "M", "L", "M", "R", "M" } //2,3
