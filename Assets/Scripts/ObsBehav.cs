using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsBehav : MonoBehaviour {
	private Transform[] obs;

	private void Start(){
		obs = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			obs [i] = transform.GetChild (i);
		}
		EnableObs ();
	}

	private void EnableObs(){
		for (int i = 0; i < transform.childCount; i++) {
			int ran = Random.Range (1, 5000);
			if (ran % 2 == 0) {
				obs [i].gameObject.SetActive (true);
			}
		}
	}
}
