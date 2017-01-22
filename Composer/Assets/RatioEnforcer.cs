using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RatioEnforcer : MonoBehaviour {
    // Use this for initialization
    void Start ()
    {
        ApplicationSettings.Instance();
        //Debug.Log(Name);
        // set the desired aspect ratio (the values in this example are
         // hard-coded for 16:9, but you could make them into public
         // variables instead so you can set them at design time)
        float targetaspect = 16.0f / 9.0f;

        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // obtain camera component so we can modify its viewport
        Camera camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
        
        //Debug.Log(Joysticks[1].Keys);
    }
    Dictionary<int, Dictionary<string, bool>> Joysticks = new Dictionary<int, Dictionary<string, bool>>();
    bool QueryJoystick(int joyNum)
    {
        if (!Joysticks.ContainsKey(joyNum)) {
            Joysticks[joyNum] = new Dictionary<string, bool>();
        }
        int i;
        for (i = 0; i < 40; i++)
        {
            //we'll try to get a joystick button
            try
            {
                string buttonSlug = string.Format("joystick {0} button {1}", joyNum, i);
                Input.GetKey(buttonSlug);
                Debug.Log(buttonSlug);
                Joysticks[joyNum][buttonSlug] = true;
            }
            catch (Exception) //if it throws an exception, then the button doesn't exist
            {
                break;
            }
        }
        if (i == 0)
        {
            return false;
        }
        return true;
    }
	// Update is called once per frame
	void Update () {
		//foreach (string key in Joysticks[1].Keys)
  //      {
  //          if(Input.GetKeyDown(key))
  //          {
  //              Debug.Log(key);
  //          }
  //      }
	}
}
