using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 28;

    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        if (health <= 0) {
            Die();
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        anim.SetTrigger("Hurt");
    }

    public void Die() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("InstantDeath")) {
            print("You died instantly.");
            Die();
        }
    }

    public int GetHealth() {
        return health;
    }
}