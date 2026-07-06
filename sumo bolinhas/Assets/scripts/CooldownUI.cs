using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    public BolinhaController player1;
    public BolinhaController player2;

    public Slider p1Slider;
    public Slider p2Slider;

    private void Update()
    {
        if (player1 != null)
            p1Slider.value = player1.GetCooldownNormalized();

        if (player2 != null)
            p2Slider.value = player2.GetCooldownNormalized();
    }
}