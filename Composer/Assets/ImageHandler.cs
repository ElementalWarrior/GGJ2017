using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        bool keyPressed = false;
        foreach (int code in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown((KeyCode)code))
            {
                keyPressed = true;
            }
        }
		 if(ComicNum < 11 && (keyPressed || _counter >= 4))
        {
        	ComicNum++;
            Sprite tex = Resources.Load<Sprite>("comic_0" + ComicNum);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = tex;
            _counter = 0;

        } else if (ComicNum >= 11 && (keyPressed || _counter >= 4)) 
        {
            
            SceneManager.LoadScene("MusicSelection");
           
    	}
	}
}

