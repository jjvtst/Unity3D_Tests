

/*****************************************************************************
 * SpineboyController created by Mitch Thompson
 * Full irrevocable rights and permissions granted to Esoteric Software
*****************************************************************************/
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SkeletonAnimation), typeof(Rigidbody2D))]
public class SpineboyController : MonoBehaviour {

	/// <summary>
	///	By adding the spineanimation attribute, a drop-down with all the animations will be shown instead of a manually typed string
	/// </summary>
	[SpineAnimation]
	public string idleAnimation = "idle";
	[SpineAnimation]
	public string walkAnimation = "walk";
	[SpineAnimation]
	public string runAnimation = "run";
	[SpineAnimation]
	public string hitAnimation = "hit";
	[SpineAnimation]
	public string deathAnimation = "death";
	[SpineAnimation]
	public string jumpAnimation = "jump";

	public float walkVelocity = 1;
	public float runVelocity = 6;
	public float jumpForce = 700;
	public int hp = 10;

	// Falling anim support
	public Transform groundCheck;
	public LayerMask whatIsGround;
	bool grounded = false;
	float groundRadius = .2f;

	// Internal refs
	SkeletonAnimation skeletonAnimation;
	Rigidbody2D rb;

	string currentAnimation = "";
	bool hit = false;
	bool dead = false;

	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle( groundCheck.position, groundRadius, whatIsGround );
		//anim.SetBool( "Ground", grounded );

		//if( !grounded )
		//{
		//	var aaa = false;
		//}

		//if( grounded )
		//	doubleJump = false;


		//anim.SetFloat( "vSpeed", rb.velocity.y );

		//---------------
		if( grounded )
		{
			//	float move = Input.GetAxis( "Horizontal2" );
			//	anim.SetFloat( "Speed", Mathf.Abs( move ) );

			//	rb.velocity = new Vector2( move * maxSpeed, rb.velocity.y );

			//	if( move > 0 && !facingRight )
			//		Flip();
			//	else if( move < 0 && facingRight )
			//		Flip();
		}
	}


	void Update () {
		if (!dead) {
			float x = 0;				//Input.GetAxis( "Horizontal2" );
			float absX = Mathf.Abs( x );

			if( !hit) {

				//          if( Input.GetAxis( "Fire2" ) > 0 )
				//			{
				//				Spine.TrackEntry aTrack = skeletonAnimation.state.GetCurrent( 1 );

				//				if( aTrack == null )
				//				{
				//					skeletonAnimation.state.SetAnimation( 1, "shoot", false );
				//				}
				//				else
				//				{
				//					Spine.Animation secAnim = aTrack.Animation;

				//					if( secAnim.Name != "shoot" )
				//					{
				//						bool bla = false;
				//					}
				//				}
				//			}

				//			if( Input.GetButtonDown( "Jump2" ) )
				//			{
				//				SetAnimation( jumpAnimation, true );
				//				rb.AddForce( new Vector2( 0, jumpForce ) );
				//			}
				//			else
				//			{
				if( x > 0 )
					skeletonAnimation.skeleton.FlipX = false;
				else if( x < 0 )
					skeletonAnimation.skeleton.FlipX = true;

				if( absX > 0.7f )
				{
					SetAnimation( runAnimation, true );
					rb.velocity = new Vector2( runVelocity * Mathf.Sign( x ), rb.velocity.y );
					//rb.velocity = new Vector2( walkVelocity * Mathf.Sign( x ), rb.velocity.y );
				}
				else if( absX > 0 )
				{
					SetAnimation( walkAnimation, true );
					rb.velocity = new Vector2( walkVelocity * Mathf.Sign( x ), rb.velocity.y );
				}
				else
				{
					SetAnimation( idleAnimation, true );
					rb.velocity = new Vector2( 0, rb.velocity.y );
				}
				//			}
				//		}
				//		else {
				//			if (skeletonAnimation.state.GetCurrent(0).Animation.Name != hitAnimation)
				//				hit = false;
			}
		}
	}

	void SetAnimation( string anim, bool loop )
	{
		if( currentAnimation != anim )
		{
			skeletonAnimation.state.SetAnimation( 0, anim, loop );
			currentAnimation = anim;
		}
	}

	//void OnMouseUp () {

	//	if (hp > 0) {
	//		hp--;

	//		if (hp == 0) {
	//			SetAnimation(deathAnimation, false);
	//			dead = true;
	//		} else {
	//			skeletonAnimation.state.SetAnimation(0, hitAnimation, false);
	//			skeletonAnimation.state.AddAnimation(0, currentAnimation, true, 0);
	//			rb.velocity = new Vector2(0, rb.velocity.y);
	//			hit = true;
	//		}

	//	}
	//}
}