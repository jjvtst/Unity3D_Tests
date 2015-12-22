using UnityEngine;
using System.Collections;

namespace TestProject
{
	public class Parallaxing : MonoBehaviour
	{
		public Transform[] backgrounds;
		private float[] parallaxScales;		// The proportion of the camera's movement to move the backgrounds by
		public float smoothing = 1f;        // How smooth the parallax is going to be. Make sure to set this above 0.
		public float parallaxScale = 1f;

		private Transform cam;				// Ref to the main camera's transform
		private Vector3 previousCamPos;		// The postiion of the camera in the previous frame

		void Awake()
		{
			// Set up the camera reference
			cam = Camera.main.transform;
		}

		// Use this for initialization
		void Start()
		{
			// The previous frame had the current frame's camera position
			previousCamPos = cam.position;

			// 
			parallaxScales = new float[ backgrounds.Length ];

			//
			for( int i = 0; i < backgrounds.Length; i++ )
			{
				parallaxScales[ i ] = backgrounds[ i ].position.z * -parallaxScale;
			}
		}

		// Update is called once per frame
		void Update()
		{
			//
			for( int i = 0, aLen = backgrounds.Length; i < aLen; i++ )
			{
				// The parallax is the opposite of the camera movement because the previous frame multiplied by the scale
				float parallax = ( previousCamPos.x - cam.position.x ) * parallaxScales[ i ];

				// Set a target x position which is the curr pos + the parallax
				float backgroundTargetPosX = backgrounds[ i ].position.x + parallax;

				// Create a target position which is the bg current position with it's target x position
				Vector3 backgroundTargetPos = new Vector3( backgroundTargetPosX, backgrounds[ i ].position.y, backgrounds[ i ].position.z );

				// Fade between current position and the target position using lerp
				backgrounds[ i ].position = Vector3.Lerp( backgrounds[ i ].position, backgroundTargetPos, smoothing * Time.deltaTime );
			}

			// Set previousCamPos to the camera's position ate the end of the frame
			previousCamPos = cam.position;
		}
	}
}
