using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class VictoryUI : MonoBehaviour
{
    public TMP_Text winnerText;
    public TMP_Text winnerBallText;

    public Image winnerBallImage;

    private void Start()
    {
        int winner = PlayerPrefs.GetInt("Winner", 0);
        string ball = PlayerPrefs.GetString("WinnerBall", "Desconhecida");

        winnerText.text = "Jogador " + winner + " venceu!";
        winnerBallText.text = "Bolinha utilizada:\n" + ball;

        BolinhaData[] bolinhas = Resources.LoadAll<BolinhaData>("Bolinhas");

        foreach (BolinhaData b in bolinhas)
        {
            if (b.nome == ball)
            {
                winnerBallImage.sprite = b.sprite;
                break;
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SelectionScene");
    }
}