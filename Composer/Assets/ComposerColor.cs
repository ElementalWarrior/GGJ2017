using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComposerColor : MonoBehaviour
{
    public Sprite Composer_Blue;
    public Sprite Composer_Red;
    public Sprite Composer_Yellow;
    public Sprite Composer_Green;

    private SpriteRenderer spriteRenderer;
    // Use this for initialization
    public GameManager.NoteColor CurrentColor = GameManager.NoteColor.Blue;
    void Start()
    {

        Composer_Blue = Resources.Load<Sprite>("Composer_Blue");
        Composer_Red = Resources.Load<Sprite>("Composer_Red");
        Composer_Yellow = Resources.Load<Sprite>("Composer_Yellow");
        Composer_Green = Resources.Load<Sprite>("Composer_Green");

        spriteRenderer = GetComponent<SpriteRenderer>();
        //access the SpriteRenderer attached to object 
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = Composer_Blue;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetButton("Blue"))
        {
            CurrentColor = GameManager.NoteColor.Blue;
            spriteRenderer.sprite = Composer_Blue;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetButton("Red"))
        {
            spriteRenderer.sprite = Composer_Red;
            CurrentColor = GameManager.NoteColor.Red;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetButton("Yellow"))
        {
            spriteRenderer.sprite = Composer_Yellow;
            CurrentColor = GameManager.NoteColor.Yellow;
        }
        else if (Input.GetKeyDown(KeyCode.F) || Input.GetButton("Green"))
        {
            spriteRenderer.sprite = Composer_Green;
            CurrentColor = GameManager.NoteColor.Green;
        }
        else
        {

        }
    }
}
