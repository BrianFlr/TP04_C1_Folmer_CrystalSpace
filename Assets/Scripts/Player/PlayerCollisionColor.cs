using UnityEngine;

public class PlayerCollisionColor : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private Color actualColor = Color.white;

    private Rigidbody2D rbPlayer;
    private SpriteRenderer srPlayer;

    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        srPlayer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == ball) // Si colisiono con la pelota cambio de color de forma aleatoria
        {
            // Cambio de color de forma aleatoria
            srPlayer.color = new Color(Random.value, Random.value, Random.value);

            // Guardo ese color actual en una variable
            actualColor = srPlayer.color;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Cuando colisiona con las paredes el sprite se tinta de gris oscuro (Esto para que se vea por el tono el fondo)
        srPlayer.color = new Color(0.2f, 0.2f, 0.2f);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject != ball)
        {
            // Al salir de colisionar con el muro actualiza el color al que tenia antes de chocar contra el mismo
            srPlayer.color = actualColor;
        }
    }
}
