using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    public Image fade;
    public Text TBC;

    public Boss_Entry BE;

    void Awake()
    {
        BE = FindObjectOfType<Boss_Entry>();
    }
	// Use this for initialization
	void Start () {
        StartCoroutine(Fader());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Fader()
    {
        
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 5; i++)
        {           
            fade.color += new Color(0, 0,0, 0.1f);    
            yield return new WaitForSeconds(0.25f);
        }
        TBC.text = "To Be \n\tContinued...";
        yield return new WaitForSeconds(1.5f);
        Application.LoadLevel(0);
    }
}
