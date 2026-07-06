using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public Transform player1Spawn;
    public Transform player2Spawn;

    private void Start()
    {
        SpawnPlayers();
    }

    private void SpawnPlayers()
    {
        // PLAYER 1
        GameObject p1 = Instantiate(
            GameManager.Instance.player1.bolinhaEscolhida.prefab,
            new Vector3(player1Spawn.position.x, 0.5f, player1Spawn.position.z),
            Quaternion.identity
        );

        var p1Renderer = p1.GetComponent<MeshRenderer>();
        p1Renderer.material = GameManager.Instance.player1.bolinhaEscolhida.material;

        BolinhaController p1Controller = p1.GetComponent<BolinhaController>();
        p1Controller.Setup(true);


        // PLAYER 2
        GameObject p2 = Instantiate(
            GameManager.Instance.player2.bolinhaEscolhida.prefab,
            new Vector3(player2Spawn.position.x, 0.5f, player2Spawn.position.z),
            Quaternion.identity
        );

        var p2Renderer = p2.GetComponent<MeshRenderer>();
        p2Renderer.material = GameManager.Instance.player2.bolinhaEscolhida.material;

        BolinhaController p2Controller = p2.GetComponent<BolinhaController>();
        p2Controller.Setup(false);


        // Cada bolinha conhece seu inimigo
        p1Controller.SetEnemy(p2);
        p2Controller.SetEnemy(p1);

        CooldownUI ui = FindFirstObjectByType<CooldownUI>();

ui.player1 = p1Controller;
ui.player2 = p2Controller;

MatchManager.Instance.SetPlayers(p1Controller, p2Controller);
    }
}