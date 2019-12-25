using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    private Text _text;
    private GameObject _target;
    private int _number;
    public PanelSwitcher Switcher { set; private get; }

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
        _text.text = _target.name;
    }

    public void HandleClick()
    {
        if (Camera.main != null)
        {
            Camera.main.transform.position = _target.transform.position + Vector3.back * 2;
        }

        var settings = UserSettings.GetInstance();
        settings.SetCurrent(_number);
        Switcher.Switch();
    }

    public void SetNumber(int i)
    {
        _number = i;
    }
}
