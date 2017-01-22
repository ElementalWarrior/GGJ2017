using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class EndGame : MonoBehaviour {
    public AudioSource audio;
    public AudioSource audioeasy;
    public AudioSource audiomed;
    public AudioSource audiohard;
    void Start()
    {
        if (GameStart.inf)
        {
            audio.loop = true;
            audio.Play();
        }
        else if (GameStart.lvl == 1)
        {
            audioeasy.Play();
        }
        else if (GameStart.lvl == 2)
        {
            audiomed.Play();
        }
        else 
        {
            audiohard.Play();
        }
    }

    void Update()
    {
       if (!audio.isPlaying)
        {
            Application.LoadLevel("Win");
        }
    }
}
