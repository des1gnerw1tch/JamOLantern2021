using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Deals with playing music in game
public class MusicPlayer : MonoBehaviour {
	public string songName; // name in AudioManager

	// Start is called before the first frame update
	void Start () {
		FindObjectOfType<AudioManager> ().Play (this.songName); // plays our song for us
	}
}
