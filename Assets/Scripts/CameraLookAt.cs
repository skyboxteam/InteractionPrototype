using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour 
{
	public GameObject LookAt;
	void Start () 
	{
	
	}
	

	void Update () 
	{
		transform.LookAt(LookAt.transform);
	}
}
