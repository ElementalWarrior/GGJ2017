using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartGame ()
    {
        SceneManager.LoadScene("Story");
    }
    public void ExitGame ()
    {
        Application.Quit();
    }
    public void Options ()
    {
        SceneManager.LoadScene("Options");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Infinite ()
    {
        SceneManager.LoadScene("Game");
    }
    public void Easy()
    {
        SceneManager.LoadScene("Game");
    }
    public void Medium()
    {
        SceneManager.LoadScene("Game");
    }
    public void Hard()
    {
        SceneManager.LoadScene("Game");
    }
    public void Back()
    {
        SceneManager.LoadScene("Game");
    }
    public void ChooseSong()
    {
    	Application.LoadLevel("MusicSelection");
    }

}
