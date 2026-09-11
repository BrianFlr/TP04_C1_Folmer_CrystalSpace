using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 5f;
    [SerializeField] private float ballMaxSpeed = 25f;
    [SerializeField] private float bosterSpeed = 0.1f;
    private float initialAngleX = 1f;
    private float initialAngleY = 0.4f;
    private float timerBoostSpeed = 0f;
    private float timeBoostSpeed = 2f;

    private Rigidbody2D rbBall;

    private void Awake()
    {
        rbBall = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Creo una variable para asiganarle un valor random y así la pelota no vaya siempre para un mismo lado al comienzo
        int randomValue = Random.Range(0,2);

        if (randomValue == 0)
        {
            // Empujo la pelota hacia la derecha
            rbBall.linearVelocity = new Vector2(initialAngleX, initialAngleY).normalized * ballSpeed;
        }
        else
        {
            // Empujo la pelota hacia la izquierda
            rbBall.linearVelocity = new Vector2(-initialAngleX, -initialAngleY).normalized * ballSpeed;
            //rbBall.AddForce(rbBall.linearVelocity);
        }
    }

    private void Update()
    {
        // Registro el tiempo transcurrido
        timerBoostSpeed += Time.deltaTime;

        // Aumento la velocidad de la pelota cada x segundos
        if (timerBoostSpeed >= timeBoostSpeed)
        {
            if (ballSpeed < ballMaxSpeed)
            {
                ballSpeed += bosterSpeed;
            }

            // Le multiplico la dirección actual de la pelota a la nueva velocidad
            rbBall.linearVelocity = rbBall.linearVelocity.normalized * ballSpeed;

            // Reseteo el contador restando
            timerBoostSpeed -= timeBoostSpeed;
        }
     }

    // Deteccion de colisión de la pelota
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Aumento velocidad de la pelota por cada rebote
        ballSpeed = Mathf.Clamp(ballSpeed + bosterSpeed, 0f, ballMaxSpeed);

        // Le multiplico la dirección actual de la pelota a la nueva velocidad
        rbBall.linearVelocity = rbBall.linearVelocity.normalized * ballSpeed;
    }
}
