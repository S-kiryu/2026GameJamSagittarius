using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ステージのデータ
/// </summary>
[CreateAssetMenu(fileName = "StageData", menuName = "Data/StageData")]
public class StageData : ScriptableObject
{
    [Header("ステージ関連")]
    /// <summary>
    /// ステージの名前
    /// </summary>
    [SerializeField] private string _themeName;
    /// <summary>
    /// 選択画面の画像
    /// </summary>
    [SerializeField] private Sprite _selectImage;

    [Header("リザルト関連")]
    /// <summary>
    /// リザルト画面のバック背景
    /// </summary>
    [SerializeField] private Sprite _resultBackgroundImage;
    /// <summary>
    /// クリア時のキャライメージ
    /// </summary>
    [SerializeField] private Sprite _clearCharacterImage;
    /// <summary>
    /// 失敗時のキャライメージ
    /// </summary>
    [SerializeField] private Sprite _defeatCharacterImage;

    [Header("アイテム関連")]
    /// <summary>
    /// このステージに出てくるアイテム
    /// </summary>
    [SerializeField] 
    private List<Sprite> _themeImageList = new List<Sprite>();

    /// <summary>
    /// 正解の画像
    /// </summary>
    [SerializeField] 
    private List<Sprite> _correctImage = new List<Sprite>();
    public string ThemeName => _themeName;
    public Sprite SelectImage => _selectImage;
    public Sprite ResultBackgroundImage => _resultBackgroundImage;
    public Sprite ClearCharacterImage => _clearCharacterImage;
    public Sprite DefeatCharacterImage => _defeatCharacterImage;

    public IReadOnlyList<Sprite> ItemImages => _themeImageList;

    /// <summary>
    /// 正解の画像
    /// </summary>
    public IReadOnlyList<Sprite> CorrectImages => _correctImage;

}
