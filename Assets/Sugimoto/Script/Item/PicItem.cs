using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイテムクラス
/// </summary>
public class PicItem : MonoBehaviour
{
    [Header("選択アイテムの設定")]
    /// <summary>
    /// 選択してるかわかるようにするふち
    /// </summary>
    [SerializeField] private GameObject selectionBorder;
    /// <summary>
    /// 選択済みかどうかTrueなら選択済み、Falseなら未選択
    /// </summary>
    [SerializeField] private bool isSelected;
    /// <summary>
    /// 画像イメージ
    /// </summary>
    [SerializeField] private Image image;

    private ItemData itemData;
    private ItemClickHistory itemClickHistory;
    internal ItemData Data => itemData;
    public Sprite ItemSprite => itemData?.ItemImage;

    private void Awake()
    {
        UpdateBorder();
    }

    /// <summary>
    /// 選択された時
    /// </summary>
    public void ToggleSelection()
    {
        itemClickHistory.ToggleSelection(this);
    }

    internal void SetSelected(bool selected)
    {
        isSelected = selected;
        UpdateBorder();
    }

    /// <summary>
    /// データをセット
    /// </summary>
    /// <param name="data"></param>
    public void SetItemData(ItemData data, ItemClickHistory clickHistory)
    {
        itemData = data;
        itemClickHistory = clickHistory;
        UpdateView();
    }

    /// <summary>
    /// イメージの更新
    /// </summary>
    private void UpdateView() 
    {
        if (image != null && itemData != null)
        {
            image.sprite = itemData.ItemImage;
        }
    }

    /// <summary>
    /// ふちを更新する
    /// </summary>
    private void UpdateBorder()
    {
        if (selectionBorder != null && selectionBorder.activeSelf != isSelected)
        {
            selectionBorder.SetActive(isSelected);
        }
    }

    /// <summary>
    /// デバック関連
    /// </summary>
#if UNITY_EDITOR
    private void OnValidate()
    {
        UnityEditor.EditorApplication.delayCall -= PreviewBorder;
        UnityEditor.EditorApplication.delayCall += PreviewBorder;
    }

    private void PreviewBorder()
    {
        if (this != null && !Application.isPlaying)
        {
            UpdateBorder();
        }
    }
#endif
}
