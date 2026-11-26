using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Theme_SO", menuName = "Scriptable Objects/Theme")]
public class Themes_SO : ScriptableObject
{
    public List<Theme> Themes;
}

public enum ThemeName
{
    Beach,
    Picnic,
    Camping,

}

[System.Serializable]
public class Theme
{
    public ThemeName Name;
    public Sprite Sprite;
}