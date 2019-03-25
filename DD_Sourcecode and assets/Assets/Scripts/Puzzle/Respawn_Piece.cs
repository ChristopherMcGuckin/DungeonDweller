using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Piece : MonoBehaviour {

    public Transform newpos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Spike" || other.gameObject.tag == "Dead")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.position = newpos.position;
        }
    }
}
