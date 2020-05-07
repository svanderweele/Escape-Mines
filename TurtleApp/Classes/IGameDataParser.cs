namespace TurtleApp.Classes
{
    public interface IGameDataParser
    {
        GameData GetGameData(string filePath);
    }
}