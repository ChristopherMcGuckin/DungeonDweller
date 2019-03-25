using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Platform : MonoBehaviour {

    public Vector2 movement = new Vector2(0,2);
    public bool activate = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // GetComponent<Rigidbody2D>().velocity = new Vector2(movement.x, movement.y);
        if(activate ==true)
        transform.Translate(movement.x * Time.deltaTime, movement.y * Time.deltaTime, 0);

    }

    void OnTriggerEnter2D(Collider2D other)
    {       
 
        if (other.gameObject.tag == "Turn")
        {
            movement.x = -movement.x;
            movement.y = -movement.y;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(this.transform);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }
}
