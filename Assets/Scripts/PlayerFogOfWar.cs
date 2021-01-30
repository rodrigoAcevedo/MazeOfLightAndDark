using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFogOfWar : MonoBehaviour
{
    private RaycastHit2D[] hit;
    private int frames;
    private int scenarioLayerMask = 8;

    [SerializeField]
    private float innerRadius;

    private void Awake()
    {
        frames = 0;
    }


    void FixedUpdate()
    {
        frames++;
        if (frames == 4)
        {
            frames = 0;

            hit = Physics2D.CircleCastAll(transform.position, 2f, new Vector2(0, 0), 3f);

            foreach (var tile in hit)
            {
                Vector3 dis = transform.position - tile.collider.transform.position;
                if (dis.x > innerRadius || dis.x < -innerRadius || dis.y > innerRadius || dis.y < -innerRadius)
                {
                    tile.collider.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f, 1.0f);
                }
                else
                {
                    tile.collider.transform.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1.0f);
                }
            }
        }
    }
}
