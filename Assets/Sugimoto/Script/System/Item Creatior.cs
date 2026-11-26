using NUnit.Framework;
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
    /// 生成するアイテムのリスト
    /// </summary>
    [SerializeField] private List<Sprite> _itemImageList;
    /// <summary>
    /// アイテムのプレハブ
    /// </summary>
    [SerializeField] private Item _itemPrefab;
    /// <summary>
    /// アイテムの親トランスフォームを表す。
    /// </summary>
    [SerializeField] private Transform _itemParent;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private int _itemsPerRow = 4;

    private void Start()
    {
        ItemGenerate();
    }

    /// <summary>
    /// アイテム生成
    /// </summary>
    private void ItemGenerate() 
    {
        _gridLayoutGroup.constraintCount = _itemsPerRow;
        foreach (var Sprite in _itemImageList)
        {
            var item = Instantiate(_itemPrefab, _itemParent);
            var itemData = new ItemData(Sprite.name, Sprite);
            item.SetItemData(itemData);
        }
    }
}
