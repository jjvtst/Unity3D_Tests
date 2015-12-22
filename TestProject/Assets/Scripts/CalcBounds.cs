using UnityEngine;
using System.Collections;

namespace TestProject
{
	public class CalcBounds : MonoBehaviour
	{
		Color rendColor;
		Renderer rend = null;
		Vector3 bCenter, bExtents;

		void Start()
		{
			rendColor = new Color( 0.0f, 0.7f, 1f, 1.0f );

			// If null this can be a (maybe) empty/group object
			rend = GetComponent<Renderer>();

			if( rend != null )
			{
				bCenter = rend.bounds.center;
				bExtents = rend.bounds.extents * 2;
			}
		}
		void OnDrawGizmos()
		{
			DrawGizmo( false );
		}
		void OnDrawGizmosSelected()
		{
			DrawGizmo( true );
		}
		void DrawGizmo( bool isSelected )
		{
			var col = rendColor;
			col.a = isSelected ? 0.3f : 0.1f;
			Gizmos.color = col;

			// if null this is a group/non-renderable object
			if( rend == null )
			{
				var childCount = transform.childCount;

				if( childCount > 0 )
				{
				}
				else
				{
				}

				Gizmos.DrawWireCube( bCenter, bExtents );
			}
			else
			{
				var oMatrix = Gizmos.matrix;
				Gizmos.matrix = transform.localToWorldMatrix;
				Gizmos.DrawCube( Vector3.zero, Vector3.one );
				Gizmos.matrix = oMatrix;
			}
		}
	}
}
