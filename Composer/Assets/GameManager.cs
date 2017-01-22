using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


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
	void Update () {
        if (NumWaves > NumNotes + 1)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))// || Input.GetAxis("Horizontal") < -0.5)
        {
            WaveSpawnerLeft.Spawn(ComposerColor.CurrentColor);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))// || Input.GetAxis("Horizontal") > 0.5)
        {
            WaveSpawnerRight.Spawn(ComposerColor.CurrentColor);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            WaveSpawnerUp.Spawn(ComposerColor.CurrentColor);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            WaveSpawnerDown.Spawn(ComposerColor.CurrentColor);
        }
    }
}
