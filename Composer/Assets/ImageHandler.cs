using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Space))
        {
            Sprite tex = Resources.Load<Sprite>("comic_02");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = tex;
        }
	}
}
