using TMPro;
using UnityEngine;

public class UiWinTieMenu : MonoBehaviour
{
    [Header("Canvas WinTie")]
    [SerializeField] private Canvas canvasWinTie;

    [Header("Canvas WinTie Text")]
    [SerializeField] private TMP_Text textWinTie;

    private void Update()
    {
        // Mediante el siguiente switch defino que se mostrara en el mensaje al final del juego
        switch (GameManager.Instance.GetWinTieCondition())
        {
            case GameManager.WinTieCondition.Player1Win:
                textWinTie.text = "Player 1 Wins!";
                break;
            case GameManager.WinTieCondition.Player2Win:
                textWinTie.text = "Player 2 Wins!";
                break;
            case GameManager.WinTieCondition.Tie:
                textWinTie.text = "TIE!";
                break;
            default:
                break;
        }
    }
}
