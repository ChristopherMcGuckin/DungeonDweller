using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

    bool canChange = true;
	// Use this for initialization
	void Start () {
        StartCoroutine(Wait());
	}
	
	// Update is called once per frame
	void Update () {

        if (canChange == true && GetComponent<Rigidbody2D>().velocity.y > 0)
        {
                canChange = false;
                transform.Rotate(-180, 0, 0);
        }

        if(GetComponent<Rigidbody2D>().velocity.y < 0 && canChange == false)
        {
            canChange = true;
            transform.Rotate(-180, 0, 0);
        }
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            StartCoroutine(Burn());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.01f);
        GetComponent<BoxCollider2D>().enabled = true;
    }
    IEnumerator Burn()
    {
        GetComponent<Rigidbody2D>().isKinematic =true;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().SetBool("Burn", true);
        yield return new WaitForSeconds(0.56f);
        Destroy(this.gameObject);
    }
}
