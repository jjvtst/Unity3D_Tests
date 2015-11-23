

/*****************************************************************************
 * SpineboyController created by Mitch Thompson
 * Full irrevocable rights and permissions granted to Esoteric Software
*****************************************************************************/
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SkeletonAnimation), typeof(Rigidbody2D))]
public class SpineboyController : MonoBehaviour {

	SkeletonAnimation skeletonAnimation;
	Rigidbody2D rb;

	public string idleAnimation = "idle";
	public string walkAnimation = "walk";
	public string runAnimation = "run";
	public string hitAnimation = "hit";
	public string deathAnimation = "death";
	public string jumpAnimation = "jump";
	public float walkVelocity = 1;
	public float runVelocity = 3;
	public float jumpForce = 700;
	public int hp = 10;
	string currentAnimation = "";
	bool hit = false;
	bool dead = false;

	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update () {
		if (!dead) {
			float x = Input.GetAxis("Horizontal");
			float absX = Mathf.Abs(x);

			if (!hit) {

                if( Input.GetAxis( "Fire1" ) > 0 )
				{
					Spine.TrackEntry aTrack = skeletonAnimation.state.GetCurrent( 1 );

					if( aTrack == null )
					{
						skeletonAnimation.state.SetAnimation( 1, "shoot", false );
					}
					else
					{
						Spine.Animation secAnim = aTrack.Animation;

						if( secAnim.Name != "shoot" )
						{
							bool bla = false;
						}
					}
				}

				if( Input.GetAxis( "Jump" ) > 0 )
				{
					SetAnimation( jumpAnimation, false );
					rb.AddForce( new Vector2( 0, jumpForce ) );
				}
				else
				{
					if( x > 0 )
						skeletonAnimation.skeleton.FlipX = false;
					else if( x < 0 )
						skeletonAnimation.skeleton.FlipX = true;

					if( absX > 0.7f )
					{
						//SetAnimation( runAnimation, true );
						//rb.velocity = new Vector2( runVelocity * Mathf.Sign( x ), rb.velocity.y );
						rb.velocity = new Vector2( walkVelocity * Mathf.Sign( x ), rb.velocity.y );
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
				}
			}
			else {
				if (skeletonAnimation.state.GetCurrent(0).Animation.Name != hitAnimation)
					hit = false;
			}
		}
	}

	void SetAnimation (string anim, bool loop) {
		if (currentAnimation != anim) {
			skeletonAnimation.state.SetAnimation(0, anim, loop);
			currentAnimation = anim;
		}
	}

	void OnMouseUp () {

		if (hp > 0) {
			hp--;

			if (hp == 0) {
				SetAnimation(deathAnimation, false);
				dead = true;
			} else {
				skeletonAnimation.state.SetAnimation(0, hitAnimation, false);
				skeletonAnimation.state.AddAnimation(0, currentAnimation, true, 0);
				rb.velocity = new Vector2(0, rb.velocity.y);
				hit = true;
			}

		}
	}
}