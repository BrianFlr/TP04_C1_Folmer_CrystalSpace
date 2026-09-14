using UnityEngine;

public class PlayerChangeColor : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    private SpriteRenderer spriteRenderer;

    private float timerColor = 0f;
    private float timeToChangeColor = 3f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //Cargo el valor default de color del jugador
        spriteRenderer.color = data.color;
    }

    private void Update()
    {
        // Registro el tiempo transcurrido
        timerColor += Time.deltaTime;

        // Vuelvo al color definido en la configuracion cada x segundos
        if (timerColor >= timeToChangeColor)
        {
            spriteRenderer.color = data.color;

            // Reseteo el contador
            timerColor -= timeToChangeColor;
        }
    }
}
