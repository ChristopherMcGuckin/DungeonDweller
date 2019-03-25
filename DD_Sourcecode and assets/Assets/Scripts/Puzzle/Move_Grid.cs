using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Grid : MonoBehaviour {


    Vector3 currentPos;
   
	// Use this for initialization
	void Start () {
        currentPos = this.transform.position;

    }
	
	// Update is called once per frame
	void Update () {


        //Gets the world position of the mouse on the screen        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            //If we've pressed down on the mouse (or touched on the iphone)
            if (Input.GetButton("Fire1"))
            {
                //Set the position to the mouse position
                this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                                      0.0f);
            }
        

    }
}
