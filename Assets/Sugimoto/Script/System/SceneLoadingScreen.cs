using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class SceneLoadingScreen : MonoBehaviour
{
    private const float ReadyToActivate = 0.9f;

    [SerializeField, Min(0f)] private float _minimumDisplaySeconds = 1f;
    [SerializeField] private Slider _progressBar;

    private static SceneLoadingScreen _active;

    public static bool TryLoad(string sceneName, SceneLoadingScreen prefab)
    {
        if (_active != null)
        {
            return false;
        }

        if (prefab == null || string.IsNullOrWhiteSpace(sceneName)
            || !Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogError($"シーン「{sceneName}」のロード画面を開始できません。");
            return false;
        }

        AsyncOperation load = SceneManager.LoadSceneAsync(sceneName);
        if (load == null)
        {
            return false;
        }

        load.allowSceneActivation = false;

        _active = Instantiate(prefab);
        DontDestroyOnLoad(_active.gameObject);
        _active.gameObject.SetActive(true);

        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        _active.StartCoroutine(_active.ShowProgress(load));
        return true;
    }

    private IEnumerator ShowProgress(AsyncOperation load)
    {
        yield return null;
        float visibleUntil = Time.unscaledTime + _minimumDisplaySeconds;

        while (load.progress < ReadyToActivate || Time.unscaledTime < visibleUntil)
        {
            if (_progressBar != null)
            {
                float progress = Mathf.Clamp01(load.progress / ReadyToActivate);
                _progressBar.SetValueWithoutNotify(progress);
            }

            yield return null;
        }

        if (_progressBar != null)
        {
            _progressBar.SetValueWithoutNotify(1f);
            yield return null;
        }

        load.allowSceneActivation = true;
        yield return load;

        Destroy(gameObject);
    }
}
