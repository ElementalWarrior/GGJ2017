
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public Vector2 Direction = Vector2.zero;
    public float WaitTime = 1;
    public float StartTime = 5;
    public bool running = true;
    public GameObject objectToSpawn = null;
    public bool UseTimer = true;
	// Use this for initialization
	void Start () {
        if (UseTimer)
        {
            StartCoroutine(SpawnQueue());
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator SpawnQueue()
    {
        yield return new WaitForSeconds(StartTime);
        while (running)
        {
            Spawn((GameManager.NoteColor)Random.Range(0, 4));
            
            WaitTime = Mathf.Max(WaitTime - 0.01f, 0.1f);
            yield return new WaitForSeconds(WaitTime);
        }
        yield return null;
    }
    public GameObject Spawn(GameManager.NoteColor color)
    {
        if(objectToSpawn == null)
        {
            return null;
        }
        GameObject newNote = GameObject.Instantiate(objectToSpawn, this.transform.position, new Quaternion());
        newNote.tag = color.ToString();
        if(objectToSpawn.name.IndexOf("Note") == 0)
        {
            GameManager.Instance().NumNotes++;
        } else if (objectToSpawn.name.IndexOf("Wave") == 0)
        {
            GameManager.Instance().NumWaves++;
        }
        switch (color)
        {
            case GameManager.NoteColor.Blue:
                newNote.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(objectToSpawn.name + "/blue");
                break;
            case GameManager.NoteColor.Green:
                newNote.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(objectToSpawn.name + "/green");
                break;
            case GameManager.NoteColor.Red:
                newNote.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(objectToSpawn.name + "/red");
                break;
            case GameManager.NoteColor.Yellow:
                newNote.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(objectToSpawn.name + "/yellow");
                break;
        }
        MovementHandler mhNote = newNote.GetComponent<MovementHandler>();
        mhNote.direction = Direction;
        return newNote;
    }
}
