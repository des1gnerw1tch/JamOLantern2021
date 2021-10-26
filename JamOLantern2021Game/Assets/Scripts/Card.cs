using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attributes of a Card, will probably become abstract
public abstract class Card : MonoBehaviour {
	[SerializeField] private int level; // level of this card
	[SerializeField] private GameObject CanvasPrefab; // 
}
