using UnityEngine;

/// <summary>
/// リザルト時に使うデータの保存先
/// </summary>
public sealed class StageResultStore : MonoBehaviour
{
    private static StageResultStore _instance;
    private StageResult _result;

    /// <summary>
    /// データを保存
    /// </summary>
    /// <param name="result">引き渡すデータ</param>
    internal static void Save(StageResult result)
    {
        if (_instance == null)
        {
            var storeObject = new GameObject(nameof(StageResultStore));
            _instance = storeObject.AddComponent<StageResultStore>();
            DontDestroyOnLoad(storeObject);
        }

        _instance._result = result;
    }

    /// <summary>
    /// リザルトデータの取得
    /// </summary>
    /// <param name="result"></param>
    /// <returns>リザルトデータ</returns>
    internal static bool TryTake(out StageResult result)
    {
        if (_instance == null)
        {
            result = null;
            return false;
        }

        StageResultStore store = _instance;
        result = store._result;
        store._result = null;
        _instance = null;
        Destroy(store.gameObject);
        return true;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void Reset()
    {
        _instance = null;
    }
}
