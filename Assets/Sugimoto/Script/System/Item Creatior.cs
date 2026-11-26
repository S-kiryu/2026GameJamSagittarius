using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテム生成をするクラス
/// </summary>
public class ItemCreatior : MonoBehaviour
{
    [Header("アイテム生成設定")]
    /// <summary>
    /// アイテムのプレハブ
    /// </summary>
    [SerializeField] private PicItem _itemPrefab;
    /// <summary>
    /// 画面全体を覆うアイテムの親。
    /// </summary>
    [SerializeField] private RectTransform _itemParent;
    [Tooltip("スポーン範囲。カメラの画面と辺が平行になるように配置します。")]
    [SerializeField] private BoxCollider2D _spawnArea;
    [SerializeField] private Camera _spawnCamera;
    [SerializeField, Range(0f, 180f)] private float _maxSpawnAngle = 35f;
    [SerializeField] private ItemClickHistory _itemClickHistory;

    /// <summary>
    /// アイテム生成
    /// </summary>
    public void GenerateItems(IReadOnlyList<Sprite> itemImages)
    {
        Canvas.ForceUpdateCanvases();
        if (!TryGetSpawnArea(out Rect spawnArea))
        {
            return;
        }

        foreach (Sprite sprite in itemImages)
        {
            if (sprite == null)
            {
                continue;
            }

            var item = Instantiate(_itemPrefab, _itemParent);
            var itemData = new ItemData(sprite.name, sprite);
            item.SetItemData(itemData, _itemClickHistory);
            item.SetSpawnPose(spawnArea, Random.Range(-_maxSpawnAngle, _maxSpawnAngle));
        }
    }

    private bool TryGetSpawnArea(out Rect area)
    {
        area = default;
        if (_spawnArea == null || _spawnCamera == null)
        {
            Debug.LogError("Spawn Area と Spawn Camera を設定してください。", this);
            return false;
        }

        Vector2 halfSize = _spawnArea.size * 0.5f;
        Vector2 first = _spawnArea.offset - halfSize;
        Vector2 last = _spawnArea.offset + halfSize;
        if (!TryProject(first, out Vector2 lower) ||
            !TryProject(new Vector2(last.x, first.y), out Vector2 right) ||
            !TryProject(new Vector2(first.x, last.y), out Vector2 up) ||
            !TryProject(last, out Vector2 upper))
        {
            Debug.LogError("Spawn Area をカメラの前に置いてください。", this);
            return false;
        }

        Vector2 edgeX = right - lower;
        Vector2 edgeY = up - lower;
        const float tolerance = 0.01f;
        bool aligned = (Mathf.Abs(edgeX.y) < tolerance && Mathf.Abs(edgeY.x) < tolerance) ||
                       (Mathf.Abs(edgeX.x) < tolerance && Mathf.Abs(edgeY.y) < tolerance);
        if (!aligned || (upper - (lower + edgeX + edgeY)).sqrMagnitude >= tolerance * tolerance)
        {
            Debug.LogError("Spawn Area の辺を画面の辺と平行にしてください。", this);
            return false;
        }

        Rect viewport = _itemParent.rect;
        Vector2 min = Vector2.Max(Vector2.Min(lower, upper), viewport.min);
        Vector2 max = Vector2.Min(Vector2.Max(lower, upper), viewport.max);
        area = Rect.MinMaxRect(min.x, min.y, max.x, max.y);
        if (area.width <= 0f || area.height <= 0f)
        {
            Debug.LogError("Spawn Area をカメラに映る位置に置いてください。", this);
            return false;
        }

        return true;
    }

    private bool TryProject(Vector2 point, out Vector2 localPoint)
    {
        Vector3 world = _spawnArea.transform.TransformPoint(point);
        Vector3 screen = _spawnCamera.WorldToScreenPoint(world);
        localPoint = default;
        return screen.z >= _spawnCamera.nearClipPlane && screen.z <= _spawnCamera.farClipPlane &&
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_itemParent, screen, null, out localPoint);
    }
}
