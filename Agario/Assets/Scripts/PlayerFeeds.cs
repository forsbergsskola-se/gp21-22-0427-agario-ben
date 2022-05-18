using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeeds : MonoBehaviour {

	private Rigidbody2D self;
	private void Start() {
		self = GetComponent<Rigidbody2D>();
	}
	private void Update() {
		
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Food")) {
			UpdateSize();
			Destroy(collision.gameObject);
			Debug.Log("Nom");
		}
	}
	private void UpdateSize() {
		self.transform.localScale *= 1.01f;
		GetComponentInChildren<Camera>().orthographicSize *= 1.005f;
	}
}
