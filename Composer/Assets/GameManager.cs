using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject _note = GameObject.Instantiate(GameObject.Find("Note"));
        _note.GetComponent<MovementHandler>().transform.position = new Vector2(0, 720 / 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
