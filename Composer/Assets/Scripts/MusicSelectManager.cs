using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSelectManager : MonoBehaviour {

    public int lastMenuPosition = 10;
    public int menuPosition = 10;
    public List<GameObject> MenuButtons = new List<GameObject>();
    bool changeSelect = false;
    // Use this for initializations
    void Start()
    {
        GameObject.Find("Infinite").GetComponent<UnityEngine.UI.Button>().Select();
        GameObject.Find("Infinite").GetComponentInChildren<AudioHover>().onHover();
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
                    || Input.GetKeyDown(KeyCode.Mouse0)
                    || Input.GetKeyDown(KeyCode.Mouse1)
                    || Input.GetKeyDown(KeyCode.Mouse2)
                    || Input.GetKeyDown(KeyCode.Mouse3)
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
                    GameObject.Find("soundscript").GetComponent<PlaySound>().playClip();
                    GameStart.Instance().Easy();
                    break;
                case 1:
                    GameObject.Find("soundscript").GetComponent<PlaySound>().playClip();
                    GameStart.Instance().Medium();
                    break;
                case 2:
                    GameObject.Find("soundscript").GetComponent<PlaySound>().playClip();
                    GameStart.Instance().Hard();
                    break;
                default:
                    GameObject.Find("soundscript").GetComponent<PlaySound>().playClip();
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
                changeSelect = true;
            }
        } else if (lastPress > 0.1 && (
            Input.GetAxis("Horizontal") < -0.5 ||
            Input.GetKey(KeyCode.LeftArrow))) {

            if (menuPosition < 10)
            {
                menuPosition += 10;
                changeSelect = true;
            }
        } else if (lastPress > 0.1 && (
         Input.GetAxis("Vertical") < -0.5 ||
         Input.GetKey(KeyCode.UpArrow)))
        {
            lastPress = 0;
            menuPosition -= 1;
            if (menuPosition < 0)
            {
                menuPosition = 0;
            }
            changeSelect = true;
            menuPosition += greaterThan9 ? 10 : 0;
        }
        else if (lastPress > 0.1 && (
            Input.GetAxis("Vertical") > 0.5 ||
            Input.GetKey(KeyCode.DownArrow)))
        {
            menuPosition = Mathf.Min(menuPosition + 1, MenuButtons.Count-1);
            lastPress = 0;
            menuPosition += greaterThan9 ? 10 : 0;
            changeSelect = true;
        }

    }
    private void FixedUpdate()
    {

        if (lastMenuPosition != menuPosition && changeSelect)
        {
            changeSelect = false;
            //Debug.Log(lastMenuPosition + " " + menuPosition);
            foreach (GameObject obj in MenuButtons)
            {
                //var foo = obj.GetComponentsInChildren(typeof(Component));
                obj.GetComponentInChildren<AudioHover>().onExit();
            }
            GameObject.Find("Infinite").GetComponentInChildren<AudioHover>().onExit();
            if (menuPosition > 9)
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
