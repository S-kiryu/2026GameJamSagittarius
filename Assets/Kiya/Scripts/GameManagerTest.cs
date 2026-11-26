using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{
    public static GameManagerTest Instance;

    [SerializeField] Themes_SO _themeData;
    [SerializeField] Items_SO _itemData;

    [SerializeField] ThemeName _themeName;

    public Theme CurrentTheme { get; private set; }
    [SerializeField] List<ItemName> _selectedItems;
    public List<Item> SelectedItems { get; private set; } = new List<Item>();

    [SerializeField] bool _result = true;
    public bool Result => _result;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SetCurrentTheme();
        SetItems();
    }

    private void OnValidate()
    {
        SetCurrentTheme();
        SetItems();
    }

    void SetCurrentTheme()
    {
        CurrentTheme = _themeData.Themes.Find(theme => theme.Name == _themeName);
        Debug.Log($"current theme is {CurrentTheme.Name}");
    }

    void SetItems()
    {
        SelectedItems.Clear();
        foreach (var item in _selectedItems)
        {
            SelectedItems.Add(_itemData.Items.Find(sprite => sprite.Name == item));

            //var selectedItem = _itemData.Items.Find(sprite => sprite.Name == item);

            //if (!SelectedItems.Contains(selectedItem))
            //    SelectedItems.Add(selectedItem);
        }
    }
}
