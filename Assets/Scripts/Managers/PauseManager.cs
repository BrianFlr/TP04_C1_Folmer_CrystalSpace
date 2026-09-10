using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    public bool isMainMenu = false;
    public bool isSettings = false;
    public bool isCredits = false;

    // Defino mi variable de pausa de acceso global
    private bool isPause = false;

    private void Awake()
    {
        // Para permanecer con sólo una instancia de PauseManager activa a la vez
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

    private void Update()
    {
        if (!isMainMenu && !isSettings && !isCredits)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) // Leo el input de la tecla para pausa
            {
                isPause = !isPause;

                if (isPause)
                {
                    // Seteo el tiempo en 0.
                    Time.timeScale = 0;

                    // Cargo la escena de "MainMenu", pero colocándola encima de la actual "Gameplay"
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                }
                else
                {
                    // Seteo el tiempo en 1 para reanudar el juego
                    Time.timeScale = 1;

                    // Apago la escena de "MainMenu" para volver a la del juego
                    SceneManager.UnloadSceneAsync("MainMenu");
                }
            }
        } 
    }

    // Función que setea la pausa o la quita
    public void SetPauseState(bool State)
    {
        isPause = State;
    }

    // Función para leer el estado de pausa
    public bool GetPauseState()
    {
        return isPause;
    }
}
