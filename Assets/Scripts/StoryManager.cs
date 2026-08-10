using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StoryManager : MonoBehaviour
{
    public VideoPlayer vp; public VideoClip[] vc = new VideoClip[13];
    public AudioSource au; public AudioClip Click, PSong;
    void Start()
    {
        au.volume = DataCrosser.sfx;
        if (DataCrosser.EnvCompleted)
        {
            if (DataCrosser.WonLevels == 0) { vp.clip = vc[0]; vp.Play(); DataCrosser.EnvCompleted = false; }
            else if (DataCrosser.WonLevels == 18)
            {
                if (DataCrosser.IsClockwise) { vp.clip = vc[10]; vp.Play(); }
                else { vp.clip = vc[1]; vp.Play(); }
            }
            else if (DataCrosser.WonLevels == 33)
            {
                if (DataCrosser.IsClockwise) { vp.clip = vc[8]; vp.Play(); }
                else { vp.clip = vc[3]; vp.Play(); }
            }
            else if (DataCrosser.WonLevels == 48)
            {
                if (DataCrosser.IsClockwise) { vp.clip = vc[6]; vp.Play(); }
                else { vp.clip = vc[5]; vp.Play(); }
            }
            else if (DataCrosser.WonLevels == 63)
            {
                if (DataCrosser.IsClockwise) { vp.clip = vc[4]; vp.Play(); }
                else { vp.clip = vc[7]; vp.Play(); }
            }
            else if (DataCrosser.WonLevels == 78)
            {
                if (DataCrosser.IsClockwise) { vp.clip = vc[2]; vp.Play(); }
                else { vp.clip = vc[9]; vp.Play(); }
            }
            else if (DataCrosser.WonLevels == 93)
            {
                if (DataCrosser.IsClockwise) { vp.clip = vc[11]; vp.Play(); }
                else { vp.clip = vc[12]; vp.Play(); }
            }
        }
        else
        {
            if (DataCrosser.VideoNumber == 0) { vp.clip = vc[0]; vp.Play(); }
            else if (DataCrosser.VideoNumber == 1)
            {
                if (DataCrosser.IsClockwise) { vp.clip = vc[10]; vp.Play(); }
                else { vp.clip = vc[1]; vp.Play(); }
            }
            else if (DataCrosser.VideoNumber == 2)
            {
                if (DataCrosser.IsClockwise) { vp.clip = vc[8]; vp.Play(); }
                else { vp.clip = vc[3]; vp.Play(); }
            }
            else if (DataCrosser.VideoNumber == 3)
            {
                if (DataCrosser.IsClockwise) { vp.clip = vc[6]; vp.Play(); }
                else { vp.clip = vc[5]; vp.Play(); }
            }
            else if (DataCrosser.VideoNumber == 4)
            {
                if (DataCrosser.IsClockwise) { vp.clip = vc[4]; vp.Play(); }
                else { vp.clip = vc[7]; vp.Play(); }
            }
            else if (DataCrosser.VideoNumber == 5)
            {
                if (DataCrosser.IsClockwise) { vp.clip = vc[2]; vp.Play(); }
                else { vp.clip = vc[9]; vp.Play(); }
            }
            else if (DataCrosser.VideoNumber == 6)
            {
                if (DataCrosser.IsClockwise) { vp.clip = vc[11]; vp.Play(); }
                else { vp.clip = vc[12]; vp.Play(); }
            }
        }
    }
    private void Awake()
    {
        vp.loopPointReached += EndReached;
    }
    public void EndReached(VideoPlayer vp2)
    {
        if(DataCrosser.EnvCompleted || DataCrosser.WonLevels == 0) UnityEngine.SceneManagement.SceneManager.LoadScene("Envs Screen");
        else UnityEngine.SceneManagement.SceneManager.LoadScene("Restory");
    }
    public void skip()
    {
        au.PlayOneShot(Click);
        MusicPlayer.instance.ChangeMusic(PSong);
        StartCoroutine(Skip());
    }
    IEnumerator Skip()
    {
        yield return new WaitForSeconds(0.2f);
        EndReached(vp);
    }
}
