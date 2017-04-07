using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class EndGame : MonoBehaviour {
    void Start()
    {
        if (GameStart.inf)
        {
            GameObject.Find("music").GetComponent<AudioSource>().loop = true;
        } else
        {
            GameObject.Find("music").GetComponent<AudioSource>().loop = false;
        }
    }

    void Update()
    {
        GameObject music = GameObject.Find("music");
        AudioSource aSource = music.GetComponent<AudioSource>();
       if (!aSource.isPlaying && !GameManager.Instance().IsPaused)
        {
            Application.LoadLevel("Win");
        }
    }
}
