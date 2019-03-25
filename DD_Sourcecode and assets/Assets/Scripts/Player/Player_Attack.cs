using UnityEngine;
using System.Collections;

public class Player_Attack : MonoBehaviour
{

    Animator anime;
    bool canHit = true;
    CircleCollider2D sword;
    Player_SFX Sfx;
    AudioSource ASource;
    // Use this for initialization
    void Start()
    {
        ASource = GetComponent<AudioSource>();
        Sfx = GetComponent<Player_SFX>();
        anime = GetComponent<Animator>();
        sword = transform.GetChild(0).GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }
    }


    public void Attack()
    {
        if (canHit == true)
        {
            if (GetComponent<Player_Movement>().grounded == true)
                anime.SetTrigger("Attack");
            else
                anime.SetTrigger("AirAttack");
            //sword.enabled = true;
            StartCoroutine(attack());
        }

        
    }


    IEnumerator attack()
    {
        yield return new WaitForSeconds(0.15f);
        ASource.clip = Sfx.SFX[0];
        ASource.Play();
        sword.enabled = true;
        canHit = false;
        if (GetComponent<Player_Movement>().grounded == true)
        {
            GetComponent<Player_Movement>().canMove = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Player_Movement>().speed = 0.0f;
        }
        yield return new WaitForSeconds(0.3f);
        sword.enabled = false;
        canHit = true;
        yield return new WaitForSeconds(0.15f);
        canHit = true;
        GetComponent<Player_Movement>().canMove = true;

       

    }
}

