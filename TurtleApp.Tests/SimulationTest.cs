using System;
using Xunit;
using TurtleApp.Classes;
using TurtleApp.Classes.Actions;
using System.Linq;

namespace TurtleApp.Tests
{
    public class SimulationTest
    {
        [Fact]
        public void PassingTest()
        {
               GameDataParser gameDataParser = new GameDataParser();
            GameData gameData = gameDataParser.GetGameData(GameData.SuccessPath);

            GameSimulation simulation = new GameSimulation();
            simulation.Init(
                gameData.BoardSize,
                gameData.StartingPosition,
                gameData.EndPosition,
                gameData.MinePositions,
            gameData.ActionSequences[0].ToList()
                );
                
            Assert.Equal(5, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
