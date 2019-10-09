using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTimer = 3f;
    private float spawn = 1f;
    private Collider2D col;

    private void Awake()
    {
        col = this.GetComponent<Collider2D>();
        spawn = spawnTimer;
    }

    void Update()
    {
        spawn -= Time.deltaTime;

        if (spawn <= 0) {
            Vector3 pos = new Vector3(
            Random.Range(col.bounds.min.x, col.bounds.max.x),
            Random.Range(col.bounds.min.y, col.bounds.max.y),
            Random.Range(col.bounds.min.z, col.bounds.max.z)
            );
            GameObject ne = Instantiate(enemyPrefab, pos, Quaternion.identity);
            spawn = spawnTimer;
        }
    }
}
