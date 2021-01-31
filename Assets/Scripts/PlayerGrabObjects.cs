using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabObjects : MonoBehaviour
{

    public Transform grabDetect;
    public Transform objectHolder;
    public float rayDist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.up * transform.localScale, rayDist);

        if (grabCheck.collider != null)
        {

            if (Input.GetKey(KeyCode.J))
            {
                grabCheck.collider.gameObject.transform.parent = objectHolder;
                grabCheck.collider.gameObject.transform.position = objectHolder.position;
                grabCheck.collider.gameObject.transform.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
            }

        }
    }
}
