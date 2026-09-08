using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiSettingsSlidersLenght : MonoBehaviour
{
    [Header("Sliders Lenght")]
    [SerializeField] private Slider sliderPlayer1Lenght;
    [SerializeField] private Slider sliderPlayer2Lenght;
    [SerializeField] private TMP_Text textPlayer1Lenght;
    [SerializeField] private TMP_Text textPlayer2Lenght;

    private void Awake()
    {
        sliderPlayer1Lenght.onValueChanged.AddListener(OnPlayer1LenghtChanged);
        sliderPlayer2Lenght.onValueChanged.AddListener(OnPlayer2LenghtChanged);
    }

    private void OnDestroy()
    {
        sliderPlayer1Lenght.onValueChanged.RemoveAllListeners();
        sliderPlayer2Lenght.onValueChanged.RemoveAllListeners();
    }

    // Eventos de sliders
    private void OnPlayer1LenghtChanged(float value)
    {
        // Obtengo el valor del slider y lo guardo una plantilla para identificarla con esa clave
        PlayerPrefs.SetFloat("Player1Lenght", value);
        PlayerPrefs.Save();

        textPlayer1Lenght.text = value.ToString("F2");
    }

    private void OnPlayer2LenghtChanged(float value)
    {
        // Obtengo el valor del slider y lo guardo una plantilla para identificarla con esa clave
        PlayerPrefs.SetFloat("Player2Lenght", value);
        PlayerPrefs.Save();

        textPlayer2Lenght.text = value.ToString("F2");
    }
}
