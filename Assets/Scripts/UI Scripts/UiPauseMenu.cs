using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiPauseMenu : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject creditsCanvas;

    [Header("Buttons")]
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;

    private void Awake()
    {
        btnContinue.onClick.AddListener(OnContinueClicked);
        btnSettings.onClick.AddListener(OnSettingsClicked);
        btnCredits.onClick.AddListener(OnCreditsClicked);
    }

    private void OnDestroy()
    {
        btnContinue.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
    }

    // Eventos de botones
    private void OnContinueClicked()
    {
        // Quito el estado de pausa
        PauseManager.Instance.ResetPauseState();

        // Desactivo el panel de pausa
        pauseCanvas.SetActive(false);

    }

    private void OnSettingsClicked()
    {
        // Desactivo el panel de Pausa y activo el de Configuración
        pauseCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    private void OnCreditsClicked()
    {
        // Desactivo el panel de Pausa y activo el de Créditos
        pauseCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }
}
