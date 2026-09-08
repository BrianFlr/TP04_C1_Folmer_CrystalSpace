using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiPauseMenu : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject creditsCanvas;
    [SerializeField] private GameObject mainMenuCanvas;

    [Header("Buttons")]
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnContinue.onClick.AddListener(OnContinueClicked);
        btnSettings.onClick.AddListener(OnSettingsClicked);
        btnCredits.onClick.AddListener(OnCreditsClicked);
        btnExit.onClick.AddListener(OnExitClicked);
    }

    private void Start()
    {
        // Consulto si se encuentra activo el script de la escena que se pausa para evitar el error "null reference"
        if (UiPauseManager.instance != null)
        {
            if (UiPauseManager.instance.isPause) // Si el juego se encuentra en pausa
            {
                // Desactivo el panel de Main Menu y activo el de Pausa
                mainMenuCanvas.SetActive(false);
                pauseCanvas.SetActive(true);
            }
        }
    }

    private void OnDestroy()
    {
        btnContinue.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
    }

    // Eventos de botones
    private void OnContinueClicked()
    {
        // Vuelvo el estado de pausa a false
        UiPauseManager.instance.isPause = false;

        // Reanudo el tiempo del juego
        Time.timeScale = 1;

        // Apago la escena de "MainMenu" para volver a la del juego
        SceneManager.UnloadSceneAsync("MainMenu");
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

    private void OnExitClicked()
    {
        // Reanudo el tiempo del juego
        Time.timeScale = 1;

        // Cargo la escena "MainMenu" de forma individual, cerrando las demás activas
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
