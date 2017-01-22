using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartGame ()
    {
        Application.LoadLevel ("Story");
    }
    public void ExitGame ()
    {
        Application.Quit();
    }
    public void Options ()
    {
        Application.LoadLevel ("Options");
    }
    public void Credits()
    {
        Application.LoadLevel ("Credits");
    }
    public void Infinite ()
    {
    	Application.LoadLevel("Game");
    }
    public void Easy()
    {
    	Application.LoadLevel("Game");
    }
    public void Medium()
    {
    	Application.LoadLevel("Game");
    }
    public void Hard()
    {
    	Application.LoadLevel("Game");
    }

}
