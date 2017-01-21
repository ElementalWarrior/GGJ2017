﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComposerColor : MonoBehaviour {
public Sprite Composer_Blue; 
public Sprite Composer_Red; 
public Sprite Composer_Yellow; 
public Sprite Composer_Green; 

private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {

        Composer_Blue = Resources.Load<Sprite>("Composer_Blue");
        Composer_Red =  Resources.Load<Sprite>("Composer_Red"); 
        Composer_Yellow = Resources.Load<Sprite>("Composer_Yellow"); 
        Composer_Green = Resources.Load<Sprite>("Composer_Green");

		spriteRenderer = GetComponent<SpriteRenderer>(); 
		//access the SpriteRenderer attached to object 
		if (spriteRenderer.sprite == null){
			spriteRenderer.sprite = Composer_Blue; 
		}
	
	}

	// Update is called once per frame
	void Update ()
	 {
		 if(Input.GetKeyUp(KeyCode.Space))
        {
           ChangeSprite (); 
        } 
     
	}

	void ChangeSprite ()
	{
		if (spriteRenderer.sprite == Composer_Blue)
		{
			spriteRenderer.sprite = Composer_Red;
		} else if (spriteRenderer.sprite == Composer_Red)
		{
			spriteRenderer.sprite = Composer_Yellow; 
		} else if (spriteRenderer.sprite == Composer_Yellow)
		{
			spriteRenderer.sprite = Composer_Green;
		} else 
		{
			spriteRenderer.sprite = Composer_Blue; 
		}

	}
}
