using UnityEngine;
using System.Collections;

public class Attack_Points : MonoBehaviour {

    //Used to set the damage the the players' sword does

    public float Damage;
    public int level = 0;
    public bool UpdateAttack = false;
    void Start () {
        Damage = 1.0f;
	}
	

	void Update () {
	
        if(UpdateAttack)
        {
            if(level == 1)
            {
                Damage = 1.25f;
            }else if(level == 2)
            {
                Damage = 1.5f;
            }
            else if (level == 3)
            {
                Damage = 1.75f;
            }
            else if (level == 4)
            {
                Damage = 2f;
            }
            else if (level == 5)
            {
                Damage = 2.25f;
            }
            else if (level == 6)
            {
                Damage = 2.5f;
            }
            else if (level == 7)
            {
                Damage = 2.75f;
            }
            else if (level == 8)
            {
                Damage = 3f;
            }
            UpdateAttack = false;
        }

	}
}
