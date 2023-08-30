namespace MooGameCleanCode2023.Interfaces;

public interface IResultManager
{
        void SaveGameResult(string playerName, int guesses);
        List<PlayerData> GetPlayerDataList();
}
