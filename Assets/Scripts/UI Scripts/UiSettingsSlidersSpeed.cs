using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiSettingsSlidersSpeed : MonoBehaviour
{
    [Header("Sliders Speed")]
    [SerializeField] private Slider sliderPlayer1Speed;
    [SerializeField] private Slider sliderPlayer2Speed;
    [SerializeField] private TMP_Text textPlayer1Speed;
    [SerializeField] private TMP_Text textPlayer2Speed;

    private void Awake()
    {
        sliderPlayer1Speed.onValueChanged.AddListener(OnPlayer1SpeedChanged);
        sliderPlayer2Speed.onValueChanged.AddListener(OnPlayer2SpeedChanged);
    }

    private void OnDestroy()
    {
        sliderPlayer1Speed.onValueChanged.RemoveAllListeners();
        sliderPlayer2Speed.onValueChanged.RemoveAllListeners();
    }

    // Eventos de sliders
    private void OnPlayer1SpeedChanged(float value)
    {
        // Obtengo el valor del slider y lo guardo en una plantilla para identificarla con esa clave
        PlayerPrefs.SetFloat("Player1Speed", value);
        PlayerPrefs.Save();

        // Muestro el valor de la velocidad en el texto al lado del slider
        textPlayer1Speed.text = value.ToString("F2");
    }

    private void OnPlayer2SpeedChanged(float value)
    {
        // Obtengo el valor del slider y lo guardo en una plantilla para identificarla con esa clave
        PlayerPrefs.SetFloat("Player2Speed", value);
        PlayerPrefs.Save();

        // Muestro el valor de la velocidad en el texto al lado del slider
        textPlayer2Speed.text = value.ToString("F2");
    }
}
