using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;

    // Observer ta aq
    public static event Action<int, int> OnRoundsUpdated;

    public BolinhaController player1;
    public BolinhaController player2;

    public Transform p1Spawn;
    public Transform p2Spawn;

    private int p1Rounds = 0;
    private int p2Rounds = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnRoundsUpdated?.Invoke(p1Rounds, p2Rounds);
    }

    public void SetPlayers(BolinhaController p1, BolinhaController p2)
    {
        player1 = p1;
        player2 = p2;
    }

    public void PlayerDied(BolinhaController player)
    {
        if (player == player1)
        {
            p2Rounds++;
            Debug.Log("Player 2 ganhou o round!");
        }
        else
        {
            p1Rounds++;
            Debug.Log("Player 1 ganhou o round!");
        }

        // Dispara o evento
        OnRoundsUpdated?.Invoke(p1Rounds, p2Rounds);

        CheckMatchWinner();

        Respawn();
    }

    private void CheckMatchWinner()
    {
        if (p1Rounds >= 2)
        {
            EndMatch(1);
        }
        else if (p2Rounds >= 2)
        {
            EndMatch(2);
        }
    }

    private void EndMatch(int winner)
{
    Debug.Log("JOGADOR " + winner + " VENCEU A PARTIDA!");

    PlayerPrefs.SetInt("Winner", winner);

    if (winner == 1)
    {
        PlayerPrefs.SetString("WinnerBall", GameManager.Instance.player1.bolinhaEscolhida.nome);
    }
    else
    {
        PlayerPrefs.SetString("WinnerBall", GameManager.Instance.player2.bolinhaEscolhida.nome);
    }

    SceneManager.LoadScene("VictoryScene");
}

    private void Respawn()
    {
        ResetPlayer(player1, p1Spawn.position);
        ResetPlayer(player2, p2Spawn.position);
    }

    private void ResetPlayer(BolinhaController player, Vector3 pos)
    {
        player.transform.position = pos;

        Rigidbody rb = player.GetComponent<Rigidbody>();

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}