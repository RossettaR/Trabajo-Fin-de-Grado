using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitsManager : MonoBehaviour
{
   

    public Text fruitsCollected;

    public int totalFruitsInLevel;

   
    
    private void Start ()
    {
        totalFruitsInLevel=transform.childCount;

    }

    private void Update() 
    {
         
         AllFruitsCollected();
        fruitsCollected.text=(totalFruitsInLevel-transform.childCount).ToString();
        PlayerPrefs.SetString("point",fruitsCollected.text); 
    }

    public void AllFruitsCollected()
    {
        if (transform.childCount==0)
        {
            Debug.Log("");
        }
    }

    
   
}
