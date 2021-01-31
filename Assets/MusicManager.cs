using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SoundManager.Initialize();
        SoundManager.PlayMusic(SoundManager.Music.Theme);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
