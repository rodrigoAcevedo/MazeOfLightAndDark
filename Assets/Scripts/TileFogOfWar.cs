using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFogOfWar : MonoBehaviour
{
    [SerializeField]
    private Color darkTileColor;

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

        DarknenLevelStart();
    }

    void DarknenLevelStart()
    {
        // Set to dark
        foreach (GameObject tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().color = darkTileColor;
        }
    }
}
