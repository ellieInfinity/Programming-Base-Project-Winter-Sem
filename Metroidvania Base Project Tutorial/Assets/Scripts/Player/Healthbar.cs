using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour 
{
    [SerializeField] private Image mask;
    private Player player;
    private float maxHealth;

    private void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        maxHealth = player.GetHealth();
    }

    private void Update() {
        float fillAmount = (float)player.GetHealth() / (float)maxHealth;
        mask.fillAmount = fillAmount;

        if ((float)player.GetHealth() <= 5 && (float)player.GetHealth() > 2)
        {
            mask.color = Color.yellow;
        }
        if ((float)player.GetHealth() <= 2)
        {
            mask.color = Color.red;
        }
        if ((float)player.GetHealth() > 5)
        {
            mask.color = new Color(0f, 168f, 255f);
        }
    }
}