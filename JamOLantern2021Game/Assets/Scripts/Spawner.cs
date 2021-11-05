
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.CoreModule;

public class Spawner : MonoBehaviour {
	private Transform target;
	public GameObject prefab;
	public float spawnTime;
	private float spawnTimeCounter;
	public int max;
	public int numAlive = 0;
	public float xRadius = 15f;
	public float yRadius = 15f;
	public float minDistanceFromPlayer = 10f;
	private EnemyHealth healthScript;
	public Color GizmosColor = new Color (0.5f, 0.5f, 0.5f, 0.2f);
	Vector3 spawnRadius;
	Vector3 offset;
	Vector2 pos;
	// Start is called before the first frame update
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		healthScript = prefab.GetComponent<EnemyHealth> ();
		spawnRadius.Set (xRadius, yRadius, 0f);
	}
	void Spawn () {


		pos.Set (Random.Range (transform.position.x - xRadius, transform.position.x + xRadius), Random.Range (transform.position.y - yRadius, transform.position.y + yRadius));
		if (Vector2.Distance (pos, target.position) > minDistanceFromPlayer) {
			GameObject Spider = Instantiate (prefab, pos, Quaternion.identity);
			numAlive++;

		} else {
			//causes stack overflow?
			//  Spawn();
		}



	}
	void OnDrawGizmos () {
		spawnRadius.Set (xRadius, yRadius, 0f);
		Gizmos.color = GizmosColor;
		Gizmos.DrawWireCube (transform.position, spawnRadius * 2);
	}
	// Update is called once per frame
	void Update () {



		if (spawnTimeCounter > 0) {
			spawnTimeCounter -= Time.deltaTime;
		}
		if (spawnTimeCounter <= 0) {

			if (numAlive < max) {
				Spawn ();
			} else {
				SceneManager.LoadScene ("SecondFloor");
			}
			spawnTimeCounter = spawnTime;
		}
	}
}