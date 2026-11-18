using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 10f;
    public float health;
    public int reward = 10;

    private bool isDead = false;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        health -= damage;
        if (health <= 0f)
            Die();
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        if (GameManager.Instance != null)
            GameManager.Instance.AddMoney(reward);

        Destroy(gameObject);
    }
}