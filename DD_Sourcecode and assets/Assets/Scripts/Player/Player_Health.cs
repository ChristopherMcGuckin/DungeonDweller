using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour {

    public float health, maxHealth;
    float damageDone;

    bool canHurt = true;
    int throwIt;
    float dir;
    bool playerDir;
    [HideInInspector]  public bool hasDied = false;
    public int level = 0;
    public GameObject menu, normal;
    Player_SFX Sfx;
    AudioSource ASource;
    [HideInInspector]  public bool UpdateHealth = true, GainedHealth = true;
    [HideInInspector]  public bool ChangeHealth = false;
    Animator anime;
    void Start () {
        ASource = GetComponent<AudioSource>();
        Sfx = GetComponent<Player_SFX>();
        anime = GetComponent<Animator>();

        health = maxHealth;
        

    }


	void Update () {

        if(dir< 0)
        {
            throwIt = 200;
        }
        else
        {
            throwIt = -200;
        }

        if (health <= 0 && hasDied == false)
        {
            
            Dead();
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if(ChangeHealth)
        if (level == 1)
        {
            maxHealth = 3.5f;
                health = maxHealth;
        } else if (level == 2)
        {
            maxHealth = 4f;
                health = maxHealth;
            } else if (level == 3)
        {
            maxHealth = 4.5f;
                health = maxHealth;
            } else if (level == 4)
        {
            maxHealth = 5f;
                health = maxHealth;
            } else if (level == 5)
        {
            maxHealth = 5.5f;
                health = maxHealth;
            } else if (level == 6)
        {
            maxHealth = 6f;
                health = maxHealth;
            }
        ChangeHealth = false;

	}

    IEnumerator Hurt()
    {
        GetComponent<Player_Movement>().canMove = false;
        ASource.clip = Sfx.SFX[2];
        ASource.Play();
        health -= damageDone;
        UpdateHealth = true;
        Physics2D.IgnoreLayerCollision(9, 11, true);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(throwIt, 400)); 
        StartCoroutine(flash());
        yield return new WaitForSeconds(.75f);
        Physics2D.IgnoreLayerCollision(9, 11, false);
        GetComponent<Player_Movement>().canMove = true;
        canHurt = true;
    }

    IEnumerator flash()
    {
        GetComponent<SpriteRenderer>().color = Color.clear;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = Color.clear;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = Color.clear;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }



    void OnCollisionEnter2D(Collision2D other)
    {
     
        switch (other.gameObject.tag)
        {
            case "Enemy":
                //check which direction the player was hit from
                dir = gameObject.transform.position.x - other.gameObject.transform.position.x;
                if (canHurt == true)
                {
                    canHurt = false;
                    damageDone = other.gameObject.GetComponent<Enemy_Attack>().power;
                    StartCoroutine(Hurt());
                }
                break;
            case "Spike":
                dir = gameObject.transform.position.x - other.gameObject.transform.position.x;
                if (canHurt == true)
                {
                    canHurt = false;
                    damageDone = 0.5f;
                    StartCoroutine(Hurt());
                }
               
                
                break;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Fire":
                dir = gameObject.transform.position.x - other.gameObject.transform.position.x;
                if (canHurt == true)
                {
                    canHurt = false;
                    damageDone = 1f;
                    StartCoroutine(Hurt());
                    Destroy(other.gameObject);
                }
                break;
            case "Dead":
                {
                    damageDone = maxHealth;
                    StartCoroutine(Hurt());
                    Dead();
                }
                break;
        }
    }

      void Dead()
    {
        hasDied = true;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(50f, 50f));
        anime.SetBool("Die", true);
        Debug.Log("Player has died");
        menu.SetActive(true);
        normal.SetActive(false);
    }


}
