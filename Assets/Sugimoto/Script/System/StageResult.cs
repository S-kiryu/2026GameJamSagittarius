using System;
using System.Collections.Generic;

/// <summary>
/// インゲームからリザルトシーンへ渡すステージ結果。
/// </summary>
public class StageResult
{
    public bool IsSuccess { get; }
    public IReadOnlyList<ItemData> SelectedItems { get; }

    private StageResult(bool isSuccess, IReadOnlyList<ItemData> selectedItems)
    {
        IsSuccess = isSuccess;
        SelectedItems = selectedItems;
    }

    /// <summary>
    /// 引継ぎができる機能
    /// </summary>
    /// <param name="isSuccess">クリアしているかどうか</param>
    /// <param name="selectedItems">選択したアイテム</param>
    public static void Save(bool isSuccess, IReadOnlyList<PicItem> selectedItems)
    {
        var itemData = new ItemData[selectedItems.Count];
        for (int i = 0; i < selectedItems.Count; i++)
        {
            itemData[i] = selectedItems[i].Data;
        }

        StageResultStore.Save(new StageResult(isSuccess, Array.AsReadOnly(itemData)));
    }

    public static bool TryTake(out StageResult result)
    {
        return StageResultStore.TryTake(out result);
    }
}
