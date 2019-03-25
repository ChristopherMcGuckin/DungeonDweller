using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    [System.Serializable]
    public class EnemyType
    {
        public int Enemy = 1;
        public GameObject Small, Medium, Big;
    }
    public EnemyType Type;
    GameObject creature;

	// Use this for initialization
	void Start () {

        //Adds the creature to the scene
        Add();
        //Destroys the spawner
        Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Add()
    {
        //depending on the number input on the inspector it will spawn the correct creature
        if (Type.Enemy == 3)
        {
            creature = (GameObject)Instantiate(Type.Big, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        
        }
        else if (Type.Enemy == 2)
        {
            creature = (GameObject)Instantiate(Type.Medium, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
 
        }
        else
        {
            creature = (GameObject)Instantiate(Type.Small, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
           
        }
    }
}
