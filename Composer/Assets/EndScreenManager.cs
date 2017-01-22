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
                    SceneManager.LoadScene("Game");
                    break;
                case 1:
                    GameObject.Find("soundscript").GetComponent<PlaySound>().playClip();
                    SceneManager.LoadScene("MusicSelection");
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
        }
        else if (lastPress > 0.1 && (
            Input.GetAxis("Vertical") > 0.5 ||
            Input.GetKey(KeyCode.DownArrow)))
        {
            menuPosition = (menuPosition + 1) % MenuButtons.Count;
            lastPress = 0;
        }

    }
    private void FixedUpdate()
    {

        if (lastMenuPosition != menuPosition)
        {
            //Debug.Log(lastMenuPosition + " " + menuPosition);
            MenuButtons[menuPosition].GetComponent<UnityEngine.UI.Button>().Select();
        }
        lastMenuPosition = menuPosition;
    }
}
