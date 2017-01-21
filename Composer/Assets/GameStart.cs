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
        Application.LoadLevel ("Game");
    }
    public void ExitGame ()
    {
        Application.Quit();
    }
    void Options ()
    {

    }

}
