using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items_SO", menuName = "Scriptable Objects/Items")]
public class Items_SO : ScriptableObject
{
    public List<Item> Items;
}

public enum ItemName
{
    ball,
    bathingSuit,
    sunglasses,
}

[System.Serializable]
public class Item
{
    public ItemName Name;
    public Sprite Sprite;
}