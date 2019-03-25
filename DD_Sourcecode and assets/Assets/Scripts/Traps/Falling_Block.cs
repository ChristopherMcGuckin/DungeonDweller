using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Block : MonoBehaviour {

    public Vector3 StartPos;
    bool canHide, canFall = true;
    SpriteRenderer Spr;
    BoxCollider2D BxC;
    Rigidbody2D Rb2;
    public bool JustFall;
    void Awake()
    {
        StartPos = transform.parent.GetComponent<Transform>().position;

    }
	// Use this for initialization
	void Start () {
        Spr = GetComponent<SpriteRenderer>();
        BxC = transform.parent.GetComponent<BoxCollider2D>();
        Rb2 = transform.parent.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartFall()
    {
        StartCoroutine("Shake");

        canHide = true;
    }

    void ReturnPos()
    {
        canFall = false;
        StartCoroutine(FlashIn());
        canFall = true;
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(0.5f);
        Spr.enabled = false;
        BxC.enabled = false;
        transform.parent.GetComponent<Transform>().position = StartPos;
    }


    IEnumerator FlashIn()
    {
        yield return new WaitForSeconds(2);
        Spr.enabled = true;
        yield return new WaitForSeconds(0.1f);
        Spr.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Spr.enabled = true;
        yield return new WaitForSeconds(0.1f);
        Spr.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Spr.enabled = true;
        yield return new WaitForSeconds(0.1f);
        Spr.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Spr.enabled = true;
        BxC.enabled = true;

    }

    IEnumerator Shake()
    {

        transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
        yield return new WaitForSeconds(.5f);
        Rb2.bodyType = RigidbodyType2D.Dynamic;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && canFall == true)
        {
            Debug.Log("Player");
            StartFall();
            canHide = true;
           
        }
        if(other.gameObject.layer == 8 && canHide == true)
        {
            Debug.Log("Ground");
            canFall = false;
            Rb2.bodyType = RigidbodyType2D.Static;
            StartCoroutine(Hide());
            ReturnPos();


        }
    }
}
