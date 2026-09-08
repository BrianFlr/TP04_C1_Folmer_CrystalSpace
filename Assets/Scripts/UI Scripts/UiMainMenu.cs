using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject creditsCanvas;

    [Header("Buttons")]
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnStart.onClick.AddListener(OnStartClicked);
        btnSettings.onClick.AddListener(OnSettingsClicked);
        btnCredits.onClick.AddListener(OnCreditsClicked);
        btnExit.onClick.AddListener(OnExitClicked);
    }

    private void OnDestroy()
    {
        btnStart.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
    }

    // Eventos de botones
    private void OnStartClicked()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void OnSettingsClicked()
    {
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    private void OnCreditsClicked()
    {
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    private void OnExitClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;  
    }
}
