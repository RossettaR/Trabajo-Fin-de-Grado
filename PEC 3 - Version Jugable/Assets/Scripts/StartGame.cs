using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartGame : MonoBehaviour
{
    string str = "You can Control the Game: \n\n- MOVEMENT: 'Arrows' \n\n- JUMP: 'Space' \n\n- ATTACK: 'Jump on Top' \n\n- PAUSE: 'p' \n\n- EXIT: 'Esc'";
    public Text texto;
    public AudioSource clip;

   
    void Start()
    {
        StartCoroutine (Write());
        clip.Play();
    }

    IEnumerator Write()
    {
        foreach (char character in str)
        {
            texto.text = texto.text + character;
            yield return new WaitForSeconds(0.03f);
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
