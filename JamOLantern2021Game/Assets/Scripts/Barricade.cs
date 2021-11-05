using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour {
	[SerializeField] private float lifetime;


	void Start () {
		StartCoroutine ("Death");
	}

	IEnumerator Death () {
		yield return new WaitForSeconds (lifetime);
	}
}
