using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Creo un enum para diferenciar jugadores desde el editor
    enum PlayerId
    {
        Player1 = 0,
        Player2 = 1
    }

    [SerializeField] private PlayerId playerId;
    [SerializeField] private float currentSpeed = 5.0f;
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Dependiendo la ID de player, carga la velocidad mediante la clave correspondiente con la que esta fue guardada
        if (playerId == PlayerId.Player1)
        {
            GetPlayerSpeedValue("Player1Speed");
        }
        else
        {
            GetPlayerSpeedValue("Player2Speed");
        }
    }

    private void FixedUpdate()
    {
        // Movimiento del jugador por posicionamiento
        if (Input.GetKey(moveUp))
        {
            rb.position += new Vector2(0, currentSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(moveDown))
        {
            rb.position += new Vector2(0, -currentSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(moveRight))
        {
            rb.position += new Vector2(currentSpeed * Time.fixedDeltaTime, 0);
        }

        if (Input.GetKey(moveLeft))
        {
            rb.position += new Vector2(-currentSpeed * Time.fixedDeltaTime, 0);
        }
    }

    // Función para obtener los valores de velocidad seteados en settings y asignárselo a la velocidad con la que se va a mover el sprite
    private void GetPlayerSpeedValue(string playerPrefsKey) // La clave con la que guardé la velocidad es el parámetro a recibir 
    {
        currentSpeed = PlayerPrefs.GetFloat(playerPrefsKey, currentSpeed);
    }

}
