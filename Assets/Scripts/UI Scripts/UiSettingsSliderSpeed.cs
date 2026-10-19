using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Suggestion: este script, UiSettingsSliderLenght, UiSettingsSliderRounds y UiSettingsSliderMaxTime son cuatro clases de 45 líneas casi idénticas: cambia el campo del SO que escriben y el nombre de la clave.
// Una sola clase con un enum serializado (o con un Action<float> asignado desde el inspector) te deja un archivo en vez de cuatro.
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
        // Bug: estas claves de PlayerPrefs se escriben pero no se leen en ningún lado del proyecto (no hay un solo PlayerPrefs.Get en los veinte scripts). Lo mismo pasa en UiSettingsSliderLenght.cs:40, UiSettingsSliderRounds.cs:40 y UiSettingsSliderMaxTime.cs:40.
        // La configuración hoy sobrevive solo porque el slider escribe el ScriptableObject, y eso persiste en el editor pero NO en el build: al cerrar el juego se pierde todo.
        // Leé estas mismas claves en el Awake de cada slider y volcalas al SO.
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();

        // Muestro el valor en el texto al lado del slider
        textPlayerSpeed.text = value.ToString("F1");
    }
}
