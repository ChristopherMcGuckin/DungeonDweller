using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public Text ItemLeft; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Sword")
        {
            if(other.GetComponentInParent<Collection>().PiecesCollected == 6)
            {
                Application.LoadLevel(2);
            }
            else
            {
                int iLeft = 6 - other.GetComponentInParent<Collection>().PiecesCollected;
                StartCoroutine(ShowText(iLeft));
            }
        }
    }

    IEnumerator ShowText(int iLeft)
    {
        ItemLeft.text = ("You require " + iLeft + " pieces to continue");
        yield return new WaitForSeconds(1);
        ItemLeft.text = (" ");

    }
}
