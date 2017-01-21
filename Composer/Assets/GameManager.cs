using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static GameObject defaultNote;
    public static GameObject ObjectDeath;
    // Use this for initialization
    void Start () {
        defaultNote = Resources.Load<GameObject>("Note");
        defaultNote.SetActive(false);
        ObjectDeath = GameObject.Find("CollisionDeath");
        //CloneNote(MovementHandler.Tracks.Down);
        //CloneNote(MovementHandler.Tracks.Up);
        //CloneNote(MovementHandler.Tracks.Right);
    }
    public enum NoteColor { Blue, Green, Red, Yellow }
    public static GameObject CloneNote(Vector2 Direction, GameObject spawner,  NoteColor color)
    {
        GameObject newNote = Instantiate(GameManager.defaultNote, spawner.transform.position, new Quaternion());
        switch (color)
        {
            case NoteColor.Blue:
                newNote.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("note_blue");
                break;
            case NoteColor.Green:
                newNote.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("note_green");
                break;
            case NoteColor.Red:
                newNote.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("note_red");
                break;
            case NoteColor.Yellow:
                newNote.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("note_yellow");
                break;
        }
        //newNote.transform.position = Vector2.zero;
        newNote.SetActive(true);
        MovementHandler mhNote = newNote.GetComponent<MovementHandler>();
        mhNote.direction = Direction;
        return newNote;
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    CloneNote(MovementHandler.Tracks.Left);
        //}else if(Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    CloneNote(MovementHandler.Tracks.Right);
        //} else if (Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    CloneNote(MovementHandler.Tracks.Down);
        //} else if (Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    CloneNote(MovementHandler.Tracks.Up);
        //}
    }
}
