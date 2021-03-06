using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attributes of a Card, will probably become abstract
public abstract class Card : MonoBehaviour {
	public Sprite sprite;
	public bool dispenseWhenUsed;

	// xDirection: The direction the player is facing on the x axis
	// yDirection: The direction the player is facing on the y axis
	public abstract void Activate (int xDirection, int yDirection, Vector3 playerPos, GameObject player);
}