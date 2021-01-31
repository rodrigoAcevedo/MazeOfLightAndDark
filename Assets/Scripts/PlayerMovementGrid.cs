using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementGrid : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public Animator anim;



    private Vector3 currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (currentPoint != movePoint.position)
            {
                currentPoint = movePoint.position;
            }

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
            anim.SetBool("IsMoving", false);
        }
        else
        {
            anim.SetBool("IsMoving", true);
            SoundManager.PlaySound(SoundManager.Sound.PlayerMove);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Play bump sound
        movePoint.position = currentPoint;
        SoundManager.PlaySound(SoundManager.Sound.BumpWall);
        Debug.Log("hit a wall");
    }
}
