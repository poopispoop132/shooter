using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] 
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject FastPrefab;

    [Header("Spawn Timing")]
    public float spawnInterval = 1.0f;
    public float fastSpawnInterval = 2.5f;

    [Header("Spawn Distance")]
    [SerializeField]
    private float spawnDistance = 10f;

    [Header("Optional Target (Player)")]
    [SerializeField]
    private Transform target;

    void Start()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player")?.transform;

        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnFastEnemies());
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "GameScene")
            return;

        // (You don’t actually need anything here right now)
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (SceneManager.GetActiveScene().name != "GameScene")
                continue;

            if (swarmerPrefab == null)
            {
                Debug.LogError("Spawner lost prefab reference!");
                yield break;
            }

            Vector2 dir = Random.insideUnitCircle.normalized;
            Vector3 spawnPos = transform.position + (Vector3)(dir * spawnDistance);

            Instantiate(swarmerPrefab, spawnPos, Quaternion.identity);
        }
    }

    private IEnumerator SpawnFastEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(fastSpawnInterval);

            if (SceneManager.GetActiveScene().name != "GameScene")
                continue;

            if (FastPrefab == null)
            {
                Debug.LogError("Spawner lost FastPrefab reference!");
                yield break;
            }

            Vector2 dir = Random.insideUnitCircle.normalized;
            Vector3 spawnPos = transform.position + (Vector3)(dir * spawnDistance);

            Instantiate(FastPrefab, spawnPos, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 centerPoint = target != null ? target.position : transform.position;
        Gizmos.DrawWireSphere(centerPoint, spawnDistance);
    }
}