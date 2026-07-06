using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BolinhaController player = other.GetComponent<BolinhaController>();

        if (player == null)
            return;

        MatchManager.Instance.PlayerDied(player);
    }
}