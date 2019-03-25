using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    [Tooltip("Fix in Script to accept the activation of this object")] public GameObject ActiveObject;
    public Sprite On, Off;
    bool canActive = true;
    SpriteRenderer SR;
	// Use this for initialization
	void Start () {
        SR = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Sword" )
        {
            if (canActive == true)
            {
                canActive = false;
                SR.sprite = Off;
                ActiveObject.GetComponent<Move_Platform>().activate = true;
            }
            else if (canActive == false)
            {
                canActive = true;
                SR.sprite = On;
                ActiveObject.GetComponent<Move_Platform>().activate = false;
            }
        }
    }


}
