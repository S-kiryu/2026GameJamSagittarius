using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ステージのデータ
/// </summary>
[CreateAssetMenu(fileName = "StageData", menuName = "Data/StageData")]
public class StageData : ScriptableObject
{
    /// <summary>
    /// ステージの名前
    /// </summary>
    [SerializeField] private string _themeName;
    /// <summary>
    /// このステージに出てくるアイテム
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
