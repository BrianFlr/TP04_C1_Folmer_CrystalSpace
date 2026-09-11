using UnityEngine;

[CreateAssetMenu(fileName = "GameplayData", menuName = "Data/Game/GameplayData")]

public class GameplayDataSo : ScriptableObject
{
    [Header("Rounds To Win")]
    [Range(3, 7)] public int roundsToWin = 3;

    [Header("Rounds Quantity")]
    [Range(3, 15)] public int maxRounds = 5;
   
    [Header("Limit Time Goal")]
    [Range(5, 40)] public int maxTimeGoal = 20;
}
