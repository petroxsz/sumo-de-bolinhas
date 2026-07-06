using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VictoryUI : MonoBehaviour
{
    public TMP_Text winnerText;

    private void Start()
    {
        int winner = PlayerPrefs.GetInt("Winner", 0);

        winnerText.text = "Jogador " + winner + " venceu!";
    }

    public void Restart()
    {
        SceneManager.LoadScene("SelectionScene");
    }
}