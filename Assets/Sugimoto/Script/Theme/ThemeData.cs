using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// お題のデータ
/// </summary>
public class ThemeData : ScriptableObject
{
    /// <summary>
    /// お題
    /// </summary>
    [SerializeField] private string _themeName;
    /// <summary>
    /// このお題に出てくるアイテム
    /// </summary>
    [SerializeField] private List<Sprite> _themeImageList;
    /// <summary>
    /// 正解の画像
    /// </summary>
    [SerializeField] private Sprite _correctImage;
}
