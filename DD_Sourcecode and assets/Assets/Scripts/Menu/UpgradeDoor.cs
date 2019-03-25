using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDoor : MonoBehaviour {

    public GameObject Normal, Upgrade;

 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HITTTT");
        if (other.gameObject.name == "Sword")
        {
            Debug.Log("HITTTT");
            Normal.SetActive(false);
            Upgrade.SetActive(true);
            other.GetComponentInParent<Player_Movement>().canMove = false;
        
        }
    }
}
