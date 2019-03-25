using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour {

    GameManager gm;
    int Acost = 25 ,Hcost = 30 ,Ccost = 50;
    Attack_Points Ap;
    Player_Health Hp;
	// Use this for initialization
	void Start () {
        gm = GameObject.FindObjectOfType<GameManager>();
        Ap = GameObject.FindObjectOfType<Attack_Points>();
        Hp = GameObject.FindObjectOfType<Player_Health>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AttackUp()
    {
        if(gm.currentALevel < gm.maxALevel && gm.coins >= Acost)
        {
            Ap.UpdateAttack = true;
            Ap.level++;
            gm.currentALevel++;
            gm.coins -= Acost;
        }
    }

    public void HealthUp()
    {
        if (gm.currentHLevel < gm.maxHLevel && gm.coins >= Hcost)
        {
            
            Hp.ChangeHealth = true;
            
            Hp.level++;
           
            gm.currentHLevel++;
            
            Hp.GainedHealth = true;
            Hp.UpdateHealth = true;
            gm.coins -= Hcost;
          
          
        }

    }

    public void UpHint()
    {
        if(gm.coins >= Ccost)
        {
            gm.hints++;
            gm.coins -= Ccost;
        }
    }
}

