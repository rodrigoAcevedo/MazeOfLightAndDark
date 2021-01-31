using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler_Setup : MonoBehaviour
{
    private void Awake()
    {
        SoundManager.Initialize();
        SoundManager.PlayMusic(SoundManager.Music.InGame);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
