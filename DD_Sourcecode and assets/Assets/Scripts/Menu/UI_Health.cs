using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour {

    [System.Serializable]
    public class UIHeart
    {
        [System.Serializable]
        public class IHeart
        {
            public Sprite full, half, empty;
        }
        public IHeart HealImage;
        public GameObject H1, H2, H3, H4, H5, H6;
    }
    public  UIHeart Heart;
    Player_Health Phealth;

    // Use this for initialization
    void Start () {
        Phealth = GameObject.FindObjectOfType<Player_Health>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Phealth.UpdateHealth == true && !(Phealth.health > Phealth.maxHealth))
        {
            HeathSprite();
        }

        if (Phealth.GainedHealth == true)
        {
            if (Phealth.maxHealth > 3 && Phealth.maxHealth <= 4)
            {
                Heart.H4.SetActive(true);

            }
            else if (Phealth.maxHealth > 4 && Phealth.maxHealth <= 5)
            {
                Heart.H5.SetActive(true);
            }
            else if (Phealth.maxHealth > 5 && Phealth.maxHealth <= 6)
            {
                Heart.H6.SetActive(true);
            }
            Phealth.GainedHealth = false;
        }

    }

    void HeathSprite()
    {

        if (Phealth.health == 0.5)
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.half;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.empty;
        }
        else if (Phealth.health == 1)
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.empty;
        }
        else if (Phealth.health == 1.5)
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.half;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.empty;
        }

        else if (Phealth.health == 2)
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.empty;
        }

        else if (Phealth.health == 2.5)
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.half;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.empty;
        }

        else if (Phealth.health == 3)
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.empty;
        }
        else if (Phealth.health == 3.5)
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.half;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.empty;
        }
        else if (Phealth.health == 4)
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.empty;
        }
        else if (Phealth.health == 4.5)
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.half;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.empty;
        }
        else if (Phealth.health == 5)
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.empty;
        }
        else if (Phealth.health == 5.5)
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.half;
        }
        else if (Phealth.health == 6)
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.full;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.full;
        }
        else
        {
            Heart.H1.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H2.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H3.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H4.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H5.GetComponent<Image>().sprite = Heart.HealImage.empty;
            Heart.H6.GetComponent<Image>().sprite = Heart.HealImage.empty;
        }
        Phealth.UpdateHealth = false;
    }
}
