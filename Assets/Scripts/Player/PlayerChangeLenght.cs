using UnityEngine;

public class PlayerChangeLenght : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    private float playerLenght = 0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Cargo los valores default de la altura del jugador
        playerLenght = data.lenght;
    }

    private void FixedUpdate()
    {
        // Cambio el largo del player
        // Warning: la escala se reescribe en cada frame de física con un valor que casi nunca cambia, y además se lee el SO en cada Update para eso. Es el mismo punto que te marqué en el TP03.
        // Aplicá la escala en el Start y cuando el slider avise que cambió; el FixedUpdate no hace falta.
        rb.transform.localScale = new Vector3(data.width, playerLenght, 0);
    }
}
