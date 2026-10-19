using UnityEngine;

public class PlayerCollisionColor : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    [SerializeField] private GameObject ball;
    private Color initialColor = Color.white;
    // Suggestion: actualColor arranca en blanco, guarda el último color aleatorio y en el OnCollisionExit2D se vuelve a igualar a initialColor, así que funciona como bandera y como valor a la vez.
    // Separá las dos cosas: un bool hasRandomColor y un Color randomColor. Hoy hay que leer los tres métodos juntos para entender qué queda pintado.
    private Color actualColor = Color.white;

    private float timerColor = 0f;
    private float timeToChangeColor = 2f;

    private SpriteRenderer srPlayer;

    private void Awake()
    {
        srPlayer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        srPlayer.color = data.color;
        initialColor = data.color;
    }

    private void Update()
    {
        // Si el sprite posee un color distinto al original, se resetea luego de x segundos
        if (srPlayer.color != initialColor)
        {
            timerColor += Time.deltaTime;

            if (timerColor >= timeToChangeColor)
            {
                srPlayer.color = initialColor;

                timerColor = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == ball) // Si colisiono con la pelota cambio de color de forma aleatoria
        {
            // Cambio de color de forma aleatoria
            srPlayer.color = new Color(Random.value, Random.value, Random.value);

            actualColor = srPlayer.color;
        }
    }

    // Bug: este OnCollisionStay2D no chequea contra qué chocó, así que pinta gris oscuro también cuando la paleta está tocando la pelota.
    // El color aleatorio que acabás de sortear en OnCollisionEnter2D se pisa en el mismo contacto y recién vuelve en el OnCollisionExit2D. Filtrá igual que arriba: if (collision.gameObject != ball).
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Cuando colisiona con las paredes el sprite se tinta de gris oscuro (Esto para que se vea por el tono del fondo)
        // Suggestion: la consigna pide que el color pase a Negro cuando la paleta golpea un límite, y acá es (0.2, 0.2, 0.2), gris oscuro.
        // Se entiende el motivo por el comentario de arriba, pero conviene dejar el negro exacto y resolver el contraste con un borde o con un flash, no cambiando el color pedido.
        srPlayer.color = new Color(0.2f, 0.2f, 0.2f);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject != ball)
        {
            // Si al salir de la colision el sprite poseía un color distinto al original, muestra ese color
            if(actualColor != initialColor)
            {
                srPlayer.color = actualColor;
                actualColor = initialColor;
            }
            else
            {
                srPlayer.color = initialColor;
            }
        }
    }
}
