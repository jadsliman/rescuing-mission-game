using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MenusManager : MonoBehaviour
{
    public GameObject main, settings, Tutorial, Envs, FadeOut, FadeIn, LoadingBar, EnvCompleted, Warning, gm, rc; 
    public GameObject[] BGs, Buttons, TButtons, EButtons, ELocks, SButtons;
    public TextMeshProUGUI[] Texts, TTexts, STexts; public TextMeshProUGUI music, sfx;
    public AudioSource au; public AudioClip click, PSong, Song;
    public string url = "https://paypal.me/EitharSoliman";
    void Start()
    {
        FadeOut.SetActive(true);
        au.volume = DataCrosser.sfx;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Levels Screen"))
        {
            BGs[DataCrosser.SelectedEnv].SetActive(true);
            if (DataCrosser.WonLevels >= 2) gm.SetActive(true);
            if (DataCrosser.FTF) { EnvCompleted.SetActive(true); DataCrosser.FTF = false; }
            if (DataCrosser.SelectedEnv == 0)
            {
                Tutorial.SetActive(true);
                if(DataCrosser.WonLevels >= 2)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        TButtons[i].SetActive(true);
                        TTexts[i].color = Color.white;
                    }
                }
                else
                {
                    for (int i = 0; i < DataCrosser.WonLevels + 1; i++)
                    {
                        TButtons[i].SetActive(true);
                        TTexts[i].color = Color.white;
                    }
                }
            }
            else
            {
                Envs.SetActive(true);
                if (!DataCrosser.IsClockwise)
                {
                    if (DataCrosser.SelectedEnv == 1 && DataCrosser.WonLevels >= 17)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 1 && DataCrosser.WonLevels < 17)
                    {
                        for (int i = 0; i < DataCrosser.WonLevels - 2; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 2 && DataCrosser.WonLevels >= 32)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 2 && DataCrosser.WonLevels < 32)
                    {
                        for (int i = 0; i < DataCrosser.WonLevels - 17; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 3 && DataCrosser.WonLevels >= 47)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 3 && DataCrosser.WonLevels < 47)
                    {
                        for (int i = 0; i < DataCrosser.WonLevels - 32; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 4 && DataCrosser.WonLevels >= 62)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 4 && DataCrosser.WonLevels < 62)
                    {
                        for (int i = 0; i < DataCrosser.WonLevels - 47; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 5 && DataCrosser.WonLevels >= 77)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 5 && DataCrosser.WonLevels < 77)
                    {
                        for (int i = 0; i < DataCrosser.WonLevels - 62; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 6 && DataCrosser.WonLevels >= 92)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 6 && DataCrosser.WonLevels < 92)
                    {
                        for (int i = 0; i < DataCrosser.WonLevels - 77; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                }
                else
                {
                    if (DataCrosser.SelectedEnv == 5 && DataCrosser.WonLevels >= 17)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 5 && DataCrosser.WonLevels < 17)
                    {
                        for (int i = 0; i < DataCrosser.WonLevels - 2; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 4 && DataCrosser.WonLevels >= 32)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 4 && DataCrosser.WonLevels < 32)
                    {
                        for (int i = 0; i < DataCrosser.WonLevels - 17; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 3 && DataCrosser.WonLevels >= 47)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 3 && DataCrosser.WonLevels < 47)
                    {
                        for (int i = 0; i < DataCrosser.WonLevels - 32; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 2 && DataCrosser.WonLevels >= 62)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 2 && DataCrosser.WonLevels < 62)
                    {
                        for (int i = 0; i < DataCrosser.WonLevels - 47; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 1 && DataCrosser.WonLevels >= 77)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 1 && DataCrosser.WonLevels < 77)
                    {
                        for (int i = 0; i < DataCrosser.WonLevels - 62; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 6 && DataCrosser.WonLevels >= 92)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                    else if (DataCrosser.SelectedEnv == 6 && DataCrosser.WonLevels < 92)
                    {
                        for (int i = 0; i < DataCrosser.WonLevels - 77; i++)
                        {
                            Buttons[i].SetActive(true);
                            Texts[i].color = Color.white;
                        }
                    }
                }
            }
        }
        else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Envs Screen"))
        {
            if(DataCrosser.EnvCompleted && DataCrosser.WonLevels != 93) { EnvCompleted.SetActive(true); }
            else if (DataCrosser.RC) { rc.SetActive(true); }
            else { EnvCompleted.SetActive(false); }
            if(!DataCrosser.IsClockwise)
            {
                if(DataCrosser.WonLevels >= 3)
                {
                    EButtons[0].SetActive(true); ELocks[0].SetActive(false);
                    if (DataCrosser.WonLevels >= 18)
                    {
                        EButtons[1].SetActive(true); ELocks[1].SetActive(false);
                        if (DataCrosser.WonLevels >= 33)
                        {
                            EButtons[2].SetActive(true); ELocks[2].SetActive(false);
                            if(DataCrosser.WonLevels >= 48)
                            {
                                EButtons[3].SetActive(true); ELocks[3].SetActive(false);
                                if(DataCrosser.WonLevels >= 63)
                                {
                                    EButtons[4].SetActive(true); ELocks[4].SetActive(false);
                                    if(DataCrosser.WonLevels >= 78)
                                    {
                                        EButtons[5].SetActive(true); ELocks[5].SetActive(false);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (DataCrosser.WonLevels >= 3)
                {
                    EButtons[4].SetActive(true); ELocks[4].SetActive(false);
                    if (DataCrosser.WonLevels >= 18)
                    {
                        EButtons[3].SetActive(true); ELocks[3].SetActive(false);
                        if (DataCrosser.WonLevels >= 33)
                        {
                            EButtons[2].SetActive(true); ELocks[2].SetActive(false);
                            if (DataCrosser.WonLevels >= 48)
                            {
                                EButtons[1].SetActive(true); ELocks[1].SetActive(false);
                                if (DataCrosser.WonLevels >= 63)
                                {
                                    EButtons[0].SetActive(true); ELocks[0].SetActive(false);
                                    if (DataCrosser.WonLevels >= 78)
                                    {
                                        EButtons[5].SetActive(true); ELocks[5].SetActive(false);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Loading Screen"))
        {
            SaveManager.LoadGame();
            /*string path = Application.persistentDataPath + "/save.json";
            if (File.Exists(path)) File.Delete(path);*/
            StartCoroutine(LoadingScreen(96));
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Restory"))
        {
            for (int i = 0; i < (DataCrosser.WonLevels - 3) / 15; i++)
            {
                SButtons[i].SetActive(true);
                STexts[i].color = Color.white;
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gear Screen"))
        {
            if(DataCrosser.FTGM) { EnvCompleted.SetActive(true); DataCrosser.FTGM = false; }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main Menu"))
        {
            sfx.text = (DataCrosser.sfx * 100) + "%"; music.text = (DataCrosser.music * 100) + "%";
        }
    }

    public void StartGame()
    {
        au.PlayOneShot(click);
        if (DataCrosser.WonLevels == 0) { DataCrosser.EnvCompleted = true; StartCoroutine(fadeIn(98)); }
        else { MusicPlayer.instance.ChangeMusic(PSong); StartCoroutine(fadeIn(96)); }
    }

    public void ExitGame()
    {
        au.PlayOneShot(click);
        Application.Quit();
    }

    public void Settings()
    {
        au.PlayOneShot(click);
        main.SetActive(false);
        settings.SetActive(true);
    }
    public void Support()
    {
        if(string.IsNullOrEmpty(url))
        {
            return;
        }
        Application.OpenURL(url);
    }
    public void ML()
    {
        au.PlayOneShot(click);
        if(DataCrosser.music != 0f)
        {
            DataCrosser.music -= 0.25f;
            MusicPlayer.instance.ChangeVolume();
            music.text = (DataCrosser.music * 100) + "%"; 
        }
    }
    public void SL()
    {
        au.PlayOneShot(click);
        if (DataCrosser.sfx != 0f)
        {
            DataCrosser.sfx -= 0.25f;
            au.volume = DataCrosser.sfx;
            sfx.text = (DataCrosser.sfx * 100) + "%";
        }
    }
    public void MH()
    {
        au.PlayOneShot(click);
        if (DataCrosser.music != 1f)
        {
            DataCrosser.music += 0.25f;
            MusicPlayer.instance.ChangeVolume();
            music.text = (DataCrosser.music * 100) + "%";
        }
    }
    public void SH()
    {
        au.PlayOneShot(click);
        if (DataCrosser.sfx != 1f)
        {
            DataCrosser.sfx += 0.25f;
            au.volume = DataCrosser.sfx;
            sfx.text = (DataCrosser.sfx * 100) + "%";
        }
    }
    public void Back()
    {
        au.PlayOneShot(click);
        main.SetActive(true);
        settings.SetActive(false);
    }

    public void EBack()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        StartCoroutine(fadeIn(95));
    }
    public void LBack()
    {
        au.PlayOneShot(click);
        StartCoroutine(fadeIn(96));
    }
    public void GBack()
    {
        if(DataCrosser.Gadget1Index == 0 && DataCrosser.Gadget2Index == 0)
        {
            Warning.SetActive(true);
        }
        else
        {
            au.PlayOneShot(click);
            StartCoroutine(fadeIn(97));
        }
    }
    public void GM()
    {
        au.PlayOneShot(click);
        StartCoroutine(fadeIn(93));
    }
    public void RS()
    {
        au.PlayOneShot(click);
        StartCoroutine(fadeIn(99));
    }
    public void OK()
    {
        au.PlayOneShot(click);
        EnvCompleted.SetActive(false);
    }
    public void CW()
    {
        au.PlayOneShot(click);
        DataCrosser.IsClockwise = true;
        DataCrosser.RC = false;
        DataCrosser.WonLevels++;
        StartCoroutine(fadeIn(96));
    }
    public void ACW()
    {
        au.PlayOneShot(click);
        DataCrosser.IsClockwise = false;
        DataCrosser.RC = false;
        DataCrosser.WonLevels++;
        StartCoroutine(fadeIn(96));
    }

    public void Env1()
    {
        au.PlayOneShot(click);
        DataCrosser.SelectedEnv = 0;
        StartCoroutine(fadeIn(97));
    }
    public void Env2()
    {
        au.PlayOneShot(click);
        DataCrosser.SelectedEnv = 1;
        StartCoroutine(fadeIn(97));
    }
    public void Env3()
    {
        au.PlayOneShot(click);
        DataCrosser.SelectedEnv = 2;
        StartCoroutine(fadeIn(97));
    }
    public void Env4()
    {
        au.PlayOneShot(click);
        DataCrosser.SelectedEnv = 3;
        StartCoroutine(fadeIn(97));
    }
    public void Env5()
    {
        au.PlayOneShot(click);
        DataCrosser.SelectedEnv = 4;
        StartCoroutine(fadeIn(97));
    }
    public void Env6()
    {
        au.PlayOneShot(click);
        DataCrosser.SelectedEnv = 5;
        StartCoroutine(fadeIn(97));
    }
    public void Env7()
    {
        au.PlayOneShot(click);
        DataCrosser.SelectedEnv = 6;
        StartCoroutine(fadeIn(97));
    }
    
    public void L1()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 0) StartCoroutine(fadeIn(0));
        else if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(3));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(18));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(33));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(48));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(63));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(78));
    }
    public void L2()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 0) StartCoroutine(fadeIn(1));
        else if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(4));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(19));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(34));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(49));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(64));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(79));
    }
    public void L3()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 0) StartCoroutine(fadeIn(2));
        else if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(5));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(20));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(35));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(50));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(65));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(80));
    }
    public void L4()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(6));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(21));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(36));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(51));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(66));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(81));
    }
    public void L5()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(7));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(22));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(37));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(52));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(67));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(82));
    }
    public void L6()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(8));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(23));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(38));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(53));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(68));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(83));
    }
    public void L7()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(9));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(24));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(39));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(54));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(69));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(84));
    }
    public void L8()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(10));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(25));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(40));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(55));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(70));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(85));
    }
    public void L9()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(11));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(26));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(41));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(56));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(71));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(86));
    }
    public void L10()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(12));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(27));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(42));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(57));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(72));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(87));
    }
    public void L11()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(13));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(28));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(43));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(58));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(73));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(88));
    }
    public void L12()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(14));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(29));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(44));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(59));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(74));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(89));
    }
    public void L13()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(15));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(30));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(45));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(60));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(75));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(90));
    }
    public void L14()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(16));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(31));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(46));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(61));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(76));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(91));
    }
    public void L15()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        if (DataCrosser.SelectedEnv == 1) StartCoroutine(fadeIn(17));
        else if (DataCrosser.SelectedEnv == 2) StartCoroutine(fadeIn(32));
        else if (DataCrosser.SelectedEnv == 3) StartCoroutine(fadeIn(47));
        else if (DataCrosser.SelectedEnv == 4) StartCoroutine(fadeIn(62));
        else if (DataCrosser.SelectedEnv == 5) StartCoroutine(fadeIn(77));
        else if (DataCrosser.SelectedEnv == 6) StartCoroutine(fadeIn(92));
    }
    public void Beginning()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        DataCrosser.VideoNumber = 0;
        DataCrosser.EnvCompleted = false;
        StartCoroutine(VfadeIn(99));
    }
    public void P1()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        DataCrosser.VideoNumber = 1;
        DataCrosser.EnvCompleted = false;
        StartCoroutine(VfadeIn(99));
    }
    public void P2()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        DataCrosser.VideoNumber = 2;
        DataCrosser.EnvCompleted = false;
        StartCoroutine(VfadeIn(99));
    }
    public void P3()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        DataCrosser.VideoNumber = 3;
        DataCrosser.EnvCompleted = false;
        StartCoroutine(VfadeIn(99));
    }
    public void P4()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        DataCrosser.VideoNumber = 4;
        DataCrosser.EnvCompleted = false;
        StartCoroutine(VfadeIn(99));
    }
    public void P5()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        DataCrosser.VideoNumber = 5;
        DataCrosser.EnvCompleted = false;
        StartCoroutine(VfadeIn(99));
    }
    public void Ending()
    {
        au.PlayOneShot(click);
        MusicPlayer.instance.ChangeMusic(Song);
        DataCrosser.VideoNumber = 6;
        DataCrosser.EnvCompleted = false;
        StartCoroutine(VfadeIn(99));
    }

    private IEnumerator fadeIn(int i)
    {
        FadeIn.SetActive(true);
        AsyncOperation op = SceneManager.LoadSceneAsync(i + 1);
        op.allowSceneActivation = false;
        yield return new WaitForSeconds(0.7f);
        op.allowSceneActivation = true;
    }
    private IEnumerator VfadeIn(int i)
    {
        FadeIn.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(i);
    }
    private IEnumerator LoadingScreen(int i)
    {
        yield return new WaitForSeconds(3f);
        LoadingBar.SetActive(true);
        yield return new WaitForSeconds(2f);
        FadeIn.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(i);
    }
}