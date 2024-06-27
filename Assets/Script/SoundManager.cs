using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
  
    private bool _muteBackGroundMusic = false;
    private bool _muteSoundFx = false;
    public static SoundManager instance;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }


    public void ToggleBackgroundMusic()
    {
        _muteBackGroundMusic = !_muteBackGroundMusic;
        if (_muteBackGroundMusic)
        {
            _audioSource.Stop();
        }
        else
        {
            _audioSource.Play();
        }
    }

    public void ToggleSoundFx()
    {
        _muteSoundFx = !_muteSoundFx;
        GameEvent.OnToggleSoundFxMethod();
    }

    public bool IsBackgroundMusicMuted()
    {
        return _muteBackGroundMusic;
    }

    public bool IsSoundFxMuted()
    {
        return _muteSoundFx;
    }

    public void SilienceBackgroundMusic(bool silience)
    {
        if (_muteBackGroundMusic == false)
        {
            if (silience)
            {
                _audioSource.volume = 0f;
            }
            else
            {
                _audioSource.volume = 1f;
            }
        }
    }
}
