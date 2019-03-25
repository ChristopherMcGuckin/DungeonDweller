using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Music : MonoBehaviour {

    [System.Serializable]
    public class SFX
    {
        public Sprite On, Off;
        [HideInInspector] public bool gameSFX = true;
    }
    
    [System.Serializable]
    public class Music
    {
        public Sprite On, Off;
        [HideInInspector] public bool gameMusic = true;
    }

    public SFX sfx;
    public Music music;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void mSound()
    {
    
        if(music.gameMusic == true)
        {
            GetComponent<Image>().sprite = music.Off;
            music.gameMusic = false;
           
        }
        else
        {
            GetComponent<Image>().sprite = music.On;
            music.gameMusic = true;
        }
    }

    public void sSound()
    {
        if (sfx.gameSFX == true)
        {
            GetComponent<Image>().sprite = sfx.Off;
            sfx.gameSFX = false;

        }
        else
        {
            GetComponent<Image>().sprite = sfx.On;
            sfx.gameSFX = true;
        }
    }

}

