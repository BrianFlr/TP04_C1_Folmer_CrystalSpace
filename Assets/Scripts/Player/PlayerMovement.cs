using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    private float currentSpeed = 0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Cargo el valor default de velocidad del jugador
        // Warning: currentSpeed se vuelve a copiar del ScriptableObject en cada frame para un valor que solo cambia cuando el jugador mueve el slider.
        // Leelo en el Start y volvé a leerlo cuando se cierra el panel de settings. Si querés que se aplique en vivo, que el slider avise con un evento.
        currentSpeed = data.moveSpeed;
    }

    private void FixedUpdate()
    {
        // Declaro variable vector igualado a 0 para frenar al jugador
        Vector2 direction = Vector2.zero;

        // Dependiendo la tecla que presiono se modifica el vector de direccion
        if (Input.GetKey(data.moveUp))
        {
            direction += new Vector2(0, 1);
        }

        if (Input.GetKey(data.moveDown))
        {
            direction += new Vector2(0, -1);
        }

        if (Input.GetKey(data.moveRight))
        {
            direction += new Vector2(1, 0);
        }

        if (Input.GetKey(data.moveLeft))
        {
            direction += new Vector2(-1, 0);
        }
        
        // Finalmente a la direccion le multiplico la velocidad para aplicar el movimiento
        rb.linearVelocity = direction.normalized * currentSpeed;
    }
}
