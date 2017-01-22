using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSelectManager : MonoBehaviour {

    public int lastMenuPosition = 10;
    public int menuPosition = 10;
    public List<GameObject> MenuButtons = new List<GameObject>();
    // Use this for initializations
    void Start()
    {
        GameObject.Find("Infinite").GetComponent<UnityEngine.UI.Button>().Select();
    }

    // Update is called once per frame
    float lastPress = 0;
    float startTime = 0;

    void Update()
    {
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
        if (keyPressed && startTime > 0.5)
        {
            switch (menuPosition)
            {
                case 0:
                    GameStart.Instance().Easy();
                    break;
                case 1:
                    GameStart.Instance().Medium();
                    break;
                case 2:
                    GameStart.Instance().Hard();
                    break;
                default:
                    GameStart.Instance().Infinite();
                    break;
            }
        }
        lastPress += Time.deltaTime;
        bool greaterThan9 = menuPosition > 9;
        if (lastPress > 0.1 && (
            Input.GetAxis("Horizontal") > 0.5 ||
            Input.GetKey(KeyCode.RightArrow)))
        {
            if (menuPosition > 9)
            {
                menuPosition -= 10;
            }
        } else if (lastPress > 0.1 && (
            Input.GetAxis("Horizontal") < -0.5 ||
            Input.GetKey(KeyCode.LeftArrow))) {

            if (menuPosition < 10)
            {
                menuPosition += 10;
            }
        } else if (lastPress > 0.1 && (
         Input.GetAxis("Vertical") < -0.5 ||
         Input.GetKey(KeyCode.UpArrow)))
        {
            lastPress = 0;
            menuPosition -= 1;
            if (menuPosition < 0)
            {
                menuPosition = MenuButtons.Count - 1;
            }
            menuPosition += greaterThan9 ? 10 : 0;
        }
        else if (lastPress > 0.1 && (
            Input.GetAxis("Vertical") > 0.5 ||
            Input.GetKey(KeyCode.DownArrow)))
        {
            menuPosition = (menuPosition + 1) % MenuButtons.Count;
            lastPress = 0;
            menuPosition += greaterThan9 ? 10 : 0;
        }

    }
    private void FixedUpdate()
    {

        if (lastMenuPosition != menuPosition)
        {
            //Debug.Log(lastMenuPosition + " " + menuPosition);
            foreach (GameObject obj in MenuButtons)
            {
                //var foo = obj.GetComponentsInChildren(typeof(Component));
                obj.GetComponentInChildren<AudioHover>().onExit();
            }
            if(menuPosition > 9)
            {
                GameObject.Find("Infinite").GetComponent<UnityEngine.UI.Button>().Select();
                GameObject.Find("Infinite").GetComponentInChildren<AudioHover>().onHover();
            } else
            {
                MenuButtons[menuPosition].GetComponent<UnityEngine.UI.Button>().Select();
                MenuButtons[menuPosition].GetComponentInChildren<AudioHover>().onHover();
            }
        }
        lastMenuPosition = menuPosition;
    }
}
