using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum  Sound
    {
        PlayerAttack,
        EnemyDestroy,
        BulletTouch,
        
    }
    public static void PlaySound(Sound sound,float volume = 0.3f)
    {
        GameObject soundGameObject = new GameObject("Sound");
        Destroy(soundGameObject,5f);
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound), volume);       
    }
    
    private static AudioClip GetAudioClip(Sound suond)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == suond)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound" + suond + "not found!");
        return null;
    }
}
