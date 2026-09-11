using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameplayDataSo data;
    private int roundsToWin = 3;
    private int maxRounds = 5;
    private float maxTimeGoal = 20f;
    private float timerGoal = 0f;
    public int Player1WinRounds = 0;
    public int Player2WinRounds = 0;

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

        roundsToWin = data.roundsToWin;
        maxRounds = data.maxRounds;
        float maxTimeGoal = data.maxTimeGoal + 1;
    }

    private void Update()
    {
        // Cuento la cantidad de segundos y lo comparo con el maximo definido
        if (timerGoal <= maxTimeGoal)
        {
            timerGoal += Time.deltaTime;
        }
        else
        {
            timerGoal = 0;
        }

        if (Player1WinRounds == data.roundsToWin || Player2WinRounds == data.roundsToWin)
        {

        }
    }

    // Setters para sumarle puntaje a cada jugador
    public void SetPlayer1WinRounds()
    {
        Player1WinRounds++;
    }

    public void SetPlayer2WinRounds()
    {
        Player2WinRounds++;
    }

    // Get para saber el tiempo transcurrido
    public float GetTimerGoalValue()
    {
        return timerGoal;
    }

    // Get para saber el tiempo maximo para anotar un punto
    public float GetMaxTimeGoal()
    {
        return maxTimeGoal;
    }
}
