using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeep : MonoBehaviour {
    private float start;
    public Text TimerText;
	// Use this for initialization
	void Start () {
        start = Time.time;
	}
	
	// Update is called once per frame
	public void Update () {
        float t = Time.time - start;
        string current = t.ToString("#.00");
        TimerText.text = current;
	}
  
}
