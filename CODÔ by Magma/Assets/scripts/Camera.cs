﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    // Use this for initialization
    private Transform target;
    public float speed;
    private Vector3 positionTarget;
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Follow();
	}

    void Follow() {
        positionTarget = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        Vector3 tempPosition = Vector3.Lerp(transform.position, positionTarget, speed);
        transform.position = tempPosition;
    }
}
