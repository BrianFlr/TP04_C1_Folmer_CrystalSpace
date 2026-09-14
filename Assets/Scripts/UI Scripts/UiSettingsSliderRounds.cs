using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiSettingsSliderRounds : MonoBehaviour
{
    [SerializeField] private GameplayDataSo data;

    private Slider sliderRounds;

    [Header("Text Rounds")]
    [SerializeField] private TMP_Text textRounds;

    private void Awake()
    {
        sliderRounds = GetComponent<Slider>();
        sliderRounds.onValueChanged.AddListener(OnRoundsChanged);
    }

    private void Start()
    {
        sliderRounds.value = data.maxRounds;
    }

    private void OnDestroy()
    {
        sliderRounds.onValueChanged.RemoveAllListeners();
    }

    // Evento de slider
    private void OnRoundsChanged(float value)
    {
        // Le asigno el valor del slider al valor de inicializacion del sriptable object
        data.maxRounds = (int)value;

        // Declaro una variable para definir el nombre con el que se va a guardar ese valor en configuracion
        string key = "Rounds";

        // Guardo ese valor del slider en la clave 
        PlayerPrefs.SetInt(key, (int)value);

        // Muestro el valor en el texto al lado del slider
        textRounds.text = value.ToString("F0");
    }
}
