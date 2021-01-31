using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPerTiles : MonoBehaviour
{

    public float movementDistance;
    private Vector2 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            newPosition = new Vector2(0,transform.position.y + movementDistance);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            newPosition = new Vector2(0, transform.position.y + movementDistance * -1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            newPosition = new Vector2(transform.position.x + movementDistance, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            newPosition = new Vector2(transform.position.x + movementDistance * -1, 0);
        }

        transform.position = newPosition;
    }
}
