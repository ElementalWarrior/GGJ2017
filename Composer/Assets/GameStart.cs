using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
    public static int diff;

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
        Resources.Load<GameObject>("Note").GetComponent<MovementHandler>().Speed = 1;
    }
    public void Easy()
    {
        SceneManager.LoadScene("Game");
        Resources.Load<GameObject>("Note").GetComponent<MovementHandler>().Speed=0.01F;
    }
    public void Medium()
    {
        SceneManager.LoadScene("Game");
        Resources.Load<GameObject>("Note").GetComponent<MovementHandler>().Speed = 0.02F;
    }
    public void Hard()
    {
        SceneManager.LoadScene("Game");
        Resources.Load<GameObject>("Note").GetComponent<MovementHandler>().Speed = 0.03F;
    }
    public void Back()
    {
        SceneManager.LoadScene("Game");
    }
    public void ChooseSong()
    {
    	SceneManager.LoadScene("MusicSelection");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    } 

}
