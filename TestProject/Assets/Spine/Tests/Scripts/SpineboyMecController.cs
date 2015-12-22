using UnityEngine;
using System.Collections;

namespace TestProject
{
	public class SpineboyMecController : MonoBehaviour
	{
		public float maxSpeed = 10f;
		public float jumpForce = 700;

		// Falling anim support
		public Transform groundCheck;
		public LayerMask whatIsGround;
		public GameObject gunTip;

		bool grounded = false;
		float groundRadius = .2f;

		[HideInInspector]
		public bool attacked = false;

		bool facingRight = true;
		//bool doubleJump = false;

		// Cached components
		//	SkeletonAnimation skeletonAnimation;
		//	SkeletonAnimator skeletonAnimator;
		Animator anim;
		Rigidbody2D rb;


		// Use this for initialization
		void Start()
		{
			//skeletonAnimator = GetComponent<SkeletonAnimator>();
			//if( skeletonAnimator == null)
			//{
			//}

			anim = GetComponent<Animator>();
			rb = GetComponent<Rigidbody2D>();

			//gunTip.collider2D.e
		}

		// Update is called once per frame
		void FixedUpdate()
		{
			grounded = Physics2D.OverlapCircle( groundCheck.position, groundRadius, whatIsGround );
			anim.SetBool( "Ground", grounded );
			anim.SetFloat( "vSpeed", rb.velocity.y );

			//---------------
			if( grounded )
			{
				float move = Input.GetAxis( "Horizontal" );
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
			//if( grounded && Input.GetButtonDown( "Jump" ) )
			//{
			//	anim.SetBool( "Ground", false );
			//	rb.AddForce( new Vector2( 0, jumpForce ) );

			//	//if( !doubleJump && !grounded )
			//	//{
			//	//	doubleJump = true;
			//	//}
			//}

			if( (Input.GetButtonDown( "Fire1" ) ) )
			{
				attacked = true;
				if( !anim.GetBool( "Attack" ) )
					anim.SetBool( "Attack", true );

				//Spine.TrackEntry aTrack = skeletonAnimation.state.GetCurrent( 1 );

				//if( aTrack == null )
				//{
				//	var bla = false;
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

			if( !attacked )
			{
				if( anim.GetBool( "Attack" ) )
				{
					anim.SetBool( "Attack", false );
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


		//void OnCollisionEnter( Collision collisionInfo )
		//{
		//	print( "Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name );
		//	print( "There are " + collisionInfo.contacts.Length + " point(s) of contacts" );
		//	print( "Their relative velocity is " + collisionInfo.relativeVelocity );
		//}

		//void OnCollisionStay( Collision collisionInfo )
		//{
		//	print( gameObject.name + " and " + collisionInfo.collider.name + " are still colliding" );
		//}

		//void OnCollisionExit( Collision collisionInfo )
		//{
		//	print( gameObject.name + " and " + collisionInfo.collider.name + " are no longer colliding" );
		//}
	}
}