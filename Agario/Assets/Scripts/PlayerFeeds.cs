using System;
using TMPro;
using UnityEngine;

public class PlayerFeeds : MonoBehaviour {
	public TextMeshProUGUI text;
	private int score;

	private void Start() {
		text.text = "0";
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Food")) {
			UpdateSize();
			Destroy(collision.gameObject);
			Debug.Log("Nom");
			score++;
			text.text = $"{score}";
		}
	}
	private void UpdateSize() {
		if (score <= 400) {
			transform.localScale *= 1.01f;
			GetComponentInChildren<Camera>().orthographicSize *= 1.005f;			
		}
	}
}
