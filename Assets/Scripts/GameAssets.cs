using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    public SoundAudioClip[] soundAudioClips;
    public MusicClip[] musicClips;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
        [Range(0,1)]
        public float volume;
    }

    [System.Serializable]
    public class MusicClip
    {
        public SoundManager.Music music;
        public AudioClip audioClip;
        [Range(0,1)]
        public float volume;
    }
}
