using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpawner : MonoBehaviour {
	
	private Vector2 spawnPosition;
	private bool playerSpawned;
	[SerializeField] private GameObject playerGroup;

	private void Update() {
		if (!playerSpawned) {
			SpawnPlayer();
		}
	}

	private void SpawnPlayer() {
		spawnPosition.x = Random.Range(-48, 48);
		spawnPosition.y = Random.Range(-48, 48);
		Instantiate(playerGroup, spawnPosition, Quaternion.identity);
		playerSpawned = true;
	}
}
