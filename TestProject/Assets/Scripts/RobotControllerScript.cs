using UnityEngine;
using System.Collections;

namespace TestProject
{
	public class RobotControllerScript : MonoBehaviour
	{

		// Cached components
		Animator anim;
		Rigidbody2D rb;

		public bool controlEnabled = false;

		public float maxSpeed = 10f;


		bool facingRight = true;

		// Falling anim support
		public Transform groundCheck;
		public LayerMask whatIsGround;
		bool grounded = false;
		float groundRadius = .2f;

		public float jumpForce = 700;

		bool doubleJump = false;


		// Use this for initialization
		void Start()
		{
			anim = GetComponent<Animator>();
			rb = GetComponent<Rigidbody2D>();
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			grounded = Physics2D.OverlapCircle( groundCheck.position, groundRadius, whatIsGround );
			anim.SetBool( "Ground", grounded );

			if( grounded )
				doubleJump = false;


			anim.SetFloat( "vSpeed", rb.velocity.y );

			//---------------
			if( grounded )
			{
				float move = controlEnabled ? Input.GetAxis( "Horizontal" ) : 0;
				anim.SetFloat( "Speed", Mathf.Abs( move ) );

				rb.velocity = new Vector2( move * maxSpeed, rb.velocity.y );

				if( move > 0 && !facingRight )
					Flip();
				else if( move < 0 && facingRight )
					Flip();
			}
		}

		void Update()
		{
			//if((grounded || !doubleJump) && Input.GetButtonDown("Jump") )

			if( controlEnabled && grounded && Input.GetButtonDown( "Jump" ) )
			{
				anim.SetBool( "Ground", false );
				rb.AddForce( new Vector2( 0, jumpForce ) );

				if( !doubleJump && !grounded )
				{
					doubleJump = true;
				}
			}
		}

		void Flip()
		{
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}