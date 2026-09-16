using UnityEngine;

public class PlayerCollisionColor : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    [SerializeField] private GameObject ball;
    private Color initialColor = Color.white;
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Cuando colisiona con las paredes el sprite se tinta de gris oscuro (Esto para que se vea por el tono del fondo)
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
