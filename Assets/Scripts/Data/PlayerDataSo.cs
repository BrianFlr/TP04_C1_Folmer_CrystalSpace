using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Game/PlayerData")]

public class PlayerDataSo : ScriptableObject
{
    // Warning: los ocho campos son public y los sliders y los toggles los escriben en runtime. En el editor eso queda grabado en el .asset entre sesiones, y en el build se pierde al cerrar.
    // Dejalos [SerializeField] private con getters y un método Set por cada valor que la UI necesita cambiar. Vale lo mismo para los dos campos de GameplayDataSo.cs:8.
    public string playerName = "PlayerXX";

    [Header("Movement")]
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    [Range(1, 10)] public float moveSpeed = 5f;

    [Header("Lenght")]
    [Range(2, 8)] public float lenght = 4f;
    [HideInInspector] public float width = 4f;

    [Header("Color")]
    public Color color = Color.white;
}
