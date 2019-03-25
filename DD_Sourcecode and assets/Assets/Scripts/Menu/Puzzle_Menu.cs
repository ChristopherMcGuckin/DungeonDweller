using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
public class Puzzle_Menu : MonoBehaviour {

    GameManager gm;
    int hintShown = 0;
    public GameObject hint1, hint2, hint3,hint4,hint5,hint6, HintScreen;
    public GameObject Puzz;
    public int NumHints;
	// Use this for initialization
	void Start () {
        gm = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void close()
    {
        hint1.SetActive(false);
        hint2.SetActive(false);
        hint3.SetActive(false);
        hint4.SetActive(false);
        hint5.SetActive(false);
        hint6.SetActive(false);
        HintScreen.SetActive(false);
        Puzz.SetActive(true);
    }
    public void Hint()
    {
      if(gm.hints > 0 && hintShown < 6)
        {
            HintScreen.SetActive(true);
            Puzz.SetActive(false);
            NumHints++;
            if (hintShown == 0)
            {
                hint1.SetActive(true);
                hintShown++;
                gm.hints--;
            } else if (hintShown == 1)
            {
                hint2.SetActive(true);
                hintShown++;
                gm.hints--;
            } else if (hintShown == 2)
            {
                hint3.SetActive(true);
                hintShown++;
            }
            else if (hintShown == 3)
            {
                hint4.SetActive(true);
                hintShown++;
                gm.hints--;
            }
            else if (hintShown == 4)
            {
                hint5.SetActive(true);
                hintShown++;
                gm.hints--;
            } else if(hintShown == 5)
            {
                hint6.SetActive(true);
                hintShown++;
                gm.hints--;
            }

        }
    }

    public void Next()
    {
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
        {
            { "Hints used", NumHints },
            { "Coins remaining", gm.coins }           
        });
        Application.LoadLevel(3);
    }
}
