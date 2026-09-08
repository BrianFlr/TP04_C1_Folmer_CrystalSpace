using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Creo un enum para diferenciar jugadores desde el editor
    enum PlayerId
    {
        Player1 = 0,
        Player2 = 1
    }

    [SerializeField] private PlayerId playerId;
    [SerializeField] private float defaultColor = 0f;
    private float newColor = 0f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Dependiendo la ID de player, carga el color mediante la clave correspondiente con la que esta fue guardada
        if (playerId == PlayerId.Player1)
        {
            GetPlayerColorsValues("Player1Color");
        }
        else
        {
            GetPlayerColorsValues("Player2Color");
        }

        // Cambio el color del player
        spriteRenderer.color = new Color(newColor, defaultColor, Random.value);
    }

    // Función para obtener los valores de colores seteados en settings y asignárselo al sprite
    private void GetPlayerColorsValues(string playerPrefsKey) // La clave con la que guardé los colores es el parámetro a recibir 
    {
        newColor = PlayerPrefs.GetFloat(playerPrefsKey, defaultColor);
    }
}
