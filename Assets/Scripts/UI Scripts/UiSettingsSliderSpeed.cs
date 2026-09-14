using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiSettingsSliderSpeed : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    private Slider sliderPlayerSpeed;

    [Header("Text Speed")]
    [SerializeField] private TMP_Text textPlayerSpeed;

    private void Awake()
    {
        sliderPlayerSpeed = GetComponent<Slider>();
        sliderPlayerSpeed.onValueChanged.AddListener(OnPlayerSpeedChanged);
    }

    private void Start()
    {
        sliderPlayerSpeed.value = data.moveSpeed;
    }

    private void OnDestroy()
    {
        sliderPlayerSpeed.onValueChanged.RemoveAllListeners();
    }

    // Evento de slider
    private void OnPlayerSpeedChanged(float value)
    {
        // Le asigno el valor del slider al valor de inicializacion del sriptable object
        data.moveSpeed = value;

        // Declaro una variable para definir el nombre con el que se va a guardar ese valor en configuracion
        string key = "Speed" + data.playerName;

        // Guardo ese valor del slider en la clave
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();

        // Muestro el valor en el texto al lado del slider
        textPlayerSpeed.text = value.ToString("F2");
    }
}
