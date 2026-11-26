using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// アイテム生成をするクラス
/// </summary>
public class ItemCreatior : MonoBehaviour
{
    [Header("アイテム生成設定")]
    /// <summary>
    /// アイテムのプレハブ
    /// </summary>
    [SerializeField] private PicItem _itemPrefab;
    /// <summary>
    /// アイテムの親トランスフォームを表す。
    /// </summary>
    [SerializeField] private Transform _itemParent;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private int _itemsPerRow = 4;
    [SerializeField] private ItemClickHistory _itemClickHistory;

    /// <summary>
    /// アイテム生成
    /// </summary>
    public void GenerateItems(IReadOnlyList<Sprite> itemImages)
    {
        _gridLayoutGroup.constraintCount = _itemsPerRow;
        foreach (Sprite sprite in itemImages)
        {
            if (sprite == null)
            {
                continue;
            }

            var item = Instantiate(_itemPrefab, _itemParent);
            var itemData = new ItemData(sprite.name, sprite);
            item.SetItemData(itemData, _itemClickHistory);
        }
    }
}
