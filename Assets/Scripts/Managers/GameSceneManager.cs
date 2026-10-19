using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    void Update()
    {
        // Si se hace un punto, recarga la escena de juego y resetea el estado de gol
        if (GameManager.Instance.GetGoalState())
        {
            // Recargo la escena de juego
            // Warning: "Gameplay" escrito a mano acá, y otra vez en UiMainMenu.cs:51, más "MainMenu" en UiPauseMenu.cs:99 y UiWinTieMenu.cs:91.
            // Declaralos como const string en una clase compartida: si renombrás una escena, el proyecto compila igual y falla recién en runtime.
            SceneManager.LoadScene("Gameplay");

            // Reseteo el estado de gol
            GameManager.Instance.ResetGoalState();

            // Nuevamente tomo las variables de inicio por si hubo algun cambio durante la partida
            GameManager.Instance.GetInitialVariables();
        }
    }
}
