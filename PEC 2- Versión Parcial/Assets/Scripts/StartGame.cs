using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    string str = "You can Control the Game: \n\n- MOVEMENT: 'Arrows' \n\n- JUMP: 'space' \n\n- PAUSE: 'p' \n\n- EXIT: 'Esc'";
    public Text texto;

   
    void Start()
    {
        StartCoroutine (Write());
    }

    IEnumerator Write()
    {
        foreach (char character in str)
        {
            texto.text = texto.text + character;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("Level");
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

}
