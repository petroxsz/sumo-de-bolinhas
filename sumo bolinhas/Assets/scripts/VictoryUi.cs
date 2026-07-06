using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VictoryUI : MonoBehaviour
{
    public TMP_Text winnerText;
    public TMP_Text winnerBallText;

    private void Start()
    {
        int winner = PlayerPrefs.GetInt("Winner", 0);
        string ball = PlayerPrefs.GetString("WinnerBall", "Desconhecida");

        winnerText.text = "Jogador " + winner + " venceu!";
        winnerBallText.text = "Bolinha utilizada:\n" + ball;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SelectionScene");
    }
}