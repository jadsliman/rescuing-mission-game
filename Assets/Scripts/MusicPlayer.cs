using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;
    public AudioSource musicSource;

    private void Start()
    {
        musicSource.volume = DataCrosser.music;
    }
    void Awake()
    {
        if(instance == null)
        {
            instance = this; DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMusic(AudioClip newTrack)
    {
        musicSource.clip = newTrack;
        StartCoroutine(music());
    }
    IEnumerator music()
    {
        yield return new WaitForSeconds(0.5f); musicSource.Play();
    }
    public void ChangeVolume()
    {
        musicSource.volume = DataCrosser.music;
    }
}
