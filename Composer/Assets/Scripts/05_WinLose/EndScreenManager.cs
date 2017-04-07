using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EndScreenManager : MonoBehaviour
{
    public int lastMenuPosition = 0;
    public int menuPosition = 0;
    public List<GameObject> MenuButtons = new List<GameObject>();
    bool changeSelect = false;
    // Use this for initializations
    void Start()
    {
        MenuButtons[0].GetComponent<UnityEngine.UI.Button>().Select();
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
                    SceneManager.LoadScene("Scenes/Game");
                    break;
                case 1:
                    GameObject.Find("soundscript").GetComponent<PlaySound>().playClip();
                    SceneManager.LoadScene("Scenes/MusicSelection");
                    break;
            }
        }
        lastPress += Time.deltaTime;
        if (lastPress > 0.1 && (
            Input.GetAxis("Horizontal") < -0.5 ||
            Input.GetKey(KeyCode.LeftArrow)))
        {
            lastPress = 0;
            menuPosition -= 1;
            if (menuPosition < 0)
            {
                menuPosition = 0;
            }
            changeSelect = true;
        }
        else if (lastPress > 0.1 && (
            Input.GetAxis("Horizontal") > 0.5 ||
            Input.GetKey(KeyCode.RightArrow)))
        {
            menuPosition = Mathf.Min(menuPosition + 1, MenuButtons.Count-1);
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
