using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float speed;
	public float jumpForce;

	public Rigidbody2D rb;

	public bool jump;
	public bool doubleJump;
	public bool onGround;

	public Transform[] groundPoints;
	public LayerMask groundMask;
	public float groundradius;

	public GameObject shootprefab;


	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		onGround = OnGround ();

		PlayerInputs ();


	}

	void FixedUpdate ()
	{
		float moveX = Input.GetAxis ("Horizontal");


		PlayerMovement (moveX);

	}

	void PlayerInputs ()
	{

		if (Input.GetKeyDown (KeyCode.W))
		{
			jump = true;

//			if (jump && !doubleJump)
//			{
//				doubleJump = true;
//				Debug.Log ("DOUBLE JUMP");
//
//			}

		}

		if (Input.GetMouseButtonDown (0))
		{
			Shoot ();
				
		}
	}

	void PlayerMovement (float move)
	{
		rb.velocity = new Vector2 (move * speed, rb.velocity.y);

		if (jump && !doubleJump && rb.velocity.y == 0)
		{
			rb.AddForce (new Vector2 (0, jumpForce));
		}  

		if (jump && doubleJump && rb.velocity.y > 0)
		{
			rb.AddForce (new Vector2 (0, jumpForce));
		}

		if (onGround)
		{
			jump = false;
			doubleJump = false;
		}
	}

	bool OnGround ()
	{	
		//Check if player is falling or on the floor
		if (rb.velocity.y <= 0f)
		{
			//Loop through list of child transforms
			foreach (Transform points in groundPoints)
			{
				//Get info of everything colliding in a circular areas around them
				Collider2D[] colliders = Physics2D.OverlapCircleAll (points.position, groundradius, groundMask);
				for (int i = 0; i < colliders.Length; i++)
				{
					//Check if the collider returned isnt itself
					if (colliders [i].gameObject != gameObject)
					{
						Debug.Log (colliders [i].name);

						return true;
					}
				}
			}
		}
		return false;
	}

	void Shoot()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 newMousePos = new Vector3 (mousePos.x, mousePos.y, 0);

		GameObject line = Instantiate (shootprefab,gameObject.transform);
		CapsuleCollider col = line.AddComponent<CapsuleCollider> ();
		LineRenderer lr = line.GetComponent<LineRenderer> ();

		lr.SetPosition (0,gameObject.transform.position);
		lr.SetPosition (1, newMousePos);
		col.height = Vector3.Distance (lr.GetPosition (0), lr.GetPosition (1));
		col.transform.LookAt (newMousePos);
		col.radius = 0.5f;


		//Pass the player position and mouse position to line renderer
	}
}
