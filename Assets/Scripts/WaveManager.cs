using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] waypoints;
    public float timeBetweenWaves = 8f;

    private int currentWaveIndex = 0;

    void Start()
    {
        StartCoroutine(RunWaves());
    }

    IEnumerator RunWaves()
    {
        while (currentWaveIndex < waves.Length)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            Wave wave = waves[currentWaveIndex];
            if (GameManager.Instance != null)
                GameManager.Instance.currentWave = currentWaveIndex + 1;

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemyPrefab);
                yield return new WaitForSeconds(wave.spawnDelay);
            }

            // Wait until all enemies from this wave are gone
            yield return new WaitUntil(() => FindObjectsOfType<Enemy>().Length == 0);

            currentWaveIndex++;
        }

        Debug.Log("All waves completed!");
    }

    void SpawnEnemy(GameObject prefab)
    {
        if (prefab == null || waypoints == null || waypoints.Length == 0) return;

        GameObject enemy = Instantiate(prefab, waypoints[0].position, Quaternion.identity);
        EnemyMovement movement = enemy.GetComponent<EnemyMovement>();
        if (movement != null)
            movement.waypoints = waypoints;
    }
}
