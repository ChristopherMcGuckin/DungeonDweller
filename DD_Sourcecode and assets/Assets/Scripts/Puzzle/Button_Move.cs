using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void moveHorint( int dir)
    {
        transform.position = new Vector2(transform.position.x + dir, transform.position.y);
    }

    public void MoveVer(int dir)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y+dir);
    }
}
