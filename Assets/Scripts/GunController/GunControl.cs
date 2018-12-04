using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
	public GameObject bulletPrefab;
	public Transform nozzle;
	private Vector3 bulletPos;

	private void Start(){
		bulletPos = nozzle.position;
	}

	private void Update(){
		bulletPos = nozzle.position;
		if (Input.GetKey (KeyCode.Space))
			Shoot ();
	}

	private void Shoot(){
		GameObject go = Instantiate (bulletPrefab, bulletPos, Quaternion.identity);
		go.transform.SetParent (transform);
		go.GetComponent<Rigidbody> ().velocity = Vector3.forward * 50f;
		Destroy (go, 2f);
	}
}
