using UnityEngine;
using System.Collections;

/// <summary>
/// Using example from https://www.youtube.com/watch?v=boIJm1o8Pkw
/// </summary>
namespace TestProject
{
	public class GunContact01 : MonoBehaviour
	{
		BoundingBoxFollower bboxFollower;
		BoneFollower boneFollower;
		Ray zeRay;

		void Start()
		{
			//	bboxFollower = GetComponent<BoundingBoxFollower>();
			boneFollower = GetComponent<BoneFollower>();

			zeRay = new Ray();
		}


		void OnTriggerEnter2D( Collider2D collider )
		{
			//	collider.SendMessage( "Hit", bboxFollower.CurrentAttachmentName, SendMessageOptions.DontRequireReceiver );
			collider.SendMessage( "Hit", boneFollower.name, SendMessageOptions.DontRequireReceiver );

			//Spine.Bone bone = boneFollower.bone;
			//// 
			//zeRay.origin = transform.TransformPoint( new Vector3( 0, 0, 0 ) );
			//zeRay.direction = new Vector3( 0, 1, 0 );

			//Debug.DrawRay( zeRay.origin, zeRay.direction, Color.yellow, 5f, false );
		}
	}
}
