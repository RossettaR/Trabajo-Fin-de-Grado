using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class JumpDamageRino : MonoBehaviour
{
    public Collider2D collider2D;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public GameObject destroyParticle;

    public float jumpForce=2.5f;

    public int lifes=2;

    public AudioSource clip;

    public AudioSource clipKill;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity=(Vector2.up*jumpForce);
            LooseLifeAndHit();
            CheckLife();
        }
    }
    public void LooseLifeAndHit()
    {
        lifes--;
        clip.Play();
        animator.Play("Hit");
    }
    public void CheckLife()
    {
        if (lifes==0)
        {
            destroyParticle.SetActive(true);
            spriteRenderer.enabled=false;
            clipKill.Play();
            Invoke("EnemyDie",0.8f);
        }
        
    }


    public void EnemyDie()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Congratulations");
    }
    
}
