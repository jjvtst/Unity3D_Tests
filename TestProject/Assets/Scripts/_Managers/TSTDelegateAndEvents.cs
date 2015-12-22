using UnityEngine;
using System.Collections;

namespace TestProject
{
	public class TSTDelegateAndEvents : MonoBehaviour
	{
		// Use this for initialization
		void Start(){}

		public void NewUnitCreated(GameObject unit, MyEvent e) {
			print( this.gameObject.name + ": Got UnitCreatedEvent from GO \"" + unit.name + "\"" );
		}
		public void NewUnitDestroyed( GameObject unit, MyEvent e ) {
			print( this.gameObject.name + ": Got UnitDestroyedEvent from GO \"" + unit.name + "\"" );
		}

		void OnEnable()
		{
			// Subscribe to events
			GameManager_Main.onUnitSpawn -= this.NewUnitCreated;
			GameManager_Main.onUnitDestroy -= this.NewUnitDestroyed;
			//
			GameManager_Main.onUnitSpawn += this.NewUnitCreated;
			GameManager_Main.onUnitDestroy += this.NewUnitDestroyed;
			print( this.gameObject.name + ": Subscribed to GameManager_Main events" );
		}
		void OnDisable()
		{
			// Unsubscribe to events
			GameManager_Main.onUnitSpawn -= this.NewUnitCreated;
			GameManager_Main.onUnitDestroy -= this.NewUnitDestroyed;
			print( this.gameObject.name + ": Unsubscribed to GameManager_Main events" );
		}
	}
}