using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

    public bool grounded, grounded2;
    public float JumpHeight = 400,speed, speed2 = 10, maxSpeed = 100;
    Animator anime;
    Rigidbody2D player;
    bool lastDir = true;
   [HideInInspector] public bool canMove = true;

    float hInput = 0;

	void Start ()
    {
        anime = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

  
	void FixedUpdate ()
    {
        RayCasting();
   
        //Allows the player to still be idle when a foot is still on the ledge
        if (grounded || grounded2)
        {
            anime.SetBool("Grounded", true);
        }
        else
        {
            //if no feet are on the ground changes the player to fall
            anime.SetBool("Grounded", false);
        }

        //   Move(Input.GetAxisRaw("Horizontal"));
        if (GetComponent<Player_Health>().hasDied == false)
        {
#if !UNITY_ANDROID
            if (canMove == true)
                Move(Input.GetAxisRaw("Horizontal"));
#else
            if (canMove == true)
                movement(hInput);
#endif
            if (Input.GetKeyDown(KeyCode.L))
                Jump();
        }

    }

    void FaceDir(float Face)
    {

        if (Face > 0)
        {
            //sets which way the player is facing
            lastDir = true;
            //adds speed to build upto the max then clamps it
            speed += 0.9f;
            speed = Mathf.Clamp(speed, 0.0f, maxSpeed);
            //changes the way the player is facing
            transform.eulerAngles = new Vector2(0, 0);
            //  transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (Face < 0)
        {
            lastDir = false;
            speed -= 0.9f;
            speed = Mathf.Clamp(speed, -maxSpeed, 0.0f);
            transform.eulerAngles = new Vector2(0, 180);
            //transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }

    void AnimateRun(float RunDir)
    {
        //animates the player running
        if (RunDir == 0)
        {
            GetComponent<Animator>().SetBool("Run", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Run", true);
        }
    }
    void RayCasting()
    {
        //draws a line so it can be seen on scene view
        //Debug.DrawLine(transform.position, new Vector3((transform.position.x), transform.position.y - 1.5f, transform.position.z), Color.green);

        //draws a line so it can be seen on scene view. Shows both sides of the characters feet
        Debug.DrawLine(new Vector3((transform.position.x + 0.25f), transform.position.y,transform.position.x), new Vector3((transform.position.x + .25f), transform.position.y - 1.25f, transform.position.z), Color.gray);
        Debug.DrawLine(new Vector3((transform.position.x - 0.25f), transform.position.y, transform.position.x), new Vector3((transform.position.x - .25f), transform.position.y - 1.25f, transform.position.z), Color.grey);

        // creates the linecast from the each side of the player to the ground and checks if the layer is ground and returns the bool to grounded and grounded2
		grounded = Physics2D.Linecast(new Vector3((transform.position.x + 0.25f), transform.position.y, transform.position.x), new Vector3((transform.position.x + .25f), transform.position.y - 1.25f, transform.position.z), 1 << LayerMask.NameToLayer("Ground"));
		grounded2 = Physics2D.Linecast(new Vector3((transform.position.x - 0.25f), transform.position.y, transform.position.x), new Vector3((transform.position.x - .25f), transform.position.y - 1.25f, transform.position.z), 1 << LayerMask.NameToLayer("Ground"));
        
        //creates the linecast from the centre of the player to the ground and checks if the layer is ground and returns the bool to grounded
        //grounded = Physics2D.Linecast(transform.position, new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z), 1 << LayerMask.NameToLayer("Ground"));
    }


    

    public void Move(float HorInput)
    {
        FaceDir(HorInput);

        //slows the player down depending on the direction they are going
        if (HorInput == 0)
        {
            if (lastDir == true)
            {
                speed -= 0.5f;
                speed = Mathf.Clamp(speed, 0.0f, maxSpeed);
            }
            else if (lastDir == false)
            {
                speed += 0.5f;
                speed = Mathf.Clamp(speed, -maxSpeed, 0.0f);
            }
        }
        //applies the force to the player
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, player.velocity.y);

        AnimateRun(HorInput);

      

    }

    public void Jump()
    {
        //gets the input and checks if is grounded
        if ((grounded == true || grounded2 == true))
        {
            //sets the current velocity
            GetComponent<Rigidbody2D>().velocity = new Vector2(player.velocity.x, 0.0f);

            //adds the jumpheight force up
            player.AddForce(Vector2.up * JumpHeight);

            //Triggers the jump animation
            anime.SetTrigger("Jump");
        }
    }
    public void StartMove(int speed)
    {
        
        hInput = speed;
    }

    void movement(float HorInput)
    {
        FaceDir(HorInput);
        Vector2 MovV = player.velocity;
        MovV.x = HorInput * speed2;
        player.velocity = MovV;
        AnimateRun(HorInput);
    }


}
