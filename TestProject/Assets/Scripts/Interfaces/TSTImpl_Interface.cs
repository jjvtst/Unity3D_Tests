using UnityEngine;
using System.Collections;

namespace TestProject
{
	public class TSTImpl_Interface : MonoBehaviour, IKillable, IDamageable<float>
	{
		/// <summary>
		/// 
		/// </summary>
		public void Kill()
		{
			// 
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="damageTaken"></param>
		public void Damage( float damageTaken )
		{
			// 
		}
	}
}
