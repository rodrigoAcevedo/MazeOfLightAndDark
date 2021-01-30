using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public int movement_speed;
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
            movement.y = movement_speed * -1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement.y = movement_speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement.x = movement_speed * -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = movement_speed;
        }
    }

    private void FixedUpdate()
    {
        
        RB2D.velocity = movement;

    }
}
