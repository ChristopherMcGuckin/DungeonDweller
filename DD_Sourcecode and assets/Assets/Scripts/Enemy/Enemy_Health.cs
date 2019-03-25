using UnityEngine;
using System.Collections;

public class Enemy_Health : MonoBehaviour {

    public float health;
    int CoinDrop;
    float dir;
    Animator anime;
   public  GameObject play;
    bool canHurt = true;
    bool doit = true;
    int across;
    float facing;
    public GameObject coins;

    void Start () {
        anime = GetComponent<Animator>();

        SetHealth();
        play = GameObject.FindGameObjectWithTag("Player");


    }
	

	void FixedUpdate () {

        dir = gameObject.transform.position.x - play.transform.position.x;
       

        if (dir < 0)
        {
            across = -2000;
        }
        else if(dir >= 0)
        {
            across = 2000;
        }

        if (health <= 0 && doit == true)
            StartCoroutine(Death());

    
    }

    void SetHealth()
    {
        if(gameObject.name == "Larry")
        {
            health = 4;
            CoinDrop = 3;
        }
        else if(gameObject.name == "Curly")
        {
            health = 7;
            CoinDrop = 5;
        }
        else
        {
            health = 2;
            CoinDrop = 1;
        }
    }

    IEnumerator Death()
    {
        doit = false;

        Itemthrow();

        Destroy(GetComponent<Enemy_Movement>());
        Destroy(GetComponent<Rigidbody2D>());
        anime.SetTrigger("Dead");
     
        yield return new WaitForSeconds(0.45f);
        Physics2D.IgnoreLayerCollision(9, 11, false);
       
        Destroy(this.gameObject);
    }

    IEnumerator throwBack()
    {

        canHurt = false;
        GetComponent<Enemy_Movement>().canMove = false;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(across, 1000f));
        StartCoroutine(flash());
        Physics2D.IgnoreLayerCollision(9, 11, true);
        yield return new WaitForSeconds(0.75f);
        Physics2D.IgnoreLayerCollision(9, 11, false);
        GetComponent<Enemy_Movement>().canMove = true;
        canHurt = true;
 

    }

    void Itemthrow()
    {
            float up, across;
        Debug.Log(CoinDrop);
            for (int i = 0; i < CoinDrop; i++)
            {
                Debug.Log(i);
                up = Random.Range((7.0f), (7.0f));
                across = Random.Range((-5.0f), (5.0f));
                GameObject clone = (GameObject)Instantiate(coins, new Vector2(transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
                clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(across, up));

        }
    }

        IEnumerator flash()
    {
        GetComponent<SpriteRenderer>().color =  Color.clear;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.name == "Sword" && canHurt == true  && health > 0 )
        {
           
            health -= other.GetComponent<Attack_Points>().Damage;
            StartCoroutine(throwBack());

        }
    }

}
