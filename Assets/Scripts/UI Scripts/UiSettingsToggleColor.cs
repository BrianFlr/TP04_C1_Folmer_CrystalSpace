using UnityEngine;
using UnityEngine.UI;

public class UiSettingsToggleColor : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    [SerializeField] private Toggle redToggle;
    [SerializeField] private Toggle greenToggle;
    [SerializeField] private Toggle blueToggle;

    private void Awake()
    {
        redToggle.onValueChanged.AddListener(OnColorRedChecked);
        greenToggle.onValueChanged.AddListener(OnColorGreenChecked);
        blueToggle.onValueChanged.AddListener(OnColorBlueChecked);
    }

    private void Start()
    {
        // Dependiendo del color guardado en el sriptable object dejo marcado el toggle correspondiente
        // Warning: los tres Toggle no están en un ToggleGroup, así que se pueden marcar dos a la vez y el color final queda determinado por el orden en que se dispararon los eventos.
        // Poné los tres en un ToggleGroup, o resolvelo con un solo Dropdown.
        if (data.color == Color.red)
        {
            redToggle.isOn = true;
        }
        else if (data.color == Color.green)
        {
            greenToggle.isOn = true;
        }
        else if (data.color == Color.blue)
        {
            blueToggle.isOn = true;
        }
        else
        {
            redToggle.isOn = false;
            greenToggle.isOn = false;
            blueToggle.isOn = false;
        }
    }

    private void OnDestroy()
    {
        redToggle.onValueChanged.RemoveAllListeners();
        greenToggle.onValueChanged.RemoveAllListeners();
        blueToggle.onValueChanged.RemoveAllListeners();
    }

    // Funciones para cambiar el color en el scriptable object
    private void OnColorRedChecked(bool isActive)
    {
        if (isActive)
        {
            data.color = Color.red;
        }
        else
        {
            data.color = Color.white;
        }
    }

    private void OnColorGreenChecked(bool isActive)
    {
        if (isActive)
        {
            data.color = Color.green;
        }
        else
        {
            data.color = Color.white;
        }
    }
    
    private void OnColorBlueChecked(bool isActive)
    {
        if (isActive)
        {
            data.color = Color.blue;
        }
        else
        {
            data.color = Color.white;
        }
    }
}
