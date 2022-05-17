using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour {
    private Vector2 spawnPosition;
    private float spawnTimer;
    private float totalFood;
    [SerializeField] private float maxFood;
    [SerializeField] float spawnDelay;
    [SerializeField] private GameObject food;
    void Update() {
        if (spawnTimer >= spawnDelay && totalFood <= maxFood) {
            spawnPosition.x = Random.Range(-50, 50);
            spawnPosition.y = Random.Range(-50, 50);
            Instantiate(food, spawnPosition, quaternion.identity);
            totalFood++;
            spawnTimer = 0;
        }
        spawnTimer += Time.deltaTime;
    }
}
