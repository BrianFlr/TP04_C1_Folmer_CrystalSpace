using UnityEngine;

public class GoalTriggers : MonoBehaviour
{
    [SerializeField] private Collider2D player1GoalZone;
    [SerializeField] private Collider2D player2GoalZone;
    [SerializeField] private Collider2D leftGoalTrigger;
    [SerializeField] private Collider2D rightGoalTrigger;

    private Rigidbody2D rbBall;

    private void Awake()
    {
        rbBall = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Debug.Log(GameManager.Instance.GetTimerGoalValue());
    }

    // Deteccion de la zona de gol de los jugadores
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Si la pelota entra en la zona de gol del jugador 1
        if (collider == player1GoalZone)
        {
            // Llamo el setter de la instancia de GameManager para sumar un punto al jugador 2
            GameManager.Instance.SetPlayer2WinPoints();
            GameManager.Instance.ResetTimerGoal();
        }

        // Si la pelota entra en la zona de gol del jugador 2
        if (collider == player2GoalZone)
        {
            // Realizo lo mismo de antes pero para sumarle un punto al jugador 1
            GameManager.Instance.SetPlayer1WinPoints();
            GameManager.Instance.ResetTimerGoal();
        }
    }

    // Deteccion de las zonas que definen a que jugador sumar un punto al terminar el tiempo maximo disponible para anotar
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GameManager.Instance.GetTimerGoalValue() <= 0) // Si el contador llego a 0
        {
            if (collision == leftGoalTrigger)
            {
                GameManager.Instance.SetPlayer2WinPoints();
                GameManager.Instance.ResetTimerGoal();
            }

            if (collision == rightGoalTrigger)
            {
                GameManager.Instance.SetPlayer1WinPoints();
                GameManager.Instance.ResetTimerGoal();
            }
        }
    }


}
