using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class BG_Worker : MonoBehaviour {
	
	[SerializeField]private GameObject player, walls;
	[SerializeField]private Text scoreHodler;

	int level = 1;
	int maxLevel = 10;

	private int score = 0;
	private bool wallStatus = true;

	private void Start(){
		scoreHodler.text = "0";
	}
	
	private void OnEnable(){
		EventManager.OnEventStarted += HandleEvent;
	}
	private void OnDisable(){
		EventManager.OnEventStarted -= HandleEvent;
	}

	private void Update(){
		HideWalls ();
	}

	private void HandleEvent(EventType type, System.Object data){
		if (type == EventType.DAMAGE_BOX) {
			Destroy (data as GameObject);
			IncreaseScore (1);
		}
	}

	private void IncreaseScore(int newScore){
		score += newScore;
		scoreHodler.text = score.ToString ();
		SetDifficultyLevel ();
	}

	private void SetDifficultyLevel(){
		switch (score) {
		case 30:
			IncreaseSpeed (2);
			break;
		case 50:
			IncreaseSpeed (4);
			wallStatus = false;
			break;
		case 75:
			IncreaseSpeed (10);
			break;
		}
	}

	private void IncreaseSpeed(float newSpeed){
		player.GetComponent<PlayerMotor> ().speed += newSpeed;
	}

	private void HideWalls(){
		foreach (var a in GameObject.FindGameObjectsWithTag("Walls"))
			a.SetActive (wallStatus);
	}
}
