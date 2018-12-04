using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
	private void OnTriggerEnter(Collider col){
		if (col.tag == "Obs") {
			EventManager.RaiseEvent (EventType.DAMAGE_BOX, col.gameObject);
			Destroy (gameObject);
		}
	}

	private void Update(){
		if (Time.time > 2000f) {
			Destroy (gameObject);
		}
	}
}
