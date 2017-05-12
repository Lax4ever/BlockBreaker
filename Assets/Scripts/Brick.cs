using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {


	public int maxHits;

	private LevelManager levelManager;
	private int timesHit;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
	}

	void OnCollisionEnter2D (Collision2D collision){		
		//++ = timesHit = timesHit + 1
		timesHit++;

		aif (timesHit >= maxHits){
			Destroy (gameObject);
		}
	}

	void SimulateWin () {
		levelManager.LoadNextLevel ();
	}
}