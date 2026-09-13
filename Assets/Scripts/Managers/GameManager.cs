using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameplayDataSo data;

    private int maxRounds = 0;
    private int roundsToWin = 0;
    private float maxTimeGoal = 0f;
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
    }

    private void Start()
    {
        maxRounds = data.maxRounds;
        roundsToWin = data.maxRounds / 2 + 1; // Calculo los rounds necesarios para ganar

        maxTimeGoal = data.maxTimeGoal;
        timerGoal = data.maxTimeGoal;
    }

    private void Update()
    {
        // Contador regresivo de segundos maximos para anotar 
        timerGoal -= Time.deltaTime;

        if (player1Points == roundsToWin && player2Points == roundsToWin)
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

    // Get para saber el tiempo maximo para anotar un punto
    public float GetMaxTimeGoal()
    {
        return maxTimeGoal;
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
