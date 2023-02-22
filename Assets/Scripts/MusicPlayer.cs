using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //To be done during Awake
    void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        //Singleton pattern
        if (numMusicPlayer > 1)
        {
            Destroy(gameObject);    
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
