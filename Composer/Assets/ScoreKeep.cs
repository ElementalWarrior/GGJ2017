using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeep : MonoBehaviour {
    float score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        score = Time.deltaTime;
	}
    void OnGUI()
    {
        Text text = GetComponentInChildren<Text>();
        text.text = ""+ score;
    }
}
