using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// お題のデータ
/// </summary>
[CreateAssetMenu(fileName = "ThemeData", menuName = "Data/ThemeData")]
public class ThemeData : ScriptableObject
{
    /// <summary>
    /// お題
    /// </summary>
    [SerializeField] private string _themeName;
    /// <summary>
    /// このお題に出てくるアイテム
    /// </summary>
    [SerializeField] private List<Sprite> _themeImageList = new List<Sprite>();
    /// <summary>
    /// 正解の画像
    /// </summary>
    [SerializeField] private List<Sprite> _correctImage;
    public string ThemeName => _themeName;

    public IReadOnlyList<Sprite> ItemImages => _themeImageList;

    /// <summary>
    /// 正解の画像
    /// </summary>
    public IReadOnlyList<Sprite> CorrectImages => _correctImage;

}
