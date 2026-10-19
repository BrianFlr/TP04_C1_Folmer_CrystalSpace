using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiSettingsSliderMaxTime : MonoBehaviour
{
    [SerializeField] private GameplayDataSo data;

    private Slider sliderMaxTime;

    [Header("Text MaxTime")]
    [SerializeField] private TMP_Text textMaxTime;

    private void Awake()
    {
        sliderMaxTime = GetComponent<Slider>();
        sliderMaxTime.onValueChanged.AddListener(OnRoundsChanged);
    }

    private void Start()
    {
        sliderMaxTime.value = data.maxTimeGoal;
    }

    private void OnDestroy()
    {
        sliderMaxTime.onValueChanged.RemoveAllListeners();
    }

    // Evento de slider
    // Suggestion: el método se llama OnRoundsChanged pero este slider configura el tiempo máximo, no las rondas. Quedó del copiar y pegar desde UiSettingsSliderRounds.
    // Renombralo a OnMaxTimeChanged.
    private void OnRoundsChanged(float value)
    {
        // Le asigno el valor del slider al valor de inicializacion del sriptable object
        data.maxTimeGoal = (int)value;

        // Declaro una variable para definir el nombre con el que se va a guardar ese valor en configuracion
        string key = "MaxTime";

        // Guardo ese valor del slider en la clave 
        PlayerPrefs.SetInt(key, (int)value);
        PlayerPrefs.Save();

        // Muestro el valor en el texto al lado del slider
        textMaxTime.text = value.ToString("F1");
    }
}
