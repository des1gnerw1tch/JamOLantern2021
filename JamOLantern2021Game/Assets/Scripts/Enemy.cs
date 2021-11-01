using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 4f;
    public float range = 2f;
    private Rigidbody2D body;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag("Player");
        double minDist = double.MaxValue;

        foreach (GameObject target in possibleTargets)
        {
            if (Vector3.Distance(transform.position, target.transform.position) <= minDist)
            {
                minDist = Vector3.Distance(transform.position, target.transform.position);
                player = target.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        body.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}