using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject [] hearts;

    private int life;
    
    public Animator animator;


    void Start()
    {
        life=hearts.Length;
    }

    private void CheckLife() 
    {
        if (life<1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("WilliamHurt");
            StartCoroutine (WaitToLoadScene());
        }
        else if (life<2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("WilliamTouch");
        }
        else if (life<3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("WilliamTouch");
            
        }
    }

      public void PlayerDamaged ()
    {
        life--;
        CheckLife();
    }

    IEnumerator WaitToLoadScene () 
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver");
    }


}
