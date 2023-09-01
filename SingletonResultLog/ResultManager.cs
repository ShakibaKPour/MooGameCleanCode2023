namespace MooGameCleanCode2023.SingletonResultLog;
public class ResultManager : IResultManager
{
    
    private static ResultManager instance;
    private static readonly object _lock = new object();
    private readonly string resultFilePath = "result.txt";
    private ResultManager() { }

    public static ResultManager Instance
    {
        get
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null) instance = new ResultManager();
                }
               
            }
            return instance;
        }
    }

    public void SaveGameResult(string playerName, int guesses)
    {
        string data = $"{playerName}#&#{guesses}";

        using (StreamWriter output = File.AppendText(resultFilePath))
        {
            output.WriteLine(data);
        }
    }

    public List<PlayerData> GetPlayerDataList()
    {
        List<PlayerData> results = new List<PlayerData>();

        using (StreamReader input = new StreamReader(resultFilePath))
        {

            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int pos = results.FindIndex(p => p.Equals(pd));
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);
                }
            }
        }
        return results;
    }

}
