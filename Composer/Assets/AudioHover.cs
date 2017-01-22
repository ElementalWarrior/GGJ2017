using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHover : MonoBehaviour {
    public AudioSource audio;
    public AudioClip myaudio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        audio.PlayOneShot(myaudio,1);
    }
}
