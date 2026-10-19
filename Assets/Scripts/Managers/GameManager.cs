using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    // Warning: Instance es un campo public static, así que cualquier script puede pisarlo con null o con otro GameManager y romper todas las llamadas de GameManager.Instance.
    // El patrón habitual es public static GameManager Instance { get; private set; }
    public static GameManager Instance;

    [SerializeField] private GameplayDataSo data;

    private int maxRounds = 0;
    private int roundsToWin = 0;
    private float maxTimeGoal = 0f;
    private float timerGoal = 0f;

    private int player1Points = 0;
    private int player2Points = 0;

    private bool goal = false;
    private bool isTimerOff = false;

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
        // Tomo los valores de inicio del juego
        GetInitialVariables();
    }

    private void Update()
    {
        if (!isTimerOff) // Si aun no se finalizo el juego, el contador sigue realizandose
        {
            // Contador regresivo de segundos maximos para anotar 
            timerGoal -= Time.deltaTime;
        }

        // Condicion de victoria o empate
        // Warning: la condición de victoria se evalúa en cada frame con ==, y como UiWinTieMenu.Update llama a ResetWinTieCondition() apenas la muestra, acá se vuelve a setear en el frame siguiente, una y otra vez, mientras el marcador siga igual.
        // Usá >= en lugar de == (si algún día se suman dos puntos juntos, con == no entra nunca) y resolvé el fin de partida una sola vez, desde donde se suma el punto, en vez de chequearlo en el Update.
        if (player1Points == roundsToWin)
        {
            winTieCondition = WinTieCondition.Player1Win;
            isTimerOff = true;
        }
        else if (player2Points == roundsToWin)
        {
            winTieCondition = WinTieCondition.Player2Win;
            isTimerOff = true;
        }
        else if (maxRounds % 2 == 0) // Significa que el numero de rondas es par y por lo tanto puede haber empate
        {
            if(player1Points == player2Points && player1Points == maxRounds / 2)
            {
                winTieCondition = WinTieCondition.Tie;
                isTimerOff = true;
            }
        }
    }

    // Get para volver a tomar las variables de inicio en caso de que sean modificadas a la mitad de un juego y al inicio
    public void GetInitialVariables()
    {
        maxRounds = data.maxRounds;
        roundsToWin = data.maxRounds / 2 + 1; // Calculo los rounds necesarios para ganar

        maxTimeGoal = data.maxTimeGoal;
        timerGoal = data.maxTimeGoal;
    }

    // Setters para sumarle puntaje a cada jugador
    public void SetPlayer1WinPoints()
    {
        // Aseguro que sume solo un punto
        // Suggestion: goal se pone en true en la línea anterior y el if de abajo pregunta por esa misma variable, así que siempre entra. El comentario dice que es para asegurar que sume un solo punto, pero el if no hace eso.
        // Dejá solo player1Points++ y goal = true. Lo mismo en SetPlayer2WinPoints.
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

    // Reset de la variable para que el contador regresivo vuelva a correr
    public void ResetTimerOffState()
    {
        isTimerOff = false;
    }
}
