using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fight_W_L_P : MonoBehaviour
{
    public GameObject Pause, FT, Au, Fadein;
    public AudioSource au; public AudioClip Click, Song, PSong;
    void Start()
    {
        if (DataCrosser.FF)
        {
            FT.SetActive(true); DataCrosser.FF = false;
        }
        Au = GameObject.Find("SFX Player");
        au = Au.GetComponent<AudioSource>();
        au.volume = DataCrosser.sfx;
    }
    public void pause()
    {
        au.PlayOneShot(Click);
        Pause.SetActive(true);
    }
    public void resume()
    {
        au.PlayOneShot(Click);
        Pause.SetActive(false);
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
    public void OK()
    {
        au.PlayOneShot(Click);
        FT.SetActive(false);
    }

    private IEnumerator FadeIn(int i)
    {
        Fadein.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(i);
    }
    private IEnumerator VFadeIn(int i)
    {
        Fadein.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(i);
    }
}
