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
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            WaveSpawnerLeft.Spawn(ComposerColor.CurrentColor);
            Debug.Log(ComposerColor.CurrentColor.ToString());
            //CloneNote(MovementHandler.Tracks.Left);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            WaveSpawnerRight.Spawn(ComposerColor.CurrentColor);
            //CloneNote(MovementHandler.Tracks.Right);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            WaveSpawnerUp.Spawn(ComposerColor.CurrentColor);
            //CloneNote(MovementHandler.Tracks.Down);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            WaveSpawnerDown.Spawn(ComposerColor.CurrentColor);
            //CloneNote(MovementHandler.Tracks.Up);
        }
    }
}
