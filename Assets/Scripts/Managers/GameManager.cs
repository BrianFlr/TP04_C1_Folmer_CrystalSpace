using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float playerSpeed = 0f;

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

    private float GetPlayerSpeed()
    {
        return playerSpeed;
    }

    public void GetPlayersSettings()
    {

    }
}
