using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CongratulationsGame : MonoBehaviour
{
   
    void Update()
    {
        StartCoroutine (WaitToLoadScene());
    }
        
    IEnumerator WaitToLoadScene () 
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Credits");
    } 
}

