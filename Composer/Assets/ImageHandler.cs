using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		_counter = 0;
	}
	private float _counter;
	private int ComicNum = 1;
	// Update is called once per frame
	void Update () {

		//counter increases till trigger time 

		_counter += Time.deltaTime; 
		//after or equals 5 secs show image 
		//Debug.Log(_counter);
		//if()
		 if(Input.GetKeyUp(KeyCode.Space) || (ComicNum < 8 && _counter >= 5))
        {
        	ComicNum++;
            Sprite tex = Resources.Load<Sprite>("comic_0" + ComicNum);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = tex;
            _counter = 0;

        } else if (ComicNum >= 8) 
        {
        Application.LoadLevel("Game");
    	}
	}
}

