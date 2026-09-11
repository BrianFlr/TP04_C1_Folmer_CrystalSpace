using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Creo un enum para diferenciar jugadores desde el editor
    enum PlayerId
    {
        Player1 = 0,
        Player2 = 1
    }

    [SerializeField] private PlayerDataSo data;

    [Header("Player ID")]
    [SerializeField] private PlayerId playerId;
    
    [SerializeField] public float currentSpeed = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Cargo los el valor default de velocidad del jugador
        currentSpeed = data.Speed;

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
        if (Input.anyKey) 
        {
            // Movimiento del jugador
            if (Input.GetKey(data.moveUp))
            {
                rb.linearVelocity = new Vector2(0, 1).normalized * currentSpeed;
            }

            if (Input.GetKey(data.moveDown))
            {
                rb.linearVelocity = new Vector2(0, -1) * currentSpeed;
            }

            if (Input.GetKey(data.moveRight))
            {
                rb.linearVelocity = new Vector2(1, 0) * currentSpeed;
            }

            if (Input.GetKey(data.moveLeft))
            {
                rb.linearVelocity = new Vector2(-1, 0) * currentSpeed;
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    // Función para obtener los valores de velocidad seteados en settings y asignárselo a la velocidad con la que se va a mover el sprite
    private void GetPlayerSpeedValue(string playerPrefsKey) // La clave con la que guardé la velocidad es el parámetro a recibir 
    {
        currentSpeed = PlayerPrefs.GetFloat(playerPrefsKey, data.Speed);
    }

}
