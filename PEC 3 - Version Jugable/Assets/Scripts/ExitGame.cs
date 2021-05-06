using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
   

    void Update()
    {
 

        if(Input.GetKeyDown(KeyCode.Y)){
            SceneManager.LoadScene("Start");
        }
        if(Input.GetKeyDown(KeyCode.N)){
            Application.Quit();
        }

    }


}
