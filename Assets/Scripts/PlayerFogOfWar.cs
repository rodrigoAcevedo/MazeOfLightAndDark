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
    private int innerRadius;
    [SerializeField]
    private int outerRadius;
    [SerializeField]
    private Color darkCellColor;
    [SerializeField]
    private Color grayCellColor;
    [SerializeField]
    private Color lightCellColor;

    private void Awake()
    {
        frames = 0;

        darkCellColor = new Color(1f, 1f, 1f, 1f);
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

            ApplyDarkness();

            hit = TileCircleCast(transform.position, outerRadius);

            if (hit.Count > 0)
            {
                foreach (Vector3Int tile in hit)
                {
                    {
                        fogOfWar.SetColor(tile, grayCellColor);
                    }
                }
            }

            hit = TileCircleCast(transform.position, innerRadius);
            if (hit.Count > 0)
            {
                foreach (Vector3Int tile in hit)
                {
                    fogOfWar.SetColor(tile, lightCellColor);
                }
            }
        }
    }

    private void ApplyDarkness()
    {
        foreach (var tile in fogOfWar.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(tile.x, tile.y, tile.z);
            fogOfWar.SetColor(localPlace, darkCellColor);
        }
    }

    List<Vector3Int> TileCircleCast(Vector3 pos, int radius)
    {
        //int radius = 2;
        //pos.x = Mathf.CeilToInt(pos.x);
        //pos.y = Mathf.CeilToInt(pos.y);

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
