using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiSettingsMenu : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject pauseCanvas;

    [Header("Buttons")]
    [SerializeField] private Button btnBack;

    private void Awake()
    {
        btnBack.onClick.AddListener(OnBackClicked);
    }

    private void Update()
    {
        if (settingsCanvas.activeSelf)
        {
            PauseManager.Instance.isSettings = true;
        }
        else
        {
            PauseManager.Instance.isSettings = false;
        }
    }

    private void OnDestroy()
    {
        btnBack.onClick.RemoveAllListeners();
    }

    // Eventos de botones
    private void OnBackClicked()
    {
        settingsCanvas.SetActive(false);

        // Consulto si se encuentra en pausa.
        if (PauseManager.Instance.GetPauseState() == true)
        {
            // Activo el panel de Pausa.
            pauseCanvas.SetActive(true);
        }
        else
        {
            // Activo el panel de MainMenu.
            mainMenuCanvas.SetActive(true);
        }
    }
}
