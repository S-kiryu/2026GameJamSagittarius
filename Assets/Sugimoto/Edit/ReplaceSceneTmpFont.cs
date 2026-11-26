#if UNITY_EDITOR
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

internal static class ReplaceSceneTmpFont
{
    private const string DefaultFontGuid = "3dd9b2c1a66e3034fb3885441d504774";

    [MenuItem("Tools/TMP/開いているシーンのフォントを一括変更")]
    private static void ReplaceFont()
    {
        TMP_FontAsset fontAsset = Selection.activeObject as TMP_FontAsset;
        if (fontAsset == null)
        {
            string defaultFontPath = AssetDatabase.GUIDToAssetPath(DefaultFontGuid);
            if (!string.IsNullOrEmpty(defaultFontPath))
            {
                fontAsset = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(defaultFontPath);
            }
        }

        if (fontAsset == null)
        {
            EditorUtility.DisplayDialog(
                "TMPフォント一括変更",
                "既定の ipagp SDF が見つかりません。\nProject ウィンドウで TMP フォントアセットを選択して、もう一度実行してください。",
                "OK");
            return;
        }

        TMP_Text[] texts = Resources.FindObjectsOfTypeAll<TMP_Text>();
        var changedScenes = new HashSet<Scene>();
        int changedCount = 0;

        int undoGroup = Undo.GetCurrentGroup();
        Undo.SetCurrentGroupName($"TMPフォントを {fontAsset.name} に一括変更");

        foreach (TMP_Text text in texts)
        {
            Scene scene = text.gameObject.scene;
            if (!scene.IsValid() || !scene.isLoaded || EditorUtility.IsPersistent(text))
            {
                continue;
            }

            if (text.font == fontAsset)
            {
                continue;
            }

            Undo.RecordObject(text, "TMPフォントを変更");
            text.font = fontAsset;
            EditorUtility.SetDirty(text);
            changedScenes.Add(scene);
            changedCount++;
        }

        foreach (Scene changedScene in changedScenes)
        {
            EditorSceneManager.MarkSceneDirty(changedScene);
        }

        Undo.CollapseUndoOperations(undoGroup);

        EditorUtility.DisplayDialog(
            "TMPフォント一括変更",
            $"{changedCount}個のテキストのフォントを {fontAsset.name} に変更しました。",
            "OK");
    }
}
#endif
