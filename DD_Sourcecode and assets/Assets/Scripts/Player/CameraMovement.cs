using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    //Change fields when level is completed 
    [SerializeField]
    private float xMax;

    [SerializeField]
    private float yMax;

    [SerializeField]
    private float xMin;

    [SerializeField]
    private float yMin;

    private Transform player;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, xMin, xMax), Mathf.Clamp(player.position.y, yMin, yMax), transform.position.z);
	}
}
