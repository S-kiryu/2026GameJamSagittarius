using UnityEngine;

/// <summary>
/// アイテムのデータ
/// </summary>
[CreateAssetMenu(fileName = "NewItemData", menuName = "Items/Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private Sprite _itemImage;

    /// <summary>
    /// アイテムの名前
    /// </summary>
    public string ItemName => _itemName;
    /// <summary>
    /// アイテム画像
    /// </summary>
    public Sprite ItemImage => _itemImage;
}