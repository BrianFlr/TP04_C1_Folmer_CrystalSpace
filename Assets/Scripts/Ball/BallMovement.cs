using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private float ballSpeed = 5f;
    private float ballMaxSpeed = 25f;
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
