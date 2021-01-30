using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFogOfWar : MonoBehaviour
{

    private Color darkTileColor = new Color(0f, 0f, 0f, 1f);

    private Tile[] childrenTiles;
    public List<GameObject> tiles;

    // Start is called before the first frame update
    void Start()
    {
        childrenTiles = GetComponentsInChildren<Tile>();

        foreach(Tile tile in childrenTiles)
        {
            tiles.Add(tile.gameObject);
        }

        // Set to dark
        foreach(GameObject tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().color = darkTileColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
