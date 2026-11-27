using Kiya.Data;
using System;
using System.IO;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    private static string filePath;
    private const int MAX_RANK_NUM = 10;

    private float newRankClearTimer;
    private string newRankThemeName;


    [SerializeField] private TMP_Text clearTimerText;
    [SerializeField] private Transform newRankInputPanel;



    private void ShowClearTimer(float timer)
    {
        clearTimerText.text = "残り時間：　" + Timer.FormatTime(timer);
    }


    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "ranking.json");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ToggleNewRankInput(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsertRank(Rank newRank)
    {
        RankData data = LoadRank();

        if (IsInRank((newRank.time), out int index))
        {
            data.ranks.Insert(index, newRank);
        }
        if (data.ranks.Count > MAX_RANK_NUM)
        {
            data.ranks.RemoveRange(MAX_RANK_NUM, data.ranks.Count - MAX_RANK_NUM);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        Debug.Log($"Saved JSON to: {filePath}");
    }

    /// <summary>
    /// timerはランクに入れられるかとうか。
    /// rankはいれる場合ランクのindex (0~MAX_RANK_NUM-1), いれない場合は-1
    /// </summary>
    public bool IsInRank(float timer, out int rank)
    {
        RankData data = LoadRank();
        int i = 0;
        while (i < data.ranks.Count)
        {
            if (timer > data.ranks[i].time)
            {
                break;
            }
            i++;
        }

        if (i < MAX_RANK_NUM)
        {
            rank = i;
            return true;
        }
        rank = - 1;
        return false;
    }

    public RankData LoadRank()
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





    public void HandleStageResult(StageResult result)
    {
        if (!result.IsSuccess) return;

        float timer = result.ClearTime;
        ShowClearTimer(timer);

        if (IsInRank(timer, out int index))
        {
            newRankClearTimer = result.ClearTime;
            newRankThemeName = result.Stage.ThemeName;
            ToggleNewRankInput(true);
        }
    }




    private void ToggleNewRankInput(bool isVisible)
    {
        if (newRankInputPanel)
        {
            newRankInputPanel.gameObject.SetActive(isVisible);
        }
    }


    public void OnSubmitRankName(string name)
    {
        InsertRank(new Rank(name, newRankClearTimer, newRankThemeName));
        ToggleNewRankInput(false);
    }
}


