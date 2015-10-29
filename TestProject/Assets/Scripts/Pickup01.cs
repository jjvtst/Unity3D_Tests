using UnityEngine;
using System.Collections;

public class Pickup01 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var randTime = Random.Range( 0f, 1f );
		//Debug.LogFormat( "2. randTime: {0}", randTime );

		var animC = GetComponent<Animator>();

		// Start at a different time
		animC.Play( "PickupButton", 0, randTime );
	}
}
