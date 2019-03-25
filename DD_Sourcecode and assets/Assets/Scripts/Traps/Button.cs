using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public bool Active = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y -0.1f);
            Active = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }


    }
}
