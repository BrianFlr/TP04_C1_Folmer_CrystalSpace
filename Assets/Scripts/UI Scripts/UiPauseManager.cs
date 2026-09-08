using UnityEngine;
using UnityEngine.SceneManagement;

public class UiPauseManager : MonoBehaviour
{
    // Hago que el script sea de acceso global
    public static UiPauseManager instance { get; private set; }

    // Defino mi variable de pausa de acceso global
    public bool isPause { get; set; } = false;

    private void Awake()
    {
        // Para permanecer con sólo una instancia de UiPauseManager activa a la vez
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) // Me deja cambiar a la escena para entrar en pausa al presionar una tecla
        {
            isPause = !isPause;

            if (isPause)
            {
                // Seteo el tiempo en 0
                Time.timeScale = 0;

                // Cargo la escena de "MainMenu", pero colocándola encima de la actual. En este caso "Gameplay"
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

    private void ChargePlayerPrefs()
    {

    }
}
