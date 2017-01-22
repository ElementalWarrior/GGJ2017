using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backgroundmusic : MonoBehaviour {
   
    void Start()
    {
        if (MenuManager.isStarted)
        {
            Destroy(this.gameObject);
        }
        MenuManager.isStarted = true;
    }
    void Update()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "Game") 
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    
}
