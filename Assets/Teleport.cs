using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject destination;
    public GameObject cameraDestination;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 teleportEnd = destination.transform.position;
            // Es horrible todo esto pero es la única forma en la que no se rompe el player movement.
            teleportEnd.z = 0;
            collision.gameObject.transform.position = teleportEnd;
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = cameraDestination.transform.position;
            collision.gameObject.GetComponent<PlayerMovementGrid>().ResetZAxis();
        }
    }
}
