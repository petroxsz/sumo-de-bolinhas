using TMPro;
using UnityEngine;

public class RoundUIManager : MonoBehaviour
{
    public TMP_Text player1RoundsText;
    public TMP_Text player2RoundsText;

    private void OnEnable()
    {
        MatchManager.OnRoundsUpdated += UpdateRounds;
    }

    private void OnDisable()
    {
        MatchManager.OnRoundsUpdated -= UpdateRounds;
    }

    private void UpdateRounds(int p1Rounds, int p2Rounds)
    {
        player1RoundsText.text = "P1: " + p1Rounds;
        player2RoundsText.text = "P2: " + p2Rounds;
    }
}