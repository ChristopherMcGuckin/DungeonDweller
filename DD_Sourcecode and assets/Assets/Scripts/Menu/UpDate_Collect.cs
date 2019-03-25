using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDate_Collect : MonoBehaviour {

    public GameObject Coin, Hint, Piece;
    GameManager gm;
	// Use this for initialization
	void Start () {

        gm = GameObject.FindObjectOfType<GameManager>();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if(Coin != null)
        Coin.GetComponent<Text>().text = ("Coin " + gm.coins);
        if(Piece !=null)
        Piece.GetComponent<Text>().text = ("Pieces " + gm.pieces);
        if (Hint != null)
            Hint.GetComponent<Text>().text = ("Hint " + gm.hints);

	}
}
