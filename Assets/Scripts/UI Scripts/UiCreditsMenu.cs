using UnityEngine;
using UnityEngine.UI;

public class UiCreditsMenu : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject creditsCanvas;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject pauseCanvas;

    [Header("Buttons")]
    [SerializeField] private Button btnBack;

    private void Awake()
    {
        btnBack.onClick.AddListener(OnBackClicked);
    }

    private void OnDestroy()
    {
        btnBack.onClick.RemoveAllListeners();
    }

    // Buttons Events
    private void OnBackClicked()
    {
        creditsCanvas.SetActive(false);

        // Consulto si se encuentra activo el script de la escena que se pausa
        if (UiPauseManager.instance != null)
        {
            if (UiPauseManager.instance.isPause) // Si el juego se encuentra en pausa
            {
                // Activo el panel de Pausa
                pauseCanvas.SetActive(true);
            }
        }
        else // Si no se encuentra activo, significa que no está en pausa
        {
            // Activo el panel de MainMenu
            mainMenuCanvas.SetActive(true);
        }
    }
}
