using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameplayDataSo data;
    private int roundsToWin = 3;
    private int maxRounds = 5;
    private float maxTimeGoal = 20f;
    private float timerGoal = 0f;

    private int player1WinPoints = 0;
    private int player2WinPoints = 0;

    private bool Goal = false;

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
        maxTimeGoal = (float)data.maxTimeGoal;
    }

    private void Update()
    {
        // Contador de segundos para comparar con el maximo definido
        timerGoal += Time.deltaTime;
    }

    // Setters para sumarle puntaje a cada jugador
    public void SetPlayer1WinPoints()
    {
        // Aseguro que sume solo un punto
        Goal = true;
        
        if (Goal)
        {
            player1WinPoints++;
        }
    }

    public void SetPlayer2WinPoints()
    {
        Goal = true;

        if (Goal)
        {
            player2WinPoints++;
        }
    }

    // Get para saber el tiempo transcurrido
    public float GetTimerGoalValue()
    {
        return timerGoal;
    }

    // Reset del contador de tiempo
    public void ResetTimerGoal()
    {
        timerGoal = 0;
    }

    // Get para saber el tiempo maximo para anotar un punto
    public float GetMaxTimeGoal()
    {
        return maxTimeGoal;
    }

    // Get para saber cuando se anota un punto
    public bool GetGoalState()
    {
        return Goal;
    }

    public void ResetGoalState()
    {
        Goal = false;
    }
}
