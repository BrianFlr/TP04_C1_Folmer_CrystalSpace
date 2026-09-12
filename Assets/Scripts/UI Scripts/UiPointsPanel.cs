using TMPro;
using UnityEngine;

public class UiPointsPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text textTimer;
    [SerializeField] private TMP_Text textPlayer1Points;
    [SerializeField] private TMP_Text textPlayer2Points;

    // Update is called once per frame
    void Update()
    {
        textTimer.text = GameManager.Instance.GetTimerGoalValue().ToString("0");
        textPlayer1Points.text = GameManager.Instance.GetPlayer1Points().ToString("0");
        textPlayer2Points.text = GameManager.Instance.GetPlayer2Points().ToString("0");
    }
}
