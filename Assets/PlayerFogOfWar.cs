using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFogOfWar : MonoBehaviour
{
    RaycastHit2D[] hit;
    int frames;

    private void Awake()
    {
        frames = 0;
    }

    private void FixedUpdate()
    {
        frames++;

        if (frames == 4)
        {
            frames = 0;

            // Diferenciar y hacerlo solo con los que son tiles
            hit = Physics2D.CircleCastAll(transform.position, 2f, new Vector2(0f, 0f), 3f);

            foreach(var tile in hit)
            {
                Vector3 dis = transform.position - tile.collider.transform.position;
                if (dis.x > 1 || dis.x < -1 || dis.y > 1 || dis.y < -1)
                {
                    tile.collider.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
                }
                else
                {
                    tile.collider.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

                }
            }
        }
    }
}
