using UnityEngine;
using System.Collections;

public class FireTrap : MonoBehaviour {

    [System.Serializable]
    public class Items
    {
        public GameObject Shot, ShotSide, Button;
    }
    public Items item; 

    [Tooltip("Set correct position before testing")]
    public Transform ShotDist;

    float ShotSpeed = 250;
    bool Isplayer, canFire = true;
    public bool isAuto = false;

    [System.Serializable]
    public class Direction
    {
        public bool up, down, left, right;
    }
    public Direction dir;
	// Use this for initialization
	void Start () {

        FindDir();

    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(transform.position, ShotDist.position, Color.green);
        Isplayer = Physics2D.Linecast(transform.position, ShotDist.position, 1 << LayerMask.NameToLayer("Player"));

        if (isAuto == false)
        {
            if (Isplayer && canFire)
            {
                StartCoroutine(WaitFire());
            }
        }
        else
        {
            if (item.Button.GetComponent<Button>().Active == true && canFire)
            {
                StartCoroutine(WaitFire());
            }
        }
        
    }

    //Changes the position of the shot spawner to account for the directon
    void FindDir()
    {
        if (dir.left == true)
        {
            transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
        }
        else if (dir.down == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 2);
        }
        else if (dir.right == true)
        {
            transform.position = new Vector2(transform.position.x + 1, transform.position.y -1);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }

    }

    IEnumerator WaitFire()
    {
        canFire = false;
        GameObject clone;
        if (dir.down || dir.up)
        {
            if (dir.up)
             clone = (GameObject)Instantiate(item.Shot, transform.position, Quaternion.Euler(new Vector3(0f,0f,0f)));
            else
               clone = (GameObject)Instantiate(item.Shot, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
        }
        else
        {
            if (dir.left)
                clone = (GameObject)Instantiate(item.ShotSide, transform.position, Quaternion.Euler(new Vector3(0f, 0f, -90)));
            else
                clone = (GameObject)Instantiate(item.ShotSide, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 90)));
        }
        //change when working so it can fire up/accross 
        if (dir.left == true)
        {
            clone.GetComponent<Rigidbody2D>().AddForce(Vector2.left * ShotSpeed);
           
        }
        else if (dir.down == true)
        {
            clone.GetComponent<Rigidbody2D>().AddForce(Vector2.down * ShotSpeed);
        }
        else if (dir.right == true)
        {
            clone.GetComponent<Rigidbody2D>().AddForce(Vector2.right * ShotSpeed);
        }
        else
        {
            clone.GetComponent<Rigidbody2D>().AddForce(Vector2.up * ShotSpeed);
        }
        yield return new WaitForSeconds(2.0f);
        canFire = true;
    }
}
