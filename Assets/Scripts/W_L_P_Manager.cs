using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class W_L_P_Manager : MonoBehaviour
{
    Wizard w;
    public GameObject Pause, FT, Au;
    public AudioSource au; public AudioClip Click, Song, PSong;
    void Start()
    {
        Au = GameObject.Find("SFX Player");
        au = Au.GetComponent<AudioSource>();
        w = FindObjectOfType<Wizard>();
        au.volume = DataCrosser.sfx;
    }
    public void pause()
    {
        au.PlayOneShot(Click);
        Pause.SetActive(true);
        w.Paused = true;
    }
    public void resume()
    {
        au.PlayOneShot(Click);
        Pause.SetActive(false);
        w.Paused = false;
    }
    public void restart()
    {
        au.PlayOneShot(Click);
        if (DataCrosser.isReturningFromBattle) { DataCrosser.isReturningFromBattle = false; MusicPlayer.instance.ChangeMusic(Song); }
        StartCoroutine(FadeIn(DataCrosser.Levelindex + 1));
    }
    public void home()
    {
        au.PlayOneShot(Click);
        if (DataCrosser.isReturningFromBattle) { DataCrosser.isReturningFromBattle = false; MusicPlayer.instance.ChangeMusic(Song); }
        StartCoroutine(FadeIn(96));
    }
    public void next()
    {
        au.PlayOneShot(Click);
        if (DataCrosser.EnvCompleted) StartCoroutine(VFadeIn(99));
        else if (DataCrosser.RC)
        {
            MusicPlayer.instance.ChangeMusic(PSong); StartCoroutine(FadeIn(97));
        }
        else { StartCoroutine(FadeIn(98)); MusicPlayer.instance.ChangeMusic(PSong); }
    }

    public void OK()
    {
        au.PlayOneShot(Click);
        FT.SetActive(false);
    }

    private IEnumerator FadeIn(int i)
    {
        w.fadein.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(i);
    }
    private IEnumerator VFadeIn(int i)
    {
        w.fadein.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(i);
    }
}
