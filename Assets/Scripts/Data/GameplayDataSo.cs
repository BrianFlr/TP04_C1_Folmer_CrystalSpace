using UnityEngine;

[CreateAssetMenu(fileName = "GameplayData", menuName = "Data/Game/GameplayData")]

public class GameplayDataSo : ScriptableObject
{
    [Header("Rounds Quantity")]
    [Range(1, 20)] public int maxRounds = 5;
   
    [Header("Limit Time Goal")]
    [Range(5, 50)] public int maxTimeGoal = 20;
}
