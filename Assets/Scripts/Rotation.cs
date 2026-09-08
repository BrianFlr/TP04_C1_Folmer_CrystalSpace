using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10.0f;
    [SerializeField] private KeyCode rotateLeft = KeyCode.Q;
    [SerializeField] private KeyCode rotateRight = KeyCode.E;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Rotacion del sprite
        if (Input.GetKeyDown(rotateLeft))
        {
            // Solo rotarlo 10 grados
            rigidBody.rotation += rotateSpeed;

            // Fuerza continua
            //rigidBody.AddTorque(rotateSpeed, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(rotateRight))
        {
            // Solo rotarlo 10 grados
            rigidBody.rotation -= rotateSpeed;

            // Fuerza continua
            //rigidBody.AddTorque(-rotateSpeed, ForceMode2D.Impulse);
        }
    }
}
