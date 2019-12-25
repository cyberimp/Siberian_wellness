using UnityEngine;
using UnityEngine.UI;

public class ColorSetter : MonoBehaviour
{
    private GameObject _selectedText;
    private Image _color;
    private OnlyGroup _parent;
    private int _number;
    
    private void Awake()
    {
        _color = transform.Find("Color").GetComponent<Image>();
        _selectedText = _color.transform.Find("Selected").gameObject;
        _parent = transform.parent.GetComponent<OnlyGroup>();
    }

    public void Deselect()
    {
        _selectedText.SetActive(false);
    }

    public void SetColor(Color color)
    {
        _color.color = color;
    }

    public void HandleClick()
    {
        _parent.DeselectAll();
        Select();
        var settings = UserSettings.GetInstance();
        settings.SetSelector(_number);
    }

    public void Select()
    {
        _selectedText.SetActive(true);
    }

    public void SetNum(int num)
    {
        _number = num;
    }
}
