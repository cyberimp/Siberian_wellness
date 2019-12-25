using System.Collections.Generic;
using UnityEngine;

public class UserSettings
{
    private static UserSettings _instance;
    private readonly List<Material> _materials = new List<Material>();
    private readonly List<Color> _colors = new List<Color>();
    private readonly List<int> _selected = new List<int>();
    private int _current;

    public static UserSettings GetInstance()
    {
        return _instance ?? (_instance = new UserSettings());
    }
    
    public void AddColor(Color color)
    {
        _colors.Add(color);
    }

    public void AddMaterial(Material material)
    {
        _materials.Add(material);
    }

    public void SetCurrent(int num)
    {
        _current = num;
    }

    public int GetSelector()
    {
        return _selected[_current];
    }

    public Color SetSelector(int num)
    {
        _selected[_current] = num;
        var color = _colors[num];
        _materials[_current].color = color;
        return color;
    }

    public void ReadSettings()
    {
        var length = _materials.Count;
        for (var i = 0; i < length; i++)
        {
            var cur = PlayerPrefs.GetInt("key" + i, i % 2);
            if (cur > _colors.Count)
                cur = 0;
            _selected.Add(cur);
        }
    }

    public void Apply()
    {
        for (var i = 0; i < _materials.Count; i++)
            _materials[i].color = _colors[_selected[i]];
    }

    public void WriteSettings()
    {
        var length = _materials.Count;
        for (var i = 0; i < length; i++)
        {
            PlayerPrefs.SetInt("key" + i, _selected[i]);
        }
        
        PlayerPrefs.Save();
    }
}
