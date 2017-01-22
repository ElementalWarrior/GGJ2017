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
        }
    }

    void Update()
    {
       if (!audio.isPlaying && !audioeasy.isPlaying && !audiomed.isPlaying && !audiohard.isPlaying)
        {
            Application.LoadLevel("Win");
        }
    }
}
