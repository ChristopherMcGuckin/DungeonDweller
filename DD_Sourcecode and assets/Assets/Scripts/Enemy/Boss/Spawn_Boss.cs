using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Boss : MonoBehaviour {

  
	// Use this for initialization
	void Start () {
        StartCoroutine(WaitToSpawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(1.0f);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().mass = 2;
        Destroy(this);
    }
}
