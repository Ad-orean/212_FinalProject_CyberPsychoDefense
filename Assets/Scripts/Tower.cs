using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3f;
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private float cooldown;

    void Update()
    {
        cooldown -= Time.deltaTime;

        Enemy target = GetTarget();
        if (target != null && cooldown <= 0f)
        {
            Shoot(target);
            cooldown = 1f / fireRate;
        }
    }

    Enemy GetTarget()
    {
        Enemy closest = null;
        float closestDist = Mathf.Infinity;

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist <= range && dist < closestDist)
            {
                closest = enemy;
                closestDist = dist;
            }
        }
        return closest;
    }

    void Shoot(Enemy target)
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile projectile = proj.GetComponent<Projectile>();
        if (projectile != null)
            projectile.SetTarget(target);
    }
}