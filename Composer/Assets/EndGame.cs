using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class EndGame : MonoBehaviour {
    public AudioSource audio;


    void Start()
    {
        if (GameStart.inf)
        {
            GetComponent<AudioSource>().loop = true;
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
