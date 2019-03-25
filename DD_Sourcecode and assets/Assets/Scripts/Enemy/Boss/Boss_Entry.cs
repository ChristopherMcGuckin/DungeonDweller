using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Entry : MonoBehaviour {

    public bool ground = false;
    public int timesJumped;
    Animator anime;
    AudioSource Asource;
    public Camera cam;

   public FadeOut fade;
    private float ShakeY = 0.8f;
    private float ShakeYSpeed = 0.8f;
    bool canShake = false;
    int i = 0;
    public Transform[] points;
    // Use this for initialization
    void Start () {
        anime = GetComponent<Animator>();
        Asource = GetComponent<AudioSource>();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }
    public void setShake(float someY)
    {
        ShakeY = someY;
    }

    // Update is called once per frame
    void Update () {
      
        if (ground == true && timesJumped < 3)
        {
            //move te poistion more accurate than adding force
            gameObject.transform.position = points[i].position;
            timesJumped++;
        }

        //when the boss is seen on screen it starts the fadeOut scipt
        if (GetComponent<SpriteRenderer>().isVisible == true)
        {
            fade.enabled = true;
        }


        //Creates the camera shake when the boss lands
        if (canShake == true)
        {
            Vector2 _newPosition = new Vector2(0, ShakeY);
            if (ShakeY < 0)
            {
                ShakeY *= ShakeYSpeed;
            }
            ShakeY = -ShakeY;
            cam.transform.Translate(_newPosition, Space.Self);
        }




    }

    IEnumerator JumpAgain()
    {
        anime.SetBool("Ground", true);
        Asource.Play();
        Shake();
        
        yield return new WaitForSeconds(.5f);
        i++;
        ground = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 8)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine(JumpAgain());
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.layer == 8)
        {
            canShake = false;
            anime.SetBool("Ground", false);
            ground = false;
        }

    }

    void Shake()
    {
        //resets the values for the shake 
        ShakeY = 0.8f;
     ShakeYSpeed = 0.8f;
        canShake = true;

    }
}



