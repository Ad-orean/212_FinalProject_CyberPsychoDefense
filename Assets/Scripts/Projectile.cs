using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;
    public float damage = 5f;

    private Enemy target;
    private bool hasTarget;

    public void SetTarget(Enemy newTarget)
    {
        target = newTarget;
        hasTarget = true;
    }

    void Update()
    {
        if (!hasTarget || target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = (Vector2)target.transform.position - (Vector2)transform.position;
        float distance = direction.magnitude;

        if (distance <= 0.1f)
        {
            Hit();
            return;
        }

        transform.position += (Vector3)(direction.normalized * speed * Time.deltaTime);
    }

    void Hit()
    {
        if (target != null)
            target.TakeDamage(damage);
        Destroy(gameObject);
    }
}