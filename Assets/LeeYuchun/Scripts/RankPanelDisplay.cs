using UnityEngine;
using TMPro;

public class RankPanelDisplay : MonoBehaviour
{
    [SerializeField] private RankManager rankManager;
    [SerializeField] RankPanel_RankLine[] rankLines;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RankData rankData = rankManager.LoadRank();

        int i = 0;
        while (i < rankData.ranks.Count)
        {
            Rank rank = rankData.ranks[i];
            rankLines[i].SetRankLine(rank.themeName, rank.name, rank.time);
            i++;
        }
        if (i < RankManager.MAX_RANK_NUM)
        {
            while (i < RankManager.MAX_RANK_NUM)
            {
                rankLines[i].SetRankEmptyLine();
                i++;
            }
        }
    }
}
