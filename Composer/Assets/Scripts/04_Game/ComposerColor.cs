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

        Composer_Blue = Resources.Load<Sprite>("Textures/Composer_Blue");
        Composer_Red = Resources.Load<Sprite>("Textures/Composer_Red");
        Composer_Yellow = Resources.Load<Sprite>("Textures/Composer_Yellow");
        Composer_Green = Resources.Load<Sprite>("Textures/Composer_Green");

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
        if (Input.GetButton("Blue"))
        {
            CurrentColor = GameManager.NoteColor.Blue;
            spriteRenderer.sprite = Composer_Blue;
        }
        else if (Input.GetButton("Red"))
        {
            spriteRenderer.sprite = Composer_Red;
            CurrentColor = GameManager.NoteColor.Red;
        }
        else if (Input.GetButton("Yellow"))
        {
            spriteRenderer.sprite = Composer_Yellow;
            CurrentColor = GameManager.NoteColor.Yellow;
        }
        else if (Input.GetButton("Green"))
        {
            spriteRenderer.sprite = Composer_Green;
            CurrentColor = GameManager.NoteColor.Green;
        }
        else
        {

        }
    }
}
