using UnityEngine;

[CreateAssetMenu(fileName = "GameplayData", menuName = "Data/Game/GameplayData")]

public class GameplayDataSo : ScriptableObject
{
    [HideInInspector] public int roundsToWin = 3;

    [Header("Rounds Quantity")]
    [Range(3, 15)] public int maxRounds = 5;
   
    [Header("Limit Time Goal")]
    [Range(5, 40)] public int maxTimeGoal = 20;


    //roundsToWin = maxRounds / 2 + 0.5f
}
