using UnityEngine;
using System.Collections;

/// <summary>
/// Using example from https://www.youtube.com/watch?v=boIJm1o8Pkw
/// </summary>
namespace TestProject
{
	public class GunContact02 : MonoBehaviour
	{
		void Start()
		{
		}
		void Hit( string attachmentName )
		{
			Debug.Log("Hit by " + attachmentName );
		}
	}
}
