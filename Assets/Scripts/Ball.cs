using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Keepiing Ball relative to Paddle before game start
			this.transform.position = paddle.transform.position + paddleToBallVector;

			//Mouse press which launches Ball and starts game. Changes hasStarted to True
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				print ("Mouse Clicked, Launch Ball");
				this.rigidbody2D.velocity = new Vector2 (Random.Range(-7f, 7f), 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f),Random.Range (0f, 0.2f));
		print (tweak);
		if (hasStarted == true) {
			audio.Play ();
			this.rigidbody2D.velocity += tweak;
		}
	}
}
