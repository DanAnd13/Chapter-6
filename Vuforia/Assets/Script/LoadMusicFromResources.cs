using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMusicFromResources : MonoBehaviour
{
    [HideInInspector]
    public AudioClip[] Musics;

    private void Awake()
    {
        Musics = Resources.LoadAll<AudioClip>("Music");
    }
}
