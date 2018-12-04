using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {
	public float speed = 10f;

	private CharacterController controller;
	private Vector3 moveDirection;

	private float verticalVel = 0.0f;
	private float gravity = 12.0f;

	private void Start(){
		controller = GetComponent<CharacterController> ();
	}

	private void Update(){
		Movement ();
	}

	private void Movement(){
		moveDirection = Vector3.zero;
		moveDirection.x = Input.GetAxisRaw ("Horizontal") * speed;
		if (controller.isGrounded)
			verticalVel = -0.5f;
		else
			verticalVel -= gravity * Time.deltaTime;
		moveDirection.y = verticalVel;
		moveDirection.z = speed;

		controller.Move (moveDirection * Time.deltaTime);
	}

}
