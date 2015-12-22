using UnityEngine;
using System.Collections;

public class Lamp2_Blink : MonoBehaviour {

	void Start()
	{
		//Debug.Log( string.Format( "Start time = {0}", Time.time ) );
		StartCoroutine( "CreaIEspera" );
		//Debug.Log( string.Format( "Time before call CreaIEspera = {0}", Time.time ) );
	}

	IEnumerator CreaIEspera()
	{
		yield return new WaitForSeconds( Random.Range( 1f, 10f ) );

		GetComponent<Animator>().SetBool( "goAnimate", true );
		//Debug.Log( string.Format( "Timer before a cube creation = {0}", Time.time ) );
	}
}
