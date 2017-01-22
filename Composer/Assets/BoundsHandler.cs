using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<Collider2D>().bounds.Intersects(Camera.main.GetComponent<Collider2D>().bounds))
        {
            Debug.Log("Outside");
        }
	}
}
