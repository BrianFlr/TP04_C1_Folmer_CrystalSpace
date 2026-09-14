using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiSettingsToggleColor : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    private Slider sliderPlayerColor;

    [Header("Text Speed")]
    [SerializeField] private TMP_Text textPlayerColor;

    private void Awake()
    {
        sliderPlayerColor = GetComponent<Slider>();
        sliderPlayerColor.onValueChanged.AddListener(OnPlayerColorChanged);
    }

    private void Start()
    {
        sliderPlayerColor.value = data.moveSpeed;
    }

    private void OnDestroy()
    {
        sliderPlayerColor.onValueChanged.RemoveAllListeners();
    }

    // Evento de slider
    private void OnPlayerColorChanged(float value)
    {
        // Le asigno el valor del slider al valor de inicializacion del sriptable object
        data.moveSpeed = value;

        // Declaro una variable para definir el nombre con el que se va a guardar ese valor en configuracion
        string key = "Color" + data.playerName;

        // Guardo ese valor del slider y en la clave 
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();

        // Muestro el valor en el texto al lado del slider
        textPlayerColor.text = value.ToString("F0");
    }
}
