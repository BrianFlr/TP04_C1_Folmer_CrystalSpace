using UnityEngine;

public class Movement : MonoBehaviour
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
    }

    // Función para obtener los valores de velocidad seteados en settings y asignárselo a la velocidad con la que se va a mover el sprite
    private void GetPlayerSpeedValue(string playerPrefsKey) // La clave con la que guardé la velocidad es el parámetro a recibir 
    {
        currentSpeed = PlayerPrefs.GetFloat(playerPrefsKey, currentSpeed);
    }

}
