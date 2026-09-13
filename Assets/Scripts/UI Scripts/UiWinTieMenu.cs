using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class UiWinTieMenu : MonoBehaviour
{
    [Header("Canvas WinTie")]
    [SerializeField] private GameObject canvasWinTie;

    [Header("Canvas WinTie Text")]
    [SerializeField] private TMP_Text textWinTie;

    [Header("Retry Button")]
    [SerializeField] private Button btnRetry;

    private void Awake()
    {
        btnRetry.onClick.AddListener(OnRetryClicked);
    }

    private void Update()
    {
        // Si la variable enum indica condicion de victoria y a su
        if (GameManager.Instance.GetWinTieCondition() != WinTieCondition.None)
        {
            // Detengo el juego
            Time.timeScale = 0;

            // Activo el canvas de ganar o empatar
            canvasWinTie.SetActive(true);

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

            // Reseteo la variable una vez que me mostro que finalizo el juego
            GameManager.Instance.ResetWinTieCondition();
        }
    }

    private void OnDestroy()
    {
        btnRetry.onClick.RemoveAllListeners();
    }

    // Eventos de botones
    private void OnRetryClicked()
    {
        // Reseteo los puntos de los jugadores
        GameManager.Instance.ResetPlayersPoints();

        // Reanudo el tiempo del juego
        Time.timeScale = 1;

        // Desactivo el panel de WinTie
        canvasWinTie.SetActive(false);
    }
}
