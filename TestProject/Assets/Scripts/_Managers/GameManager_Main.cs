using UnityEngine;
using System.Collections;


namespace TestProject
{
	public class GameManager_Main : MonoBehaviour
	{
		void Start()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		void Update()
		{
			if( Input.GetButtonUp( "ExitApp" ))	{
				Application.Quit();
			}
		}

		/* ==================================================================================
		 *
		 *		Using Event handlers to broadcast messages when spawning objects, etc.
		 *	This works together with a test object (TestUnit) and the attached
		 *	script (TSTDelegateAndEvents).
		 *
		 * ==================================================================================
		 */
		public delegate void UnitEventHandler( GameObject unit, MyEvent e );
		public static event UnitEventHandler onUnitSpawn;
		public static event UnitEventHandler onUnitDestroy;

		public static void NewUnitCreated( GameObject unit )
		{
			// Broadcast event if anything has suscribed to it...
			if( onUnitSpawn != null )
			{
				// Broadcast event
				onUnitSpawn( unit, new MyEvent { id = MyEvent.eType.TYPE_0, name = "Tipo Zero" } );
			}
		}
		public static void NewUnitDestroyed( GameObject unit )
		{
			// Broadcast event if anything has suscribed to it...
			if( onUnitDestroy != null )
			{
				// Broadcast event
				onUnitDestroy( unit, new MyEvent { id = MyEvent.eType.TYPE_1, name = "Tipo Uno" } );
			}
		}
		void OnEnable() { NewUnitCreated( this.gameObject ); }
		void OnDisable() { NewUnitDestroyed( this.gameObject ); }
	}

	public class MyEvent
	{
		public enum eType
		{
			TYPE_0 = 0,
			TYPE_1,
			TYPE_2
		}
		public eType id = eType.TYPE_0;
		public string name = "";
	}
}
