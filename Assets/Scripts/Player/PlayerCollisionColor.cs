using UnityEngine;

public class PlayerCollisionColor : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private Color initialColor = Color.white;
    private Color collisionBallColor = Color.white;

    private Rigidbody2D rbPlayer;
    private SpriteRenderer srPlayer;

    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        srPlayer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        initialColor = srPlayer.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == ball) // Si colisiono con la pelota cambio de color de forma aleatoria
        {
            // Cambio de color de forma aleatoria
            srPlayer.color = new Color(Random.value, Random.value, Random.value);

            // Guardo ese color actual en una variable
            collisionBallColor = srPlayer.color;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Cuando colisiona con las paredes el sprite se tinta de gris oscuro (Esto para que se vea por el tono del fondo)
        srPlayer.color = new Color(0.2f, 0.2f, 0.2f);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject != ball)
        {
            // Al dejar de colisionar con el muro actualiza el color al del principio de la partida o al random dado al colisionar con la pelota
            if (initialColor != Color.white)
            {
                srPlayer.color = initialColor;
            }
            else
            {
                srPlayer.color = collisionBallColor;
            }
        }
    }
}
