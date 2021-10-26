using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float horizontalMovement;
    [SerializeField] private float verticalMovement;
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
        // - 1 = left, 1 = right
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        // -1 = down, 1 = up
        verticalMovement = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // diagonal movement
        if (horizontalMovement != 0 && verticalMovement != 0)
        {
            horizontalMovement += speedDampener;
            verticalMovement += speedDampener;
        }

        body.velocity = new Vector2(horizontalMovement * sprintSpeed,
            verticalMovement * sprintSpeed);
    }
}