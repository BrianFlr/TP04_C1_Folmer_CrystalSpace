using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    [SerializeField] private PlayerId playerId;
    [SerializeField] private Color color = Color.white;
    private Color newColor = Color.red;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //Cargo el valor default de color del jugador
        spriteRenderer.color = data.color;

        // Dependiendo la ID de player, carga el color mediante la clave correspondiente con la que esta fue guardada
        if (playerId == PlayerId.Player1)
        {
            GetPlayerColorsValues("Player1Color");
        }
        else
        {
            GetPlayerColorsValues("Player2Color");
        }

        //    // Cambio el color del player

        //    Color randomColor = new Color(newColor, defaultColor, Random.value);
        //    randomColor.a = 1;
        //    spriteRenderer.color = randomColor;
    }

    //Función para obtener los valores de colores seteados en settings y asignárselo al sprite
    private void GetPlayerColorsValues(string playerPrefsKey) // La clave con la que guardé los colores es el parámetro a recibir 
    {
        float colorValue = PlayerPrefs.GetFloat(playerPrefsKey, 0);
        Color randomColor = Color.Lerp(data.colorFor, data.colorTo, colorValue);
        spriteRenderer.color = randomColor;
    }
}
