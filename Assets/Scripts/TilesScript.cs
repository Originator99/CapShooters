using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesScript : MonoBehaviour {
	public GameObject[] tilesPrefab;

	private Transform player;
	private float spawnZ = 0f;
	private float tileLen = 12;
	private int maxTilesOnScreen = 5;
	private int minRangeH = 10, maxRangeH = 60;
	private List<GameObject> tiles;
	private Dictionary<GameObject, int> obstacles;

	private void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		tiles = new List<GameObject> ();
		obstacles = new Dictionary<GameObject, int> ();
		for (int i = 0; i < 7; i++) {
			SpawnTile ();
		}
	}

	private void Update(){
		if (player.position.z > (spawnZ - maxTilesOnScreen * tileLen)) {
			SpawnTile (1);
			DestroyTile ();
		}
	}

	private void SpawnTile(int index = 0){
		GameObject go  = Instantiate(tilesPrefab[index]);
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLen;
		tiles.Add (go);
		if (index > 0) {
			int r = Random.Range (minRangeH, maxRangeH);
			obstacles.Add (go, r);
		}
	}

	private void DestroyTile(GameObject obj = null){
		Destroy (tiles [0]);
		tiles.RemoveAt (0);
	}
}
