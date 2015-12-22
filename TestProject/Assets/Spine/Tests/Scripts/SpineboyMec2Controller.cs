using UnityEngine;
using System.Collections;

namespace TestProject
{
	public class SpineboyMec2Controller : MonoBehaviour
	{

		public float maxSpeed = 10f;
		public float jumpForce = 700;

		// Falling anim support
		public Transform groundCheck;
		public LayerMask whatIsGround;

		bool grounded = false;
		float groundRadius = .2f;


		bool facingRight = true;
		//bool doubleJump = false;

		// Cached components
		//SkeletonAnimation skeletonAnimation;
		Animator anim;
		Rigidbody2D rb;


		// Use this for initialization
		void Start()
		{
			//skeletonAnimation = GetComponent<SkeletonAnimation>();
			anim = GetComponent<Animator>();
			rb = GetComponent<Rigidbody2D>();
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			grounded = Physics2D.OverlapCircle( groundCheck.position, groundRadius, whatIsGround );
			anim.SetBool( "Ground", grounded );

			//if( !grounded )	{
			//	var aaa = false;
			//}

			//if( grounded )
			//	doubleJump = false;

			anim.SetFloat( "vSpeed", rb.velocity.y );

			//---------------
			if( grounded )
			{
				float move = Input.GetAxis( "Horizontal2" );
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
			if( grounded && Input.GetButtonDown( "Jump2" ) )
			{
				anim.SetBool( "Ground", false );
				rb.AddForce( new Vector2( 0, jumpForce ) );

				//if( !doubleJump && !grounded )
				//{
				//	doubleJump = true;
				//}
			}
			if( Input.GetButtonDown( "Fire2" ) )
			{
				//Spine.TrackEntry aTrack = skeletonAnimation.state.GetCurrent( 1 );
				anim.SetTrigger( "Fire_Gun" );

				//if( aTrack == null )
				//{
				//	skeletonAnimation.state.SetAnimation( 1, "shoot", false );
				//}
				//else
				//{
				//	Spine.Animation secAnim = aTrack.Animation;

				//	if( secAnim.Name != "shoot" )
				//	{
				//		bool bla = false;
				//	}
				//}
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
