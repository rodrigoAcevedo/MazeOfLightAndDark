using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerFogOfWar : MonoBehaviour
{
    private List<Vector3Int> hit;
    private int frames;
    public Tilemap fogOfWar;

    [SerializeField]
    private float innerRadius;
    [SerializeField]
    private Color grayCellColor;
    [SerializeField]
    private Color lightCellColor;

    private void Awake()
    {
        frames = 0;

        grayCellColor = new Color(1f, 1f, 1f, 0.5f);
        lightCellColor = new Color(1f, 1f, 1f, 0f);

        foreach (Vector3Int tilePosition in fogOfWar.cellBounds.allPositionsWithin)
        {
            fogOfWar.RemoveTileFlags(tilePosition, TileFlags.LockColor);

        }

    }


    void FixedUpdate()
    {
        frames++;
        if (frames == 4)
        {
            frames = 0;

            hit = TileCircleCast(transform.position);

            if (hit.Count > 0)
            {
                foreach (Vector3Int tile in hit)
                {
                    Vector3 dis = transform.position - (Vector3)tile;
                    if (dis.x > innerRadius || dis.x < -innerRadius || dis.y > innerRadius || dis.y < -innerRadius)
                    {
                        fogOfWar.SetColor(tile, grayCellColor);
                    }
                    else
                    {
                        fogOfWar.SetColor(tile, lightCellColor);
                    }
                }
            }
        }
    }

    List<Vector3Int> TileCircleCast(Vector3 pos)
    {
        int radius = 2;
        pos.x = Mathf.CeilToInt(pos.x);
        pos.y = Mathf.CeilToInt(pos.y);

        int leftOffset = (int)Mathf.Floor(pos.x - radius);
        int rightOffset = (int)Mathf.Ceil(pos.x + radius);
        int topOffset = (int)Mathf.Floor(pos.y - radius);
        int bottomOffset =  (int)Mathf.Ceil(pos.y + radius);

        List<Vector3Int> tiles = new List<Vector3Int>();

        for (int x = leftOffset; x < rightOffset; x++)
        {
            for (int y = topOffset; y < bottomOffset; y++)
            {
                Vector3Int tilePosition = Vector3Int.FloorToInt(new Vector3(x, y, 0f));
                if (fogOfWar.GetTile(tilePosition) != null 
                    /*&& !(x == leftOffset && y == topOffset) // Esquina SUROESTE
                    && !(x == rightOffset && y == topOffset) // Esquina SURESTE
                    && !(x == leftOffset && y == bottomOffset) // Esquina NOROESTE
                    && !(x == rightOffset && y == bottomOffset)*/) // Esquina NORESTE
                {
                    tiles.Add(tilePosition);
                }
            }
        }
        return tiles;
    }
}
