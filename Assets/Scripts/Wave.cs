using System;
using UnityEngine;

[Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public int count = 5;
    public float spawnDelay = 0.8f;
}
