using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeeds : MonoBehaviour {
	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Food")) {
			UpdateSize();
			Destroy(collision.gameObject);
			Debug.Log("Nom");
		}
	}
	private void UpdateSize() {
		if (transform.localScale.sqrMagnitude <= 200) {
			transform.localScale *= 1.01f;
			Debug.Log(transform.localScale.sqrMagnitude);
			GetComponentInChildren<Camera>().orthographicSize *= 1.005f;			
		}
	}
}
