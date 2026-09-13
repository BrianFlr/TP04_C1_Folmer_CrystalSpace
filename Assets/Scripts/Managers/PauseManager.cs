using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject creditsCanvas;

    // Defino mi variable de pausa
    private bool isPause = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
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

    // Función que resetea el estado de pausa
    public void ResetPauseState()
    {
        isPause = false;

        // Reanudo el tiempo del juego
        Time.timeScale = 1;
    }
}
