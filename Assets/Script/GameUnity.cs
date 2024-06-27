using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUnity : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
    public void MuteToggleBackgroundMusic()
    {
        SoundManager.instance.ToggleBackgroundMusic();
    }

    public void MuteToggleSoundFx()
    {
        SoundManager.instance.ToggleSoundFx();
    }
}

