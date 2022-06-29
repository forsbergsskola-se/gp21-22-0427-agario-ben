using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour {
    private Vector2 spawnPosition;
    private float spawnTimer;
    public int totalFood;
    [SerializeField] private float maxFood;
    [SerializeField] private float spawnDelay;
    [SerializeField] private GameObject food;
    void Update() {
        if (spawnTimer >= spawnDelay && totalFood <= maxFood) {
            SpawnFood();
            totalFood++;
            spawnTimer = 0;
        }
        spawnTimer += Time.deltaTime;
    }
    public void SpawnFood() {
        spawnPosition.x = Random.Range(-50, 50);
        spawnPosition.y = Random.Range(-50, 50);
        var child = Instantiate(food, spawnPosition, quaternion.identity);
        child.transform.parent = transform; 
    }
}
