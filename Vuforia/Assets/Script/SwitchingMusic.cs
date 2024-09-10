using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingMusic : MonoBehaviour
{
    public AudioSource CharacterMusic;
    private LoadMusicFromResources _musicResources;
    private int _musicIndex = 0;
    private void Awake()
    {
        _musicResources = GetComponent<LoadMusicFromResources>();
        _musicIndex = PlayerPrefs.GetInt("MusicIndex", 0);
    }
    public void ForwardMusic()
    {
        _musicIndex++;
        if (_musicIndex >= _musicResources.Musics.Length)
        {
            _musicIndex = 0;
        }
        SaveMusicIndex();
        if (CharacterMusic.isPlaying)
        {
            PlayOrPauseMusic();
        }
        
    }
    public void BackwardMusic()
    {
        _musicIndex--;
        if (_musicIndex < 0)
        {
            _musicIndex = _musicResources.Musics.Length - 1;
        }
        SaveMusicIndex();
        if (CharacterMusic.isPlaying)
        {
            PlayOrPauseMusic();
        }
    }
    public void PlayOrPauseMusic()
    {
        if (_musicIndex >= 0 && _musicIndex < _musicResources.Musics.Length)
        {
            CharacterMusic.clip = _musicResources.Musics[_musicIndex];

            if (!CharacterMusic.isPlaying)
            {
                CharacterMusic.Play();
            }
            else
            {
                CharacterMusic.Pause();
            }
        }
    }
    private void SaveMusicIndex()
    {
        PlayerPrefs.SetInt("MusicIndex", _musicIndex);
        PlayerPrefs.Save();
    }
}
