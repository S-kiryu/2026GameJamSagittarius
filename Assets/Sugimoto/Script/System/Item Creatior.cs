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
    [SerializeField] private List<ItemData> _itemDataList;
    /// <summary>
    /// アイテムのプレハブ
    /// </summary>
    [SerializeField] private Item _itemPrefab;
    /// <summary>
    /// アイテムの親トランスフォームを表す。
    /// </summary>
    [SerializeField] private Transform _itemParent;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;

    /// <summary>
    /// アイテム生成
    /// </summary>
    private void ItemGenerate() 
    {
        _gridLayoutGroup.constraintCount = _itemDataList.Count;
        foreach (var itemData in _itemDataList)
        {
            var item = Instantiate(_itemPrefab, _itemParent);
            item.SetItemData(itemData);
        }
    }
}
