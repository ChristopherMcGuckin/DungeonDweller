using UnityEngine;
using System.Collections;

public class Wall_Line : MonoBehaviour {

    public GameObject objectOne, objectTwo;
    public float pos;
    void Update()
    {
        //attaches ends of the line to the two objects
        GetComponent<LineRenderer>().SetPosition(0, new Vector3(objectOne.transform.position.x, objectOne.transform.position.y + pos, objectOne.transform.position.z));
        GetComponent<LineRenderer>().SetPosition(1, new Vector3(objectTwo.transform.position.x, objectTwo.transform.position.y + pos, objectTwo.transform.position.z));

       

    }
}
