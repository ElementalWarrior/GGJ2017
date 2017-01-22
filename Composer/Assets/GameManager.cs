using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Use this for initialization
    void Start () {
        Score = 0;
        _instance = this;
        ObjectDeath = GameObject.Find("CollisionDeath");
        ComposerColor = GameObject.Find("ComposerBackground").GetComponent<ComposerColor>();
        BoxCollider2D collider = this.GetComponent<BoxCollider2D>();
        
        //resize camera bounds so we remove waves after they leave the viewport
        collider.size = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelRect.width, Camera.main.pixelRect.height, 0)) - Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));

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
        Resources.Load<GameObject>("Note").GetComponent<MovementHandler>().Speed = 0.01F + (Time.time * 0.0005F);
        deltaLeft += Time.deltaTime;
        deltaRight += Time.deltaTime;
        deltaUp += Time.deltaTime;
        deltaDown += Time.deltaTime;
        if (NumWaves > NumNotes + 1)
        {
            return;
        }
        if(Input.GetKeyDown("joystick 1 button 0"))
        {
            Debug.Log("joystick button 0");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)
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
}
