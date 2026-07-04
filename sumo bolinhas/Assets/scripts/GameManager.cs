using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerData player1;
    public PlayerData player2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            player1 = new PlayerData();
            player2 = new PlayerData();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}