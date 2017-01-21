using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public Vector2 Direction = Vector2.zero;
    public float WaitTime = 1;
    public float StartTime = 5;
    public bool running = true;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnQueue());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator SpawnQueue()
    {
        yield return new WaitForSeconds(StartTime);
        while (running)
        {
            
            GameManager.CloneNote(Direction, this.gameObject, (GameManager.NoteColor)Random.Range(0, 4));
            
            WaitTime = Mathf.Max(WaitTime - 0.01f, 0.1f);
            yield return new WaitForSeconds(WaitTime);
        }
        yield return null;
    }
}
