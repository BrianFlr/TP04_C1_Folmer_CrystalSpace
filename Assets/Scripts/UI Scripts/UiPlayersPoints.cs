using TMPro;
using UnityEngine;

public class UiPlayersPoints : MonoBehaviour
{
    [Header("Canvas Players Points Text")]
    [SerializeField] private TMP_Text textTimer;
    [SerializeField] private TMP_Text textPlayer1Points;
    [SerializeField] private TMP_Text textPlayer2Points;

    [Header("Canvas WinTie Text")]
    [SerializeField] private TMP_Text textWinTie;

    void Update()
    {
        // Muestro la cuenta regresiva y los puntos de cada jugador en el panel de puntos
        textTimer.text = GameManager.Instance.GetTimerGoalValue().ToString("0");
        textPlayer1Points.text = GameManager.Instance.GetPlayer1Points().ToString("0");
        textPlayer2Points.text = GameManager.Instance.GetPlayer2Points().ToString("0");
    }
}
