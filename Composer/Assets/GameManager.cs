using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    GameObject defaultNote;
    // Use this for initialization
    void Start () {
        defaultNote = GameObject.Find("Note");
        defaultNote.SetActive(false);
        CloneNote(MovementHandler.Tracks.Down);
        CloneNote(MovementHandler.Tracks.Left);
        CloneNote(MovementHandler.Tracks.Up);
        CloneNote(MovementHandler.Tracks.Right);
        //_note.GetComponent<MovementHandler>().transform.position = ;
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
		
	}
}
