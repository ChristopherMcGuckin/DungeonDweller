using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine;

public class Chest : MonoBehaviour {

    public GameObject coins;
    public GameObject puzzle;
    public Sprite open;
     float across, up;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Itemthrow()
    {
        for(int i = 0; i< 6; i++)
        {

             up = Random.Range((7.0f), (7.0f));
             across = Random.Range((-5.0f), (5.0f));
            Debug.Log(up + " Up");
            Debug.Log(across + " Across");
            GameObject clone = (GameObject)Instantiate(coins, new Vector2(transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
            clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(across, up));
        }
         up = Random.Range((7.0f), (7.0f));
         across = Random.Range((-15.0f), (15.0f));
        GameObject clone2 = (GameObject)Instantiate(puzzle, new Vector2(transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
        clone2.GetComponent<Rigidbody2D>().AddForce(new Vector2(across, up));

        GetComponent<BoxCollider2D>().enabled = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Sword")
        {
            Itemthrow ();
            GetComponent<SpriteRenderer>().sprite = open;
        }
    }
}
