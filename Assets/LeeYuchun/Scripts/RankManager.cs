using System.IO;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    private static string filePath;

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "ranking.json");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void InsertRank(Rank newRank)
    {
        Debug.Log(newRank.name +  newRank.time);
        RankData data = LoadRank();

        // TODO: timer比較
        int i = 0;
        while (i < data.ranks.Count)
        {
            if (newRank.time < data.ranks[i].time) {
                break;
            }
            i++;
        }
        data.ranks.Insert(i, newRank);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        Debug.Log($"Saved JSON to: {filePath}");
    }

    public static RankData LoadRank()
    {
        if(!File.Exists(filePath))
        {
            Debug.LogWarning($"Rank file not found at: {filePath}");
            return new RankData();
        }

        string json = File.ReadAllText(filePath);
        RankData loadedData = JsonUtility.FromJson<RankData>(json);
        return loadedData;
    }
}


