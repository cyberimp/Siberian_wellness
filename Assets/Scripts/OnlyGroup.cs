using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlyGroup : MonoBehaviour
{
    [SerializeField] private ColorSetter buttonPrefab = default;
    private readonly List<ColorSetter> _buttons = new List<ColorSetter>();

    private void OnEnable()
    {
        if (_buttons.Count == 0)
            return;
        var settings = UserSettings.GetInstance();
        DeselectAll();
        _buttons[settings.GetSelector()].Select();
    }

    public void AddButton(Color color)
    {
        var button = Instantiate(buttonPrefab.gameObject, transform);
        var setter = button.GetComponent<ColorSetter>();
        setter.SetNum(_buttons.Count);
        button.GetComponent<Button>().onClick.AddListener(setter.HandleClick);
        setter.SetColor(color);
        setter.Deselect();
        _buttons.Add(setter);
    }

    public void DeselectAll()
    {
        foreach (var button in _buttons)
        {
            button.Deselect();
        }
    }
}
