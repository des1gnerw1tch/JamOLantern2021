using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// assigns inputs to each individual player as directed from start scene
public class FirstFloorManager : MonoBehaviour {
	[Header ("Player 1 Controls")]
	[SerializeField] private KeyCode move_left;
	[SerializeField] private KeyCode move_right;
	[SerializeField] private KeyCode move_up;
	[SerializeField] private KeyCode move_down;

	[SerializeField] private KeyCode keyToUse; // Key pressed to use card
	[SerializeField] private KeyCode keyToSkip; // Key pressed to skip card

	[Header ("Player 2 Controls")]
	[SerializeField] private KeyCode move_left2;
	[SerializeField] private KeyCode move_right2;
	[SerializeField] private KeyCode move_up2;
	[SerializeField] private KeyCode move_down2;

	[SerializeField] private KeyCode keyToUse2; // Key pressed to use card
	[SerializeField] private KeyCode keyToSkip2; // Key pressed to skip card
												 // Start is called before the first frame update

	[SerializeField] private GameObject [] players; // Players from scene
	[SerializeField] private static Vector3 playersToActivate; // The players to activate 

}
