	using UnityEngine;
	using UnityEngine.Events;
	using System.Collections;

	public class BgScroller : MonoBehaviour {

		// Use this for initialization
		public float scrollSpeed;
	private UnityAction gameOverListener;

		void Awake(){
			gameOverListener = new UnityAction (onGameOver);
		}

		void OnEnable(){
		EventManager.StartListening ("gameOver", gameOverListener);
		}

		void OnDisable(){
		EventManager.StopListening ("gameOver", gameOverListener);
		}
		void Start () {
		//	GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, scrollSpeed);
		}

			// Update is called once per frames
		void Update () {
	
		Vector3 newPos = new Vector3 (0f, transform.position.y + scrollSpeed * Time.deltaTime, 0f);
		transform.position = newPos;
		if (transform.position.y <= -20f) {
			Destroy (gameObject);
			}			
		}

	void onGameOver(){

		Debug.Log ("Stop Scrolling");
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
		scrollSpeed = 0f;
	}
	}
