using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    GameObject defaultNote;
    public static GameObject ObjectDeath;
    // Use this for initialization
    void Start () {
        defaultNote = GameObject.Find("Note");
        ObjectDeath = GameObject.Find("CollisionDeath");
        defaultNote.SetActive(false);
        //CloneNote(MovementHandler.Tracks.Down);
        //CloneNote(MovementHandler.Tracks.Up);
        //CloneNote(MovementHandler.Tracks.Right);
    }
    public void CloneNote(MovementHandler.Tracks direction)
    {
        Vector3 pos = new Vector3(0f,0f,0f);
        switch(direction)
        {
            case MovementHandler.Tracks.Up:
                pos = new Vector3(1280/2, 720f, 10f);
                break;
            case MovementHandler.Tracks.Right:
                pos = new Vector3(0, 720 /2, 10f);
                break;
            case MovementHandler.Tracks.Down:
                pos = new Vector3(1280 / 2, 0f, 10f);
                break;
            case MovementHandler.Tracks.Left:
                pos = new Vector3(1280, 720/2, 10f);
                break;
        }
        GameObject _note = GameObject.Instantiate(defaultNote, Camera.main.ScreenToWorldPoint(pos), new Quaternion());
        _note.SetActive(true);
        _note.GetComponent<MovementHandler>().Track = direction;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            CloneNote(MovementHandler.Tracks.Left);
        }else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            CloneNote(MovementHandler.Tracks.Right);
        } else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            CloneNote(MovementHandler.Tracks.Up);
        } else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            CloneNote(MovementHandler.Tracks.Down);
        }
    }
}
