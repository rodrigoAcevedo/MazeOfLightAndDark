using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ElFinal : MonoBehaviour
{
    public GameObject player;
    public Tilemap level;
    public Camera mainCamera;
    public GameObject crown;
    public Transform crownSlot;
    public GameObject diamond;
    public Transform diamondSlot;
    public GameObject sword;
    public Transform swordSlot;
    public GameObject chest;
    public Transform chestSlot;

    public TextAsset winText;



    private PlayerMovementGrid playerMovement;
    private PlayerFogOfWar fogOfWar;

    private bool endingStarted = false;
    private float transparency = 0f;

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovementGrid>();
        fogOfWar = player.GetComponent<PlayerFogOfWar>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(endingStarted)
        {
            if(level.color.a >= 0f)
            {
                Color newColor = new Color(1f, 1f, 1f, level.color.a - (1f * Time.deltaTime));
                level.color = newColor;
            }

            Vector2 cameraPosition = mainCamera.transform.position;
            Vector2 playerPosition = player.transform.position;
            if(cameraPosition != playerPosition)
            {
                cameraPosition = Vector2.MoveTowards(cameraPosition, playerPosition, 1f * Time.deltaTime);
                mainCamera.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, mainCamera.transform.position.z);
            }

            if(crown.transform != crownSlot.transform)
            {
                crown.transform.position = Vector3.MoveTowards(crown.transform.position, crownSlot.transform.position, 2f * Time.deltaTime);
            }

            if (chest.transform != chestSlot.transform)
            {
                chest.transform.position = Vector3.MoveTowards(chest.transform.position, chestSlot.transform.position, 1f * Time.deltaTime);
            }

            if (sword.transform != swordSlot.transform)
            {
                sword.transform.position = Vector3.MoveTowards(sword.transform.position, swordSlot.transform.position, 1f * Time.deltaTime);
            }

            if (diamond.transform != diamondSlot.transform)
            {
                diamond.transform.position = Vector3.MoveTowards(diamond.transform.position, diamondSlot.transform.position, 1f * Time.deltaTime);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            endingStarted = true;
            SoundManager.PlayMusic(SoundManager.Music.Victory, false);
        }
    }
}
