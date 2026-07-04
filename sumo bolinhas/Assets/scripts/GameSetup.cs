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
    GameObject p1 = Instantiate(
        GameManager.Instance.player1.bolinhaEscolhida.prefab,
        new Vector3(player1Spawn.position.x, 0.5f, player1Spawn.position.z),
        Quaternion.identity
    );

    // aplicar material
    var p1Renderer = p1.GetComponent<MeshRenderer>();
    p1Renderer.material = GameManager.Instance.player1.bolinhaEscolhida.material;

    p1.GetComponent<BolinhaController>().Setup(true);


    GameObject p2 = Instantiate(
        GameManager.Instance.player2.bolinhaEscolhida.prefab,
        new Vector3(player2Spawn.position.x, 0.5f, player2Spawn.position.z),
        Quaternion.identity
    );

    // aplicar material
    var p2Renderer = p2.GetComponent<MeshRenderer>();
    p2Renderer.material = GameManager.Instance.player2.bolinhaEscolhida.material;

    p2.GetComponent<BolinhaController>().Setup(false);
}
}