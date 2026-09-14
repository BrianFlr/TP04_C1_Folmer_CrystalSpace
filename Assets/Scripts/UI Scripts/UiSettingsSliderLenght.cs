using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiSettingsSliderLenght : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    private Slider sliderPlayerLenght;

    [Header("Text Lenght")]
    [SerializeField] private TMP_Text textPlayerLenght;

    private void Awake()
    {
        sliderPlayerLenght = GetComponent<Slider>();
        sliderPlayerLenght.onValueChanged.AddListener(OnPlayerLenghtChanged);
    }

    private void Start()
    {
        sliderPlayerLenght.value = data.lenght;
    }

    private void OnDestroy()
    {
        sliderPlayerLenght.onValueChanged.RemoveAllListeners();
    }

    // Evento de slider
    private void OnPlayerLenghtChanged(float value)
    {
        // Le asigno el valor del slider al valor de inicializacion del sriptable object
        data.lenght = value;

        // Declaro una variable para definir el nombre con el que se va a guardar ese valor en configuracion
        string key = "Lenght" + data.playerName;

        // Guardo ese valor del slider en la clave 
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();

        // Muestro el valor en el texto al lado del slider
        textPlayerLenght.text = value.ToString("F0");
    }
}
