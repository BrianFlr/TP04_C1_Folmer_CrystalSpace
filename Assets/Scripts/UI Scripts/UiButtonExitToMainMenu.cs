using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiButtonExit : MonoBehaviour
{
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnExit.onClick.AddListener(OnExitClicked);
    }

    private void OnDestroy()
    { 
        btnExit.onClick.RemoveAllListeners();
    }

    private void OnExitClicked()
    {
        // Quito el estado de pausa
        PauseManager.Instance.ResetPauseState();

        // Cargo la escena "MainMenu"
        SceneManager.LoadScene("MainMenu");
    }
}
