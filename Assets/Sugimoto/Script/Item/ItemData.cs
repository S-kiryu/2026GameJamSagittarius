using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイテムのデータ
/// </summary>
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Image itemImage;
}
