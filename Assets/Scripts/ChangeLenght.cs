using UnityEngine;

public class ChangeLenght : MonoBehaviour
{
    // Creo un enum para diferenciar jugadores desde el editor
    enum PlayerId
    {
        Player1 = 0,
        Player2 = 1
    }

    [SerializeField] private PlayerId playerId;
    [SerializeField] private float defaultLenght = 4f;
    private float newLenght = 0;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Dependiendo la ID de player, carga el largo mediante la clave correspondiente con la que esta fue guardada
        if (playerId == PlayerId.Player1)
        {
            GetPlayerLenghtValue("Player1Lenght");
        }
        else
        {
            GetPlayerLenghtValue("Player2Lenght");
        }
    }

    private void FixedUpdate()
    {
        // Cambio el largo del player
        rb.transform.localScale = new Vector3(defaultLenght, newLenght, defaultLenght);
    }

    // Función para obtener los valores de largo seteados en settings y asignárselo al sprite
    private void GetPlayerLenghtValue(string playerPrefsKey) // La clave con la que guardé el largo es el parámetro a recibir 
    {
        newLenght = PlayerPrefs.GetFloat(playerPrefsKey, defaultLenght);
    }
}
