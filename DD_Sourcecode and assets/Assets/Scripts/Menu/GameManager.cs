using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour {
    public GameObject splash;
    public int hints;
    public int coins;
    public int pieces;

    public int maxALevel = 8;
    public int currentALevel;
    public int maxHLevel = 6;
    public int currentHLevel;

    public bool hasLoaded = false; 
    void Awake()
    {

        Application.DontDestroyOnLoad(this.gameObject);
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        splash.SetActive(true);


    }
	void Start () {
      
    }
	
	
	void Update () {
		if(Input.GetKeyUp(KeyCode.R))
        {
            Application.LoadLevel(0);
        }
	}
}
