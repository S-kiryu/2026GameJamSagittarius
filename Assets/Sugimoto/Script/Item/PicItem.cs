using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// アイテムクラス
/// </summary>
public class PicItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IScrollHandler
{
    private const float ScrollRotationDegrees = 15f;

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
    private RectTransform itemRect;
    private RectTransform itemParent;
    private Vector3 baseScale;
    private Vector2 grabOffset;
    private int? dragPointerId;
    internal ItemData Data => itemData;
    public Sprite ItemSprite => itemData?.ItemImage;

    private void Awake()
    {
        itemRect = (RectTransform)transform;
        itemParent = transform.parent as RectTransform;
        baseScale = itemRect.localScale;
        UpdateBorder();
    }

    internal void SetSpawnPose(Rect spawnArea, float angle)
    {
        itemRect.localRotation = Quaternion.Euler(0f, 0f, angle);
        Vector2 space = FitInside(spawnArea);
        baseScale = itemRect.localScale;
        itemRect.localPosition = spawnArea.center + new Vector2(
            Random.Range(-space.x, space.x), Random.Range(-space.y, space.y));
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left || dragPointerId.HasValue ||
            itemClickHistory == null || itemClickHistory.InputLocked || itemParent == null ||
            !RectTransformUtility.ScreenPointToLocalPointInRectangle(
                itemParent, eventData.pressPosition, eventData.pressEventCamera, out Vector2 pressPosition))
        {
            return;
        }

        dragPointerId = eventData.pointerId;
        grabOffset = (Vector2)itemRect.localPosition - pressPosition;
        eventData.eligibleForClick = false;
        itemRect.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId == dragPointerId && !itemClickHistory.InputLocked &&
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                itemParent, eventData.position, eventData.pressEventCamera, out Vector2 pointerPosition))
        {
            MoveInsideView(pointerPosition + grabOffset);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerId == dragPointerId)
        {
            dragPointerId = null;
        }
    }

    public void OnScroll(PointerEventData eventData)
    {
        if (itemClickHistory == null || itemClickHistory.InputLocked || itemParent == null || eventData.scrollDelta.y == 0f)
        {
            return;
        }

        itemRect.Rotate(0f, 0f, Mathf.Sign(eventData.scrollDelta.y) * ScrollRotationDegrees);
        MoveInsideView(itemRect.localPosition);
    }

    private void OnDisable()
    {
        dragPointerId = null;
    }

    private void OnRectTransformDimensionsChange()
    {
        if (itemParent != null)
        {
            MoveInsideView(itemRect.localPosition);
        }
    }

    private void MoveInsideView(Vector2 position)
    {
        Rect view = itemParent.rect;
        Vector2 space = FitInside(view);
        Vector2 offset = position - view.center;
        itemRect.localPosition = view.center + new Vector2(
            Mathf.Clamp(offset.x, -space.x, space.x), Mathf.Clamp(offset.y, -space.y, space.y));
    }

    // 回転した四隅が収まるようにし、中心を動かせる範囲を返す。
    private Vector2 FitInside(Rect area)
    {
        Vector2 halfSize = itemRect.rect.size * 0.5f;
        Vector3 right = itemRect.localRotation * new Vector3(halfSize.x * baseScale.x, 0f, 0f);
        Vector3 up = itemRect.localRotation * new Vector3(0f, halfSize.y * baseScale.y, 0f);
        var halfExtents = new Vector2(Mathf.Abs(right.x) + Mathf.Abs(up.x), Mathf.Abs(right.y) + Mathf.Abs(up.y));
        Vector2 areaHalfSize = area.size * 0.5f;
        float fit = Mathf.Min(1f, Mathf.Min(areaHalfSize.x / halfExtents.x, areaHalfSize.y / halfExtents.y));
        itemRect.localScale = baseScale * fit;
        return Vector2.Max(Vector2.zero, areaHalfSize - halfExtents * fit);
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
            UpdateBorder();
        }
    }

    /// <summary>
    /// ふちを更新する
    /// </summary>
    private void UpdateBorder()
    {
        if (selectionBorder == null)
        {
            return;
        }

        if (isSelected && image != null && selectionBorder.TryGetComponent(out Image borderImage))
        {
            borderImage.sprite = image.overrideSprite;
        }

        if (selectionBorder.activeSelf != isSelected)
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
