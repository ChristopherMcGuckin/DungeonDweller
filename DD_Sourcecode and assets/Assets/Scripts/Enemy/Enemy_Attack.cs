using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour {

    public float power;
    string Cname;
	// Use this for initialization
	void Start () {

        Cname = gameObject.name;
        switch (Cname)
        {
            case "Larry":
                power = 1.5f;
                
                break;
            case "Curly":
                power = 2.5f;
                break;
            case "Moe":
                power = 1f;
                break;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionenter2D(Collision2D other)
    {
    }
}
