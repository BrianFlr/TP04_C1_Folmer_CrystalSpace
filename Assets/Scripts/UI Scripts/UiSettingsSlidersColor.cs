using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiSettingsSlidersColor : MonoBehaviour
{
    [Header("Sliders Color")]
    [SerializeField] private Slider sliderPlayer1Color;
    [SerializeField] private Slider sliderPlayer2Color;
    [SerializeField] private TMP_Text textPlayer1Color;
    [SerializeField] private TMP_Text textPlayer2Color;

    private void Awake()
    {
        sliderPlayer1Color.onValueChanged.AddListener(OnPlayer1ColorChanged);
        sliderPlayer2Color.onValueChanged.AddListener(OnPlayer2ColorChanged);
    }

    private void OnDestroy()
    {
        sliderPlayer1Color.onValueChanged.RemoveAllListeners();
        sliderPlayer2Color.onValueChanged.RemoveAllListeners();
    }

    // Eventos de sliders
    private void OnPlayer1ColorChanged(float value)
    {
        // Obtengo el valor del slider y lo guardo una plantilla para identificarla con esa clave
        PlayerPrefs.SetFloat("Player1Color", value);
        PlayerPrefs.Save();

        textPlayer1Color.text = value.ToString("F2");
    }
    private void OnPlayer2ColorChanged(float value)
    {
        // Obtengo el valor del slider y lo guardo una plantilla para identificarla con esa clave
        PlayerPrefs.SetFloat("Player2Color", value);
        PlayerPrefs.Save();

        textPlayer2Color.text = value.ToString("F2");
    }
}
