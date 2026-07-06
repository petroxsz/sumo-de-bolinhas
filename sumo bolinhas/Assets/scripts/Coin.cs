using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Buffs")]
    public float forceBonus = 1.2f;
    public float speedPenalty = 0.9f;
    public float weightBonus = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        BolinhaController player = other.GetComponent<BolinhaController>();

        if (player == null)
            return;

        player.ApplyCoin(forceBonus, speedPenalty, weightBonus);

        CoinSpawner spawner = FindFirstObjectByType<CoinSpawner>();

        if (spawner != null)
            spawner.CoinCollected();

        Destroy(gameObject);
    }
}