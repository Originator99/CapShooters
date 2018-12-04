using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {
	private Transform playerT;
	private Vector3 offset;

	private void Start(){
		playerT = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = transform.position - playerT.position;
	}

	private void LateUpdate(){
		transform.position = playerT.position + offset;
	}
}
