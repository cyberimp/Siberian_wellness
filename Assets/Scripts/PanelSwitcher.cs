using UnityEngine;

public class PanelSwitcher
{
    private readonly GameObject _panelA;
    private readonly GameObject _panelB;

    public PanelSwitcher(GameObject a, GameObject b)
    {
        _panelA = a;
        _panelB = b;
        b.SetActive(false);
    }

    public void Switch()
    {
        _panelA.SetActive(!_panelA.activeSelf);
        _panelB.SetActive(!_panelB.activeSelf);
    }
}
