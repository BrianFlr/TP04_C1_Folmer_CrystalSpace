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

    private void Update()
    {
        if (creditsCanvas.activeSelf)
        {
            PauseManager.Instance.isCredits = true;
        }
        else
        {
            PauseManager.Instance.isCredits = false;
        }
    }

    private void OnDestroy()
    {
        btnBack.onClick.RemoveAllListeners();
    }

    // Eventos de botones.
    private void OnBackClicked()
    {
        creditsCanvas.SetActive(false);

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
