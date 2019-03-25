using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour {

    public int CoinsCollected, PiecesCollected;
    GameManager gm;
    Player_SFX Sfx;
    AudioSource ASource;

    // Use this for initialization
    void Start () {
        gm = GameObject.FindObjectOfType<GameManager>();
        ASource = GetComponent<AudioSource>();
        Sfx = GetComponent<Player_SFX>();

        //set the veriables that are kept in the game manager when this script is reloaded 
        gm.hints = 0;
        gm.coins = 1000;
        gm.pieces = 0;
        gm.currentALevel = 0;
        gm.currentHLevel = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            CoinsCollected++;
            ASource.clip = Sfx.SFX[1];
            ASource.Play();
            gm.coins++;
        }
        if(other.gameObject.tag == "Piece")
        {
            Destroy(other.gameObject);
            PiecesCollected++;
            ASource.clip = Sfx.SFX[3];
            ASource.Play();
            gm.pieces++;
        }
    }
}
