using UnityEngine;

public class PlayerChangeColor : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

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
    }

    //Función para obtener los valores de colores seteados en settings y asignárselo al sprite
    private void GetPlayerColorsValues(string playerPrefsKey) // La clave con la que guardé los colores es el parámetro a recibir 
    {
        float colorValue = PlayerPrefs.GetFloat(playerPrefsKey, 0);
        //Color randomColor = Color.Lerp(data.colorFor, data.colorTo, colorValue);
        //spriteRenderer.color = randomColor;
    }
}
