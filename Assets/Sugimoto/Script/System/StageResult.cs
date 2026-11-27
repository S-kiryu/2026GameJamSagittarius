using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// インゲームからリザルトシーンへ渡すステージ結果。
/// </summary>
public class StageResult
{
    public bool IsSuccess { get; }
    public IReadOnlyList<ItemData> SelectedItems { get; }
    public Sprite Background { get; }
    public StageData Stage { get; }

    public float ClearTime { get; }

    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="isSuccess">クリアしたかどうか</param>
    /// <param name="selectedItems">選択したアイテム</param>
    /// <param name="background">背景</param>
    /// <param name="stage">ステージのデータ</param>
    private StageResult(bool isSuccess, IReadOnlyList<ItemData> selectedItems, Sprite background, StageData stage, float clearTime)
    {
        IsSuccess = isSuccess;
        SelectedItems = selectedItems;
        Background = background;
        Stage = stage;
        ClearTime = clearTime;
    }

    /// <summary>
    /// 引継ぎができる機能
    /// </summary>
    /// <param name="isSuccess">クリアしているかどうか</param>
    /// <param name="selectedItems">選択したアイテム</param>
    /// <param name="background">プレイしたステージの背景</param>
    /// <param name="stage">プレイしたステージ</param>
    /// <param name="clearTime">クリアの残り時間</param>
    public static void Save(bool isSuccess, IReadOnlyList<PicItem> selectedItems, Sprite background = null, StageData stage = null, float clearTime = 0)
    {
        var itemData = new ItemData[selectedItems.Count];
        for (int i = 0; i < selectedItems.Count; i++)
        {
            itemData[i] = selectedItems[i].Data;
        }

        StageResultStore.Save(new StageResult(isSuccess, Array.AsReadOnly(itemData), background, stage, clearTime));
    }

    public static bool TryTake(out StageResult result)
    {
        return StageResultStore.TryTake(out result);
    }
}
