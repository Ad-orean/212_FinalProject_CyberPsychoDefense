using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float reachDistance = 0.15f;
    public Transform[] waypoints;

    private int currentIndex = 0;

    void Start()
    {
        if (waypoints.Length > 0)
            transform.position = waypoints[0].position;
    }

    void Update()
    {
        if (currentIndex >= waypoints.Length) return;

        Transform target = waypoints[currentIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) <= reachDistance)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
                ReachEnd();
        }
    }

    void ReachEnd()
    {
        Destroy(gameObject);
    }
}