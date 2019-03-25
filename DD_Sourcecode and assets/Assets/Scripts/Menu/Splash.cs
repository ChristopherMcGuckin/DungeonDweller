using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Splash : MonoBehaviour {

   public Image SplashS;
    public GameObject Can;
    public AudioSource As;
    public AudioClip menuTheme,splashTheme;
 
    void Awake()
    {
        As.clip = splashTheme;
        As.Play();
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
        for (int i = 0; i < 10; i++)
        {
            SplashS.color += new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.25f);
        }
        yield return new WaitForSeconds(1.5f);
        for (int r = 0; r < 10; r++)
        {
            SplashS.color += new Color(0, 0, 0, -0.1f);
            yield return new WaitForSeconds(0.25f);
        }
        Can.SetActive(false);
        As.clip = menuTheme;
        As.Play();

    }
}
