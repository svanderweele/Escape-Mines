using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace TurtleApp.Classes.Actions
{
    public class GameDataParser : IGameDataParser
    {
        public GameData GetGameData(string filePath)
        {
            GameData gameData = new GameData();

            string[] lines = File.ReadAllLines(filePath);

            string[] boardSizeString = lines[0].Split(" ");
            gameData.BoardSize = new Vector2(int.Parse(boardSizeString[0]), int.Parse(boardSizeString[1]));

            string[] minePositionsString = lines[1].Split(" ");
            gameData.MinePositions = new List<Vector2>();
            foreach (string minePos in minePositionsString)
            {
                string[] minePosString = minePos.Split(",");
                Vector2 minePosition = new Vector2(int.Parse(minePosString[0]), int.Parse(minePosString[1]));
                gameData.MinePositions.Add(minePosition);
            }

            string[] endPositionString = lines[2].Split(" ");
            gameData.EndPosition = new Vector2(int.Parse(endPositionString[0]), int.Parse(endPositionString[1]));


            string[] startPositionString = lines[3].Split(" ");
            gameData.StartingPosition = new Vector2(int.Parse(startPositionString[0]), int.Parse(startPositionString[1]));
            int startingRotation = 0;
            switch (startPositionString[2])
            {
                case "N":
                    startingRotation = 0;
                    break;
                case "S":
                    startingRotation = 180;
                    break;
                case "E":
                    startingRotation = 90;
                    break;
                case "W":
                    startingRotation = 270;
                    break;
            }
            gameData.TurtleRotation = startingRotation;

            gameData.ActionSequences = new List<string[]>();
            for (int lineIndex = 3; lineIndex < lines.Length; lineIndex++)
            {
                string[] actionsString = lines[lineIndex].Split(" ");
                gameData.ActionSequences.Add(actionsString);
            }

            return gameData;
        }
    }
}