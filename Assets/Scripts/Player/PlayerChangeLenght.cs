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
        rb.transform.localScale = new Vector3(data.width, playerLenght, 0);
    }
}
