using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMapper : MonoBehaviour {
    Dictionary<string, string> ActionMappings = new Dictionary<string, string>();
    string ListeningForAction = null;
    GameObject SelectedObject = null;
    //public delegate void Up();
    //public delegate void Down();
    //public delegate void Left();
    //public delegate void Right();

    //public delegate void Up();
    //public delegate void Up();
    //public delegate void Up();
    //public delegate void Up();
    private void Start()
    {
        ActionMappings["Up"] = null;
        ActionMappings["Down"] = null;
        ActionMappings["Left"] = null;
        ActionMappings["Right"] = null;

        ActionMappings["Blue"] = null;
        ActionMappings["Red"] = null;
        ActionMappings["Yellow"] = null;
        ActionMappings["Green"] = null;
    }
    private void Update()
    {
        if(ListeningForAction != null)
        {
            string pressedKey = null;
            for(int i = 0; i < 20; i++)
            {
                string buttonSlug = string.Format("joystick button {0}", i);
                if (Input.GetKey(buttonSlug))
                {
                    pressedKey = buttonSlug;
                }
            }
            if(pressedKey != null)
            {

                ActionMappings[ListeningForAction] = pressedKey;
                Debug.Log(string.Format("{0} is mapped to {1}", ListeningForAction, pressedKey));
                ListeningForAction = null;
                SelectedObject.GetComponent<SpriteRenderer>().color = Color.white;
                SelectedObject = null;
            }
        }
        //Resources.Load<GameObject>("Note").GetComponent<MovementHandler>().Speed = 0.1f
    }

    public void MapKey(GameObject obj)
    {
        Debug.Log(string.Format("{0} is listening", obj.name));
        ListeningForAction = obj.name;
        SelectedObject = obj;
        obj.GetComponent<SpriteRenderer>().color = Color.blue;
    }
    private void OnMouseUp()
    {
        MapKey(this.gameObject);
    }
}
