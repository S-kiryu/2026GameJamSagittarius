using UnityEngine;

/// <summary>
/// アイテムのデータ
/// </summary>
public class ItemData
{
    private string _itemName;
    private Sprite _itemImage;

    public ItemData(string itemName, Sprite itemImage)
    {
        _itemName = itemName;
        _itemImage = itemImage;
    }

    /// <summary>
    /// アイテムの名前
    /// </summary>
    public string ItemName => _itemName;
    /// <summary>
    /// アイテム画像
    /// </summary>
    public Sprite ItemImage => _itemImage;
}