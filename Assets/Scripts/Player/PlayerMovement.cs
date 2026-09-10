using Unity.Android.Gradle.Manifest;
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
        // Movimiento del jugador por posicionamiento
        if (Input.GetKey(data.moveUp))
        {
            rb.position += new Vector2(0, currentSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(data.moveDown))
        {
            rb.position += new Vector2(0, -currentSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(data.moveRight))
        {
            rb.position += new Vector2(currentSpeed * Time.fixedDeltaTime, 0);
        }

        if (Input.GetKey(data.moveLeft))
        {
            rb.position += new Vector2(-currentSpeed * Time.fixedDeltaTime, 0);
        }
    }

    // Función para obtener los valores de velocidad seteados en settings y asignárselo a la velocidad con la que se va a mover el sprite
    private void GetPlayerSpeedValue(string playerPrefsKey) // La clave con la que guardé la velocidad es el parámetro a recibir 
    {
        currentSpeed = PlayerPrefs.GetFloat(playerPrefsKey, data.Speed);
    }

}
