using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour {

	// Use this for initialization

	public GameObject[] obstaclePrefabs;
	public GameObject currentObstacle;
	Vector3 spawnPosition = new Vector3(0,35 ,0);
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentObstacle.transform.position.y <= 17) {
			GenerateObstacle ();
		}
	}

	public void GenerateObstacle(){
		Debug.Log ("Generate obstacle");
		int obs = Random.Range (1, obstaclePrefabs.Length);
		GameObject newObstacle = Instantiate(obstaclePrefabs[obs], spawnPosition , Quaternion.identity);
		currentObstacle = newObstacle;
	}
}
