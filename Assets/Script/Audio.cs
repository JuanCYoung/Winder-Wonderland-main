using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance;

    private void Awake()
    {
        instance = this;
    }
    /* public List<AudioClip> sfxLibrary;*/
    public AudioClip sfx_landing, sfx_jump, sfx_run, sfx_shoot, sfx_hit, sfx_treefaling, sfx_item;
    public AudioClip music_ost;

    public GameObject soundObject;

    public void PlaySFX(string sfxName)
    {
        switch (sfxName)
        {
            case "landing":
                Sound(sfx_landing);
                break;
            case "jump":
                Sound(sfx_jump);
                break;
            case "run":
                Sound(sfx_run);
                break;
            case "shoot":
                Sound(sfx_shoot);
                break;
            case "hit":
                Sound(sfx_hit);
                break;
            case "treefaling":
                Sound(sfx_treefaling);
                break;
            case "item":
                Sound(sfx_item);
                break;
            default:
                break;
        }
    }

    void Sound (AudioClip clip) 
    {
        GameObject newObject = Instantiate(soundObject, transform);
        newObject.GetComponent<AudioSource>().clip = clip;
        newObject.GetComponent<AudioSource>().Play();
    }

    public void PlayMusic(string musicName)
    {
        switch (musicName)
        {
            case "ost":
                music(music_ost);
                break;
            default:
                break;
        }
    }

    void music(AudioClip clip)
    {
        GameObject newObject = Instantiate(soundObject, transform);
        newObject.GetComponent<AudioSource>().clip = clip;

        newObject.GetComponent<AudioSource>().Play();
    }

}
