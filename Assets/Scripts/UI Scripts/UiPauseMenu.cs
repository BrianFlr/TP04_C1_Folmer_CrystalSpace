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
    [SerializeField] private Button btnExit;

    // Defino mi variable de pausa
    private bool isPause = false;

    private void Awake()
    {
        btnContinue.onClick.AddListener(OnContinueClicked);
        btnSettings.onClick.AddListener(OnSettingsClicked);
        btnCredits.onClick.AddListener(OnCreditsClicked);
        btnExit.onClick.AddListener(OnExitClicked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) // Leo el input de la tecla para pausa
        {
            if (settingsCanvas.activeSelf || creditsCanvas.activeSelf) // Si esta activo otro menu 
            {
                // Primero lo cierra
                settingsCanvas.SetActive(false);
                creditsCanvas.SetActive(false);

                // Y vuelve al menu de pausa
                pauseCanvas.SetActive(true);
                
            }
            else
            {
                isPause = !isPause;

                if (isPause)
                {
                    // Seteo el tiempo en 0
                    Time.timeScale = 0;

                    // Activo el menu de pausa
                    pauseCanvas.SetActive(true);
                }
                else
                {
                    // Seteo el tiempo en 1 para reanudar el juego
                    Time.timeScale = 1;

                    // Desactivo el menu de pausa
                    pauseCanvas.SetActive(false);
                }
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
        // Quito el estado de pausa
        ResetPauseState();

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

    private void OnExitClicked()
    {
        // Quito el estado de pausa
        ResetPauseState();

        // Cargo la escena "MainMenu"
        SceneManager.LoadScene("MainMenu");
    }

    // Función que resetea el estado de pausa
    public void ResetPauseState()
    {
        isPause = false;

        // Reanudo el tiempo del juego
        Time.timeScale = 1;
    }
}
