using UnityEngine;

public class ColorList : MonoBehaviour
{
    [SerializeField] private OnlyGroup panel = default;


    [Header("Цвета менять тут:")]
    [SerializeField]
    private Color[] list;
    
    // Start is called before the first frame update
    private void Start()
    {
        var settings = UserSettings.GetInstance();
        foreach (var color in list)
        {
            panel.AddButton(color);
            settings.AddColor(color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
