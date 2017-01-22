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
    // Use this for initialization
    void Start () {
        ObjectDeath = GameObject.Find("CollisionDeath");
        ComposerColor = GameObject.Find("ComposerBackground").GetComponent<ComposerColor>();
    }
    public enum NoteColor { Blue, Green, Red, Yellow }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            WaveSpawnerLeft.Spawn(ComposerColor.CurrentColor);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
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
