using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
   
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        isGrounded=true;
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        isGrounded=false;    
    }

    void Update () {

        if(Input.GetKeyDown("p")){

		    if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                AudioListener.volume = 0;

		    } else if(Time.timeScale == 0) 
            {   
			    Time.timeScale = 1; 
                AudioListener.volume = 1;	
		    }
        }
        if(Input.GetKeyDown("m"))
        {
             if(AudioListener.volume == 1)
            {
                AudioListener.volume = 0;

		    } else if(AudioListener.volume == 0) 
            {   
                AudioListener.volume = 1;	
		    }
        } 

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }      
    }
}