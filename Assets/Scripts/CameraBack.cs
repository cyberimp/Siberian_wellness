using UnityEngine;

public class CameraBack : MonoBehaviour
{
    public PanelSwitcher Switcher { set; private get; }
    
    public void HandleClick()
    {
        if (Camera.main != null)
            Camera.main.transform.position = Vector3.zero + Vector3.back * 5;
        Switcher.Switch();
    }
}
