using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject fruitPrefab;

    public float spawnRate = 2f; // кожні 2 секунди
    public float gameDuration = 120f; // 2 хвилини

    public float xRange = 15f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        float timer = 0f;

        while (timer < gameDuration)
        {
            SpawnFruit();

            yield return new WaitForSeconds(spawnRate);

            timer += spawnRate;
        }

        Debug.Log("Спавн завершено!");
    }

    void SpawnFruit()
    {
        if (fruitPrefab != null)
        {
            float randomX = Random.Range(-xRange, xRange);

            Vector3 spawnPos = new Vector3(randomX, 10f, 0f);

            Instantiate(fruitPrefab, spawnPos, Quaternion.identity);
        }
    }
}