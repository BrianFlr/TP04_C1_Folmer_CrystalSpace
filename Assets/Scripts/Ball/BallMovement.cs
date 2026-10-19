using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Warning: los siete valores de la pelota (velocidad inicial, máxima, incremento, intervalo, ratios y límites de mapa) están hardcodeados acá, mientras que los del jugador y los de la partida sí viven en un ScriptableObject.
    // La consigna pide los valores de inicialización en SO: armá un BallDataSo con estos siete campos y quedás consistente con el resto del proyecto.
    private float ballSpeed = 5f;
    private float ballMaxSpeed = 25f;
    // Suggestion: bosterSpeed va con dos oes (boosterSpeed), y lenght va con la h antes de la t (length) en PlayerDataSo.cs:17, PlayerChangeLenght.cs y UiSettingsSliderLenght.cs.
    // Son los mismos dos tipeos que te marqué en el TP03 y ya se propagaron al nombre de tres archivos y a los campos del inspector.
    private float bosterSpeed = 0.1f;

    private float timerBoostSpeed = 0f;
    private float timeBoostSpeed = 2f;

    private float ratioY = 4f;
    private float ratioX = 0.2f;


    [SerializeField] Rigidbody2D player1;
    [SerializeField] Rigidbody2D player2;
    private float mapLimitPositionY = 4.9f;
    private float resetBallPositionY = 4.8f;

    private Rigidbody2D rbBall;

    private void Awake()
    {
        rbBall = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Creo una variable para asiganarle un valor random y así la pelota no vaya siempre para un mismo lado al comienzo
        int randomValue = Random.Range(0, 2);

        if (randomValue == 0)
        {
            // Empujo la pelota hacia la derecha
            rbBall.AddForce(Vector3.right * ballSpeed, ForceMode2D.Impulse);
        }
        else
        {
            // Empujo la pelota hacia la izquierda
            rbBall.AddForce(Vector3.left * ballSpeed, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // Registro el tiempo transcurrido
        timerBoostSpeed += Time.fixedDeltaTime;

        // Aumento la velocidad de la pelota cada x segundos
        if (timerBoostSpeed >= timeBoostSpeed)
        {
            if (ballSpeed < ballMaxSpeed)
            {
                ballSpeed += bosterSpeed;
            }

            // Reseteo el contador restando
            timerBoostSpeed -= timeBoostSpeed;

            ClampDirection();
        }

        // Con esto me aseguro de que la pelota se mantenga dentro de la escena y no salga disparada si un jugador la presiona contra un muro
        if (rbBall.position.y > mapLimitPositionY)
        {
            rbBall.position = new Vector2(rbBall.position.x, resetBallPositionY);
        }
        else if (rbBall.position.y < -mapLimitPositionY)
        {
            rbBall.position = new Vector2(rbBall.position.x, -resetBallPositionY);
        }
    }

    // Deteccion de colisión de la pelota
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Aumento velocidad de la pelota por cada rebote
        ballSpeed = Mathf.Clamp(ballSpeed + bosterSpeed, 0f, ballMaxSpeed);

        ClampDirection();
    }

    private void ClampDirection()
    {
        // Aseguro que la pelota nunca quede rebotando de forma recta
        Vector2 direction = rbBall.linearVelocity;

        if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x) * ratioY)
        {
            direction.x = Mathf.Sign(direction.x);
            direction.y = Mathf.Sign(direction.y) * ratioY;
        }
        else if (Mathf.Abs(direction.y) < Mathf.Abs(direction.x) * ratioX)
        {
            direction.x = Mathf.Sign(direction.x);
            direction.y = Mathf.Sign(direction.y) * ratioX;
        }

        // Le multiplico la dirección actual de la pelota a la nueva velocidad
        rbBall.linearVelocity = direction.normalized * ballSpeed;
    }
}
