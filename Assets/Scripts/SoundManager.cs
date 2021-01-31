using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    public enum Sound
    {
        PlayerMove,
        BumpWall,
    }

    public enum Music
    {
        Theme,
        InGame,
    }

    private static Dictionary<Sound, float> soundTimerDictionary;
    private static GameObject sfxGameObject;
    private static AudioSource sfxAudioSource;
    private static GameObject musicGameObject;
    private static AudioSource musicAudioSource;
    private static AudioSource musicAudioSource2;


    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerMove] = 0f;
    }

    public static void PlaySound(Sound sound)
    {
        if(CanPlaySound(sound))
        {
            if(sfxGameObject == null)
            {
                sfxGameObject = new GameObject("Sound");
                sfxAudioSource = sfxGameObject.AddComponent<AudioSource>();

            }
            GameAssets.SoundAudioClip soundAudioClip = GetAudioClip(sound);
            sfxAudioSource.PlayOneShot(soundAudioClip.audioClip, soundAudioClip.volume);
        }
    }

    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;
            case Sound.PlayerMove:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playerMoveTimerMax = 0.5f;//GetAudioClip(sound).length;
                    if (lastTimePlayed + playerMoveTimerMax < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
        }
    }

    private static GameAssets.SoundAudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClips)
        {
            if(soundAudioClip.sound == sound)
            {
                return soundAudioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }


    public static void PlayMusic(Music music)
    {
        if (musicGameObject == null)
        {
            musicGameObject = new GameObject("Music");
            musicAudioSource = musicGameObject.AddComponent<AudioSource>();

        }
        GameAssets.MusicClip musicClip = GetMusicClip(music);
        musicAudioSource.clip = musicClip.audioClip;
        musicAudioSource.volume = musicClip.volume;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }

    private static GameAssets.MusicClip GetMusicClip(Music music)
    {
        foreach (GameAssets.MusicClip clip in GameAssets.i.musicClips)
        {
            return clip;
        }
        Debug.LogError("Music " + music + " not found!");
        return null;
    }
}
