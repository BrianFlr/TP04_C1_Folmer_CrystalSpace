using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Game/PlayerData")]

public class PlayerDataSo : ScriptableObject
{
    [Header("Movement")]
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    [Range(0, 15)] public float speed = 5.0f;

    [Header("Lenght - Anchor")]
    [Range(1, 10)] public float lenght = 5.0f;
    [Range(1, 7)] public float anchor = 4.0f;

    [Header("Color")]
    public Color color = Color.white;
    public Color colorFor = Color.green;
    public Color colorTo = Color.green;
}
