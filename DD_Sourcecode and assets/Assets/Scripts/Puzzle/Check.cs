using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {

    public GameObject col;
    public bool connect;
    string colName;
    // Use this for initialization
    void Start () {
        colName = col.gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == colName)
        {
            connect = true;
        }
  
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == colName)
        {
            connect = false;
        }

    }
}
