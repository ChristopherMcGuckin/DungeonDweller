using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_SetUp : MonoBehaviour {

    public GameObject[] Menus;
	// Use this for initialization
	void Start () {
       // Menus = new GameObject[4];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Options()
    {
        Menus[0].SetActive(false);
        Menus[1].SetActive(true);
    }

    public void Credits()
    {
        Menus[0].SetActive(false);
        Menus[2].SetActive(true);
    }

    public void Back()
    {
        Menus[0].SetActive(true);
        Menus[1].SetActive(false);
        Menus[2].SetActive(false);
    }

    public void Play()
    {
        Application.LoadLevel(1);
        
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }


    public void Reset()
    {
        Time.timeScale = 1;
        Application.LoadLevel(1);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Menus[0].SetActive(false);
        Menus[1].SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        Menus[0].SetActive(true);
        Menus[1].SetActive(false);
    }

    public void UpGradeExit()
    {
        FindObjectOfType<Player_Movement>().canMove = true;
        Menus[0].SetActive(true);
        Menus[3].SetActive(false);
        Menus[4].SetActive(true);
       
    }


}
