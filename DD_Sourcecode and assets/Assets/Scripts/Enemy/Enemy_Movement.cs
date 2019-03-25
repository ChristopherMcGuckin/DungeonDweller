using UnityEngine;
using System.Collections;

public class Enemy_Movement : MonoBehaviour {

    public int speed;
    bool turn, ground, ground2;
 [HideInInspector] public bool canTurn = true, canMove = true;
    int dis = 3;


    void Awake()
    {
        //Removes the (Clone) from the end of the spawned enemy's name
        transform.name = name.Replace("(Clone)", "").Trim();
    }

	void Start () {

    
    }
	

	void Update () {
        if (canMove == true)
        {
            Move();

            if (turn == true && canTurn == true)
            {
                StartCoroutine(CantTurn());
                dis = -dis;
                speed = -speed;
            }

            if (GetComponent<Rigidbody2D>().velocity.x >= 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
        }
        
        RayCast();
	}

    //have a cooldown before being able to turn again
    IEnumerator CantTurn()
    {
        canTurn = false;
        yield return new WaitForSeconds(0.5f);
        canTurn = true;
    }

    void Move()
    {
        //turns the creature when one of the feet are off the ledge
        if (ground == false || ground2 == false)
            turn = true;

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0f);
    }

    void RayCast()
    {
        //finding the wall to turn
        Debug.DrawLine(transform.position, new Vector3(transform.position.x + dis, transform.position.y, transform.position.z), Color.cyan);
       turn = Physics2D.Linecast(transform.position, new Vector3(transform.position.x + dis, transform.position.y, transform.position.z), 1 << LayerMask.NameToLayer("Ground"));

        //Checks the creatures feet and if they are walking off a ledge turn them
        Debug.DrawLine(new Vector3(transform.position.x + .5f, transform.position.y, transform.position.z), new Vector3(transform.position.x + .5f, transform.position.y -2f, transform.position.z), Color.red);
        ground = Physics2D.Linecast(new Vector3(transform.position.x + .5f, transform.position.y, transform.position.z), new Vector3(transform.position.x + .5f, transform.position.y - 2f, transform.position.z), 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(new Vector3(transform.position.x - .5f, transform.position.y, transform.position.z), new Vector3(transform.position.x - .5f, transform.position.y - 2f, transform.position.z), Color.red);
        ground2 = Physics2D.Linecast(new Vector3(transform.position.x - .5f, transform.position.y, transform.position.z), new Vector3(transform.position.x - .5f, transform.position.y - 2f, transform.position.z), 1 << LayerMask.NameToLayer("Ground"));
    }

}
