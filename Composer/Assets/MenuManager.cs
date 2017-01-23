using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public static bool isStarted=false;
    public int lastMenuPosition = 0;
    public int menuPosition = 0;
    bool changeSelect = false;
    public List<GameObject> MenuButtons = new List<GameObject>();
    // Use this for initializations
    void Start () {
        GameObject.Find("start").GetComponent<UnityEngine.UI.Button>().Select();
	}

    // Update is called once per frame
    float lastPress = 0;
    float startTime = 0;
    
    void Update() {
        startTime += Time.deltaTime;
        bool keyPressed = false;
        foreach (int code in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown((KeyCode)code)
                && !(
                    Input.GetKeyDown(KeyCode.UpArrow)
                    || Input.GetKeyDown(KeyCode.DownArrow)
                    || Input.GetKeyDown(KeyCode.LeftArrow)
                    || Input.GetKeyDown(KeyCode.RightArrow)
                    )
                )
            {
                keyPressed = true;
            }
        }
        if(keyPressed && startTime > 0.5)
        {
            switch(menuPosition)
            {
                case 0:
                    GameObject.Find("PlaySounds").GetComponent<PlaySound>().playClip();
                    SceneManager.LoadScene("Story");
                    break;
                case 1:
                    GameObject.Find("PlaySounds").GetComponent<PlaySound>().playClip();
                    SceneManager.LoadScene("Credits");
                    break;
                case 2:
                    GameObject.Find("PlaySounds").GetComponent<PlaySound>().playClip();
                    Application.Quit();
                    break;
            }
        }
        lastPress += Time.deltaTime;
        if (lastPress > 0.1 && (
            Input.GetAxis("Vertical") < -0.5 || 
            Input.GetKey(KeyCode.UpArrow)))
        {
            lastPress = 0;
            menuPosition -= 1;
            if (menuPosition < 0)
            {
                menuPosition = MenuButtons.Count - 1;
            }
            changeSelect = true;
        }
        else if (lastPress > 0.1 && (
            Input.GetAxis("Vertical") > 0.5 || 
            Input.GetKey(KeyCode.DownArrow)))
        {
            menuPosition = (menuPosition + 1) % MenuButtons.Count;
            lastPress = 0;
            changeSelect = true;
        }

    }
    private void FixedUpdate()
    {

        if (lastMenuPosition != menuPosition && changeSelect)
        {
            changeSelect = false;
            //Debug.Log(lastMenuPosition + " " + menuPosition);
            MenuButtons[menuPosition].GetComponent<UnityEngine.UI.Button>().Select();
        }
        lastMenuPosition = menuPosition;
    }
}
