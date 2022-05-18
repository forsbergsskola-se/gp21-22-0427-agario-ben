using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    [SerializeField] private GameObject player;

    private Vector3 offset;

    private void Start() {
        offset = transform.position - player.transform.position;
    }
    void Update() {
        transform.position = player.transform.position + offset;
    }
}
