using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySound : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
