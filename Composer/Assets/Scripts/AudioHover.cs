using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHover : MonoBehaviour {
    public AudioSource sourceInfinite;
    public AudioClip hoverInfinite;

    //public AudioSource sourceEasy;
    //public AudioClip hoverEasy;

    //public AudioSource sourceMedium;
    //public AudioClip hoverMedium;

    //public AudioSource sourceHard;
    //public AudioClip hoverHard;  

    
	public void onHover()
    {
        if (sourceInfinite.isPlaying == false)
        {

            sourceInfinite.PlayOneShot(hoverInfinite);
        }

        //} else if (sourceEasy.isPlaying == false)
        //{
    
        //    sourceEasy.PlayOneShot(hoverEasy); 
            

        //} else if (sourceMedium.isPlaying == false)
        //{
   
        //    sourceMedium.PlayOneShot(hoverMedium); 

        //} else if (sourceHard.isPlaying == false)
        //{
           
        //    sourceHard.PlayOneShot(hoverHard);
        //}
    }

    public void onExit()
    {
        sourceInfinite.Stop();
  
    }


}
