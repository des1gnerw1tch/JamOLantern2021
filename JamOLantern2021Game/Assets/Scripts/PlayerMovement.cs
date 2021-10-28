using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    //[SerializeField] private float horizontalMovement;
    //[SerializeField] private float verticalMovement;

    [SerializeField] private float sprintSpeed = 10.0f;
    [SerializeField] private float speedDampener = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left) && Input.GetKey(up))
        {
            body.velocity = new Vector2(-sprintSpeed
                + speedDampener, sprintSpeed + speedDampener);
        }
        else if (Input.GetKey(left) && Input.GetKey(down))
        {
            body.velocity = new Vector2(-sprintSpeed
                + speedDampener, -sprintSpeed + speedDampener);
        }
        else if (Input.GetKey(right) && Input.GetKey(up))
        {
            body.velocity = new Vector2(sprintSpeed
                + speedDampener, sprintSpeed + speedDampener);
        }
        else if (Input.GetKey(right) && Input.GetKey(down))
        {
            body.velocity = new Vector2(sprintSpeed
                + speedDampener, -sprintSpeed + speedDampener);
        }
        else if (Input.GetKey(left))
        {
            body.velocity = new Vector2(-sprintSpeed, body.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            body.velocity = new Vector2(sprintSpeed, body.velocity.y);
        }
        else if (Input.GetKey(up))
        {
            body.velocity = new Vector2(body.velocity.x, sprintSpeed);
        }
        else if (Input.GetKey(down))
        {
            body.velocity = new Vector2(body.velocity.x, -sprintSpeed);
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }
    }
}