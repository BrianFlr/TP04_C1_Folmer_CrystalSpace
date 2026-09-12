using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    void Update()
    {
        // Si se hace un punto, recarga la escena de juego y resetea el estado de gol
        if (GameManager.Instance.GetGoalState())
        {
            //SceneManager.LoadScene("Gameplay");
            //GameManager.Instance.ResetGoalState();
        }
    }
}
