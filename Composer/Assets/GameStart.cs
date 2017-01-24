﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
    public static bool inf=false;
    public static int lvl = 1;
    private static GameStart _instance = null;

	// Use this for initialization
	void Start () {
        if (_instance == null)
        {
            _instance = this;
        }
	}
    public static GameStart Instance()
    {
        return _instance;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartGame ()
    {
        SceneManager.LoadScene("Story");
        DontDestroyOnLoad(GameObject.Find("easySong"));
        DontDestroyOnLoad(GameObject.Find("mediumSong"));
        DontDestroyOnLoad(GameObject.Find("hardSong"));
        DontDestroyOnLoad(GameObject.Find("infiniteSong"));
    }
    public void Game()
    {
        SceneManager.LoadScene("Game");
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
        Resources.Load<GameObject>("Note").GetComponent<MovementHandler>().Speed = 0.01F;
        ApplicationSettings.Instance().GameSong = GameObject.Find("infiniteSong").GetComponent<AudioSource>().clip;
        inf = true;
    }
    public void Easy()
    {
        SceneManager.LoadScene("Game");
        Resources.Load<GameObject>("Note").GetComponent<MovementHandler>().Speed=0.01F;
        inf = false;
        ApplicationSettings.Instance().GameSong = GameObject.Find("easySong").GetComponent<AudioSource>().clip;
    }
    public void Medium()
    {
        SceneManager.LoadScene("Game");
        Resources.Load<GameObject>("Note").GetComponent<MovementHandler>().Speed = 0.02F;
        inf = false;
        lvl = 2;
        ApplicationSettings.Instance().GameSong = GameObject.Find("mediumSong").GetComponent<AudioSource>().clip;
    }
    public void Hard()
    {
        SceneManager.LoadScene("Game");
        Resources.Load<GameObject>("Note").GetComponent<MovementHandler>().Speed = 0.03F;
        inf = false;
        lvl = 3;
        ApplicationSettings.Instance().GameSong = GameObject.Find("hardSong").GetComponent<AudioSource>().clip;
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
