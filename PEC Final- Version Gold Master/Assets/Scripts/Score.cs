using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    public Text totalScore;

    void Update()
    {

        totalScore.text = PlayerPrefs.GetString("point").ToString(); 

    }


}

