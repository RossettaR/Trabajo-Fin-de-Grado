using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitsManager : MonoBehaviour
{
   


    public Text fruitsCollected;

    private int totalFruitsInLevel;

    private void Start ()
    {
        totalFruitsInLevel=transform.childCount;
    }

    private void Update() {
        {
            AllFruitsCollected();
            
            fruitsCollected.text=((totalFruitsInLevel-transform.childCount)*100).ToString();
          
        }
    }

    public void AllFruitsCollected()
    {
        if (transform.childCount==0)
        {
            Debug.Log("");
        }
    }
   
}
