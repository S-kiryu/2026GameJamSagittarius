using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 選択されたアイテムのデータを保存するクラス
/// </summary>
public class ItemClickHistory : MonoBehaviour
{
    private readonly List<PicItem> _selectedItems = new List<PicItem>();
    public IReadOnlyList<PicItem> SelectedItems => _selectedItems;
    public bool InputLocked { get; set; }
    public const int MaxSelectionCount = 3;
    /// <summary>
    /// アイテムを選択する機能
    /// </summary>
    /// <param name="item"></param>
    public void ToggleSelection(PicItem item)
    {
        if (InputLocked)
        {
            return;
        }

        if (_selectedItems.Remove(item))
        {
            item.SetSelected(false);
            return;
        }
        //三つ以上選ばれた時は一番初めに選んでいたものを消す
        if (_selectedItems.Count >= MaxSelectionCount)
        {
            PicItem oldestItem = _selectedItems[0];
            _selectedItems.RemoveAt(0);
            oldestItem.SetSelected(false);
        }

        _selectedItems.Add(item);
        item.SetSelected(true);
    }
}