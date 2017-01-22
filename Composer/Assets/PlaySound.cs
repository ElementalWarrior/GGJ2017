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
        DontDestroyOnLoad(this.audioSource);
        DontDestroyOnLoad(this.audioClip);

    }
    // Use this for initialization
    void Start () {
        //audioSource = new AudioSource();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
