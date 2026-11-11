using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 10f;
    public float health;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}