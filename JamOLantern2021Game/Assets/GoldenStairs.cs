using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoldenStairs : MonoBehaviour {
	[SerializeField]
	private string nextSceneToLoad;


	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.CompareTag ("Player")) {
			FindObjectOfType<AudioManager> ().Play ("climbStairs");
			FindObjectOfType<AudioManager> ().Stop (FindObjectOfType<MusicPlayer> ().songName);
			SceneManager.LoadScene (nextSceneToLoad);
		}

	}
}
