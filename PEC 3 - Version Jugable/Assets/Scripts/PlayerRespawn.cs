using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject [] hearts;

    private int life;
    
    public Animator animator;

    public AudioSource clip;

    public AudioSource clipTouch;


    void Start()
    {
        life=hearts.Length;
    }

    private void CheckLife() 
    {
        if (life<1)
        {
            Destroy(hearts[0].gameObject);
            clip.Play();
            animator.Play("WilliamHurt");
            StartCoroutine (WaitToLoadScene());
        }
        else if (life<2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("WilliamTouch");
            clipTouch.Play();
        }
        else if (life<3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("WilliamTouch");
            clipTouch.Play();
        }
    }

      public void PlayerDamaged ()
    {
        life--;
        CheckLife();
    }

    IEnumerator WaitToLoadScene () 
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");
    }


}
