using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameplayDataSo data;

    private int maxRounds = 0;
    private int roundsToWin = 0;
    private float maxTimeGoal = 0f;
    private float timerGoal = 0f;

    private int player1Points = 0;
    private int player2Points = 0;

    private bool goal = false;

    // Creo mi variable tipo enum para asignarle el estado de victoria o empate
    private WinTieCondition winTieCondition = WinTieCondition.None;

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

        // Condicion de victoria o empate
        if (player1Points == roundsToWin)
        {
            winTieCondition = WinTieCondition.Player1Win;
        }
        else if (player2Points == roundsToWin)
        {
            winTieCondition = WinTieCondition.Player2Win;
        }
        else if (maxRounds % 2 == 0) // Significa que el numero de rondas es par y por lo tanto puede haber empate
        {
            if(player1Points == player2Points && player1Points == maxRounds / 2)
            {
                winTieCondition = WinTieCondition.Tie;
            }
        }
    }

    // Setters para sumarle puntaje a cada jugador
    public void SetPlayer1WinPoints()
    {
        // Aseguro que sume solo un punto
        goal = true;

        if (goal)
        {
            player1Points++;
        }
    }

    public void SetPlayer2WinPoints()
    {
        goal = true;

        if (goal)
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
        return goal;
    }

    // Reset del valor de la variable que me indica cuando se suma un punto
    public void ResetGoalState()
    {
        goal = false;
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

    // Reset de los puntos de cada jugador
    public void ResetPlayersPoints()
    {
        player1Points = 0;
        player2Points = 0;
    }

    // Get para saber el valor del enum que tiene la variable del mismo tipo
    public WinTieCondition GetWinTieCondition()
    {
        return winTieCondition;
    }
    
    // Reset de la variable para poder reiniciar el juego
    public void ResetWinTieCondition()
    {
        winTieCondition = WinTieCondition.None;
    }
}
