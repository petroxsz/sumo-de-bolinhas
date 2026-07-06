using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject coinPrefab;

    [Header("Área de Spawn")]
    public Vector3 center;
    public Vector3 size = new Vector3(8f, 0f, 8f);

    [Header("Altura da moeda")]
    public float spawnHeight = 0.15f;

    [Header("Tempo")]
    public float spawnInterval = 5f;

    private GameObject currentCoin;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), 1f, spawnInterval);
    }

    void SpawnCoin()
    {
        if (currentCoin != null)
            return;

        Vector3 randomPos = center + new Vector3(
            Random.Range(-size.x / 2, size.x / 2),
            spawnHeight,
            Random.Range(-size.z / 2, size.z / 2)
        );

        currentCoin = Instantiate(coinPrefab, randomPos, Quaternion.identity);
    }

    public void CoinCollected()
    {
        currentCoin = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, size);
    }
}