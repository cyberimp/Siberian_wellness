using UnityEngine;
using UnityEngine.UI;

public class MeshLayout : MonoBehaviour
{
    [SerializeField] private CanvasRenderer panelA = default;
    [SerializeField] private CanvasRenderer panelB = default;
    [SerializeField] private CameraSwitch buttonPrefab = default;
    [SerializeField] private CameraBack backButton = default;
    [SerializeField] private Material defaultMaterial = default;

    private GameObject[] _meshes;
    
    // Start is called before the first frame update
    void Start()
    {
        var settings = UserSettings.GetInstance();
        var switcher = new PanelSwitcher(panelA.gameObject, panelB.gameObject);
        backButton.Switcher = switcher;
        var childCount = transform.childCount;
        _meshes = new GameObject[childCount];
        var parent = panelA.transform;
        for (var i = 0; i < childCount; i++)
        {
            var mat = new Material(defaultMaterial);
            _meshes[i] = transform.GetChild(i).gameObject;
            
            
            if (childCount == 1)
                _meshes[i].transform.position = Vector3.zero;
            else
            {
                _meshes[i].transform.position = Vector3.left * childCount + Vector3.right * (8 * (i / (float) childCount));
            }
            
            _meshes[i].GetComponent<MeshRenderer>().material = mat;
            settings.AddMaterial(mat);
            var button = Instantiate(buttonPrefab.gameObject, parent);
            var buttonMozgi = button.GetComponent<CameraSwitch>();
            buttonMozgi.SetTarget(_meshes[i]);
            buttonMozgi.SetNumber(i);
            buttonMozgi.Switcher = switcher;
            var buttonComponent = button.GetComponent<Button>();
            buttonComponent.onClick.AddListener(buttonMozgi.HandleClick);
        }
        
        settings.ReadSettings();
        settings.Apply();
    }

    private void OnApplicationQuit()
    {
        var settings = UserSettings.GetInstance();
        settings.WriteSettings();
    }
}
