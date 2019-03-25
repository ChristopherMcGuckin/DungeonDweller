using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swap_piece : MonoBehaviour {

    public GameObject Pice, Pice2, Pice3, Pice4, Pice5, Pice6;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    
    public void swap()
    {
        Debug.Log("SWAP");
        Pice.SetActive(true);
        Pice2.SetActive(false);
        Pice3.SetActive(false);
        Pice4.SetActive(false);
        Pice5.SetActive(false);
        Pice6.SetActive(false);
    }

    public void swap2()
    {
        Debug.Log("SWAP");
        Pice.SetActive(false);
        Pice2.SetActive(true);
        Pice3.SetActive(false);
        Pice4.SetActive(false);
        Pice5.SetActive(false);
        Pice6.SetActive(false);
    }
    public void swap3()
    {
        Debug.Log("SWAP");
        Pice.SetActive(false);
        Pice2.SetActive(false);
        Pice3.SetActive(true);
        Pice4.SetActive(false);
        Pice5.SetActive(false);
        Pice6.SetActive(false);
    }
    public void swap4()
    {
        Debug.Log("SWAP");
        Pice.SetActive(false);
        Pice2.SetActive(false);
        Pice3.SetActive(false);
        Pice4.SetActive(true);
        Pice5.SetActive(false);
        Pice6.SetActive(false);
    }
    public void swap5()
    {
        Debug.Log("SWAP");
        Pice.SetActive(false);
        Pice2.SetActive(false);
        Pice3.SetActive(false);
        Pice4.SetActive(false);
        Pice5.SetActive(true);
        Pice6.SetActive(false);
    }
    public void swap6()
    {
        Debug.Log("SWAP");
        Pice.SetActive(false);
        Pice2.SetActive(false);
        Pice3.SetActive(false);
        Pice4.SetActive(false);
        Pice5.SetActive(false);
        Pice6.SetActive(true);
    }

}
