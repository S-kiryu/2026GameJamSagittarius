using UnityEngine;

/// <summary>
/// アイテムクラス
/// </summary>
public class Item : MonoBehaviour
{
    /// <summary>
    /// 選択してるかわかるようにするふち
    /// </summary>
    [SerializeField] private GameObject selectionBorder;
    /// <summary>
    /// ItemData property
    /// </summary>
    private ItemData itemData;
    /// <summary>
    /// 選択済みかどうか
    /// </summary>
    private bool isSelected;

    private void SetItemData(ItemData data)
    {
        itemData = data;
    }

    /// <summary>
    /// アイテムの初期化処理
    /// </summary>
    private void Initialize()
    {
        
    }

    /// <summary>
    /// 選択状態を切り替える
    /// </summary>
    private void ToggleSelection()
    {
        isSelected = !isSelected;
    }
}
