using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHistory : MonoBehaviour
{
    private Stack<Item> _clickHistory = new Stack<Item>();

    /// <summary>
    /// アイテムを入れこむ
    /// </summary>
    /// <param name="item"></param>
    public void AddToHistory(Item item)
    {
        if(_clickHistory.Count == 3)
        {
            _clickHistory.Pop();
        }
        _clickHistory.Push(item);
    }
}
