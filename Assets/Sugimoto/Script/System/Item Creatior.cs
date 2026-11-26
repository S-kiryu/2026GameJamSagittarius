using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// アイテム生成をするクラス
/// </summary>
public class ItemCreatior : MonoBehaviour
{
    /// <summary>
    /// 生成するアイテムのリスト
    /// </summary>
    [SerializeField] private List<ItemData> _itemDataList;
    /// <summary>
    /// アイテムのプレハブ
    /// </summary>
    [SerializeField] private Item _itemPrefab;

    /// <summary>
    /// アイテム生成
    /// </summary>
    private void ItemGenerate() 
    {

    }
}
