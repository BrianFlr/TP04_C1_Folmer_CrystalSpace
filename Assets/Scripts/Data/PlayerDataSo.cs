using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Game/PlayerData")]

public class PlayerDataSo : ScriptableObject
{
    [Header("Movement")]
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    [Range(0, 15)] public float Speed = 5.0f;

    [Header("Lenght - Anchor")]
    [Range(1, 10)] public float Lenght = 5.0f;
    [Range(1, 7)] public float Anchor = 4.0f;

    [Header("Color")]
    public Color color = Color.white;
}
