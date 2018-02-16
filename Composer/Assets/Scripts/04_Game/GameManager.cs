using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITYEDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour {

    public static int Score;
    public GameObject heart0;
    public GameObject heart1;
    public GameObject heart2;
    public static int NumHearts = 3;
    public static GameObject ObjectDeath;
    public Spawner WaveSpawnerLeft;
    public Spawner WaveSpawnerRight;
    public Spawner WaveSpawnerDown;
    public Spawner WaveSpawnerUp;
    private ComposerColor ComposerColor;
    public int NumWaves = 0;
    public int NumNotes = 0;
    public static GameManager _instance;
    public bool IsPaused = false;
    public GameObject PauseScreen;
    private bool AltDown = false;
    // Use this for initialization
    void Start () {
        NumHearts = 3;
        Score = 0;
        _instance = this;
        ObjectDeath = GameObject.Find("CollisionDeath");
        ComposerColor = GameObject.Find("ComposerBackground").GetComponent<ComposerColor>();
        BoxCollider2D collider = this.GetComponent<BoxCollider2D>();
        
        
        //resize camera bounds so we remove waves after they leave the viewport
        collider.size = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelRect.width, Camera.main.pixelRect.height, 0)) - Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));

        if(ApplicationSettings.Instance().GameSong != null)
        {
            GameObject.Find("music").GetComponent<AudioSource>().clip = ApplicationSettings.Instance().GameSong;
            GameObject.Find("music").GetComponent<AudioSource>().Play();
        }
    }
    public static GameManager Instance()
    {
        return _instance;
    }
    public enum NoteColor { Blue, Green, Red, Yellow }

    // Update is called once per frame
    float deltaLeft = 0;
    float deltaRight = 0;
    float deltaUp = 0;
    float deltaDown = 0;
    void Update () {
        if (GameStart.inf) {
            Resources.Load<GameObject>("Note").GetComponent<MovementHandler>().Speed = 0.01F + (Time.timeSinceLevelLoad * 0.0003F);
        }
        
        deltaLeft += Time.deltaTime;
        deltaRight += Time.deltaTime;
        deltaUp += Time.deltaTime;
        deltaDown += Time.deltaTime;
        if (NumWaves > NumNotes + 1)
        {
            return;
        }
        
        if((Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)))
        {
            AltDown = true;
        }
        if ((Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt)))
        {
            AltDown = false;
        }
        if(IsPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Scenes/MusicSelection");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsPaused)
            {
                UnPause();
            } else
            {
                Pause();
            }
        }
        else if (AltDown && Input.GetKeyDown(KeyCode.Q))
        {
#if UNITYEDITOR
            EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)
         || (Input.GetAxis("Horizontal") < -0.5 && deltaLeft > 0.2)
         )// || Input.GetAxis("Horizontal") < -0.5)
        {
            deltaLeft = 0;
            WaveSpawnerLeft.Spawn(ComposerColor.CurrentColor);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)
            || (Input.GetAxis("Horizontal") > 0.5 && deltaRight > 0.2))// || Input.GetAxis("Horizontal") > 0.5)
        {
            deltaRight = 0;
            WaveSpawnerRight.Spawn(ComposerColor.CurrentColor);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)
            || (Input.GetAxis("Vertical") < -0.5 && deltaUp > 0.2))
        {
            deltaUp = 0;
            WaveSpawnerUp.Spawn(ComposerColor.CurrentColor);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)
            || (Input.GetAxis("Vertical") > 0.5 && deltaDown > 0.2))
        {
            deltaDown = 0;
            WaveSpawnerDown.Spawn(ComposerColor.CurrentColor);
        }
    }
    public void OnApplicationFocus(bool focus)
    {
        if (!focus && SceneManager.GetActiveScene().name == "Game")
        {
            Pause();
        }
    }
    public void Pause()
    {
        IsPaused = true;
        PauseScreen.SetActive(true);
        foreach (AudioSource a in GameObject.FindObjectsOfType<AudioSource>())
        {
            a.Pause();
        }
    }
    public void UnPause()
    {
        IsPaused = false;
        PauseScreen.SetActive(false);
        foreach (AudioSource a in GameObject.FindObjectsOfType<AudioSource>())
        {
            a.UnPause();
        }
    }
}
