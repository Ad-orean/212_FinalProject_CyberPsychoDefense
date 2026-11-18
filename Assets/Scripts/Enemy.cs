using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 10f;
    public float health;
    public int reward = 10;

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
        if (GameManager.Instance != null)
            GameManager.Instance.AddMoney(reward);
        Destroy(gameObject);
    }
}