using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {

	// Use this for initialization
	public float speed = 1.0f;
//	public GameObject explosion;
	public bool gameOver;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate(){
//		float move = Input.GetAxis ("Horizontal");

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			transform.Translate (-touchDeltaPosition.x * speed * Time.deltaTime, 0, 0);
//			Vector3 movement = new Vector3 (touchDeltaPosition.x * speed, 0f, 0f);
//			GetComponent<Rigidbody2D> ().velocity = movement * speed;

//			Vector3 newPosition = new Vector3(Input.GetTouch (0).position.x, transform.position.y, 0);
//			transform.position = newPosition;
		}
//		if (Input.GetTouch (0).phase == TouchPhase.Ended) {
//			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
//		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("Colll" + coll.gameObject.tag.ToString ());
		if (coll.gameObject.tag == "red" && !gameOver) {
			Debug.Log ("Collided with red");
			GetComponent<AudioSource> ().Play ();
//			Instantiate (explosion, transform.position, Quaternion.identity);
			Invoke ("ShowGameOver", 1.5f);	
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			gameOver = true;
		}
	}

	void ShowGameOver(){
			EventManager.TriggerEvent("gameOver");
			Destroy (gameObject);
		}
	


}
