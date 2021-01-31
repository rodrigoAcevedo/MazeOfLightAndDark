using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int movementSpeed;
    private Rigidbody2D RB2D;
    private Vector2 movement;
        
    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        movement = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.S))
        {
            movement.y = movementSpeed * -1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement.y = movementSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement.x = movementSpeed * -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = movementSpeed;
        }
    }

    private void FixedUpdate()
    {
        
        RB2D.velocity = movement;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
