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
            SceneManager.LoadScene("Gameplay");

            // Reseteo el estado de gol
            GameManager.Instance.ResetGoalState();

            // Nuevamente tomo las variables de inicio por si hubo algun cambio durante la partida
            GameManager.Instance.GetInitialVariables();
        }
    }
}
