using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Game/PlayerData")]

public class PlayerDataSo : ScriptableObject
{
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
