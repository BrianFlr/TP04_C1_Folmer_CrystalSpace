using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameplayDataSo data;
    private int roundsToWin = 3;
    private int maxRounds = 5;
    private float maxTimeGoal = 20f;
    private float timerGoal = 0f;

    private int player1Points = 0;
    private int player2Points = 0;

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
        timerGoal = (float)data.maxTimeGoal;
    }

    private void Update()
    {
        // Contador de segundos hacia atras para anotar 
        timerGoal -= Time.deltaTime;

        if (player1Points == roundsToWin || player2Points == roundsToWin)
        {

        } 
    }

    // Setters para sumarle puntaje a cada jugador
    public void SetPlayer1WinPoints()
    {
        // Aseguro que sume solo un punto
        Goal = true;
        
        if (Goal)
        {
            player1Points++;
        }
    }

    public void SetPlayer2WinPoints()
    {
        Goal = true;

        if (Goal)
        {
            player2Points++;
        }
    }

    // Get para saber el tiempo hacia atras transcurrido
    public float GetTimerGoalValue()
    {
        return timerGoal;
    }

    // Reset del contador de tiempo
    public void ResetTimerGoal()
    {
        timerGoal = maxTimeGoal;
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

    // Reset del valor de la variable que me indica cuando se suma un punto
    public void ResetGoalState()
    {
        Goal = false;
    }

    // Get de los puntos de cada jugador
    public int GetPlayer1Points()
    {
        return player1Points;
    }

    public int GetPlayer2Points()
    {
        return player2Points;
    }
}
