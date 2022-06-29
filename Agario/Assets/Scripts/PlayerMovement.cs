using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] private float speed;
	private Vector2 targetPosition;
	
	void Update () {
		targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
	}
}
