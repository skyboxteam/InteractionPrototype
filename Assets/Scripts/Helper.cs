using UnityEngine;
using System.Collections;

public static class Helper// : MonoBehaviour 
{

	public static Vector3 ScreenToWorld(Vector3 screenPos, Touch touch)
	{
		screenPos = touch.position;
		screenPos.z = -Camera.main.transform.position.z;
		return screenPos = Camera.main.ScreenToWorldPoint( screenPos );
		
	}
}
