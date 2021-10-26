using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform toMove;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown("w")) {
            this.toMove.Translate(Vector3.up * Time.deltaTime * this.speed);
        Debug.Log("Moved Forward");
      }
    }
}
