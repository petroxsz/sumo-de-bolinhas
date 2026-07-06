using TMPro;
using UnityEngine;

public class RoundUIManager : MonoBehaviour
{
    public static RoundUIManager Instance;

    public TMP_Text player1RoundsText;
    public TMP_Text player2RoundsText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateRounds(int p1Rounds, int p2Rounds)
    {
        player1RoundsText.text = "P1: " + p1Rounds;
        player2RoundsText.text = "P2: " + p2Rounds;
    }
}