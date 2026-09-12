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
        Vector2 direction = Vector2.zero;

        // Movimiento del jugador
        if (Input.GetKey(data.moveUp))
        {
            direction += new Vector2(0, 1);
        }

        if (Input.GetKey(data.moveDown))
        {
            direction += new Vector2(0, -1);
        }

        if (Input.GetKey(data.moveRight))
        {
            direction += new Vector2(1, 0);
        }

        if (Input.GetKey(data.moveLeft))
        {
            direction += new Vector2(-1, 0);
        }
        
        rb.linearVelocity = direction.normalized * currentSpeed;
    }

    // Función para obtener los valores de velocidad seteados en settings y asignárselo a la velocidad con la que se va a mover el sprite
    private void GetPlayerSpeedValue(string playerPrefsKey) // La clave con la que guardé la velocidad es el parámetro a recibir 
    {
        currentSpeed = PlayerPrefs.GetFloat(playerPrefsKey, data.Speed);
    }

}
