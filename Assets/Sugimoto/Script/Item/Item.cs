using UnityEngine;

/// <summary>
/// アイテムクラス
/// </summary>
public class Item : MonoBehaviour
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
    /// ItemData property
    /// </summary>
    private ItemData itemData;

    private void Awake()
    {
        UpdateBorder();
    }

    public void ToggleSelection()
    {
        isSelected = !isSelected;
        UpdateBorder();
    }

    private void SetItemData(ItemData data)
    {
        itemData = data;
    }


    private void UpdateBorder()
    {
        if (selectionBorder != null && selectionBorder.activeSelf != isSelected)
        {
            selectionBorder.SetActive(isSelected);
        }
    }

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
