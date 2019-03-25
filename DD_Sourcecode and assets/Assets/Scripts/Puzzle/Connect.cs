using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviour {


    [System.Serializable]
    public class BoxC
    {
        public GameObject Col_1;
        public GameObject Col_2;
        public GameObject Col_3;
        public GameObject Col_4;
        public GameObject Col_5;
        public GameObject Col_6;
    }

    public bool Connected_1  =false, Connected_2 = false, Connected_3 = false, Connected_4 = false, Connected_5 = false, Connected_6 = false;
    public BoxC CBox;
    public bool Win;
    public GameObject Next;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Connected_1 = CBox.Col_1.GetComponent<Check>().connect;
        Connected_2 = CBox.Col_2.GetComponent<Check>().connect;
        Connected_3 = CBox.Col_3.GetComponent<Check>().connect;
        Connected_4 = CBox.Col_4.GetComponent<Check>().connect;
        Connected_5 = CBox.Col_5.GetComponent<Check>().connect;
        Connected_6 = CBox.Col_6.GetComponent<Check>().connect;

        CheckResults();

        if(Win == true)
        {
            Next.SetActive(true);
        }

    }

    void CheckResults()
    {
        if (Connected_1 == true && Connected_2 == true && Connected_3 == true && Connected_4 == true && Connected_5 == true && Connected_6 == true)
        {
            Win = true;
        }
    }



    
}
