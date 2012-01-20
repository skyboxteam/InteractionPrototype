using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour 
{
	public GameObject Fg;
	public GameObject Mg;
	public GameObject Bg;
//	private Vector3 fingerDeltaPos;
	private Vector3 lastPos;
	private Vector3 curPos;
	private float movement;
	
	void Start () 
	{
//		fingerDeltaPos = Vector3.zero;
		lastPos = Vector3.zero;
		curPos = Vector3.zero;
	}
	

	void Update () 
	{
//		Touch touch = Input.GetTouch(0);
		
		//Gesture recognizer Loop
		for (int i = 0; i < Input.touchCount; i++) 
		{	
			if (Input.GetTouch(i).phase == TouchPhase.Began && Input.touchCount == 1)
			{
				lastPos = curPos = Helper.ScreenToWorld(curPos, Input.GetTouch(i));
				Debug.Log("cur: " + curPos + " last: " + lastPos);
			}
//			if (Input.GetTouch(i).phase == TouchPhase.Ended && Input.touchCount == 2)
//			{
//				endPos = Input.GetTouch(i).position;
//				Debug.Log(startPos + " : " + endPos);
//			}
			if(Input.GetTouch(i).phase == TouchPhase.Moved && Input.touchCount == 1)
			{
//					Debug.Log("Moved");
				Debug.Log("cur: " + curPos + " last: " + lastPos);
//				curPos = ScreenToWorld(curPos, Input.GetTouch(i));
				curPos = Helper.ScreenToWorld(curPos, Input.GetTouch(i));
				movement = lastPos.x - curPos.x;
				lastPos = curPos;
				//Movement limitation from -11 to 10, the edge of front ground	
				Fg.transform.position -= Vector3.right * movement;
				if(Fg.transform.position.x < -11)
					Fg.transform.position = new Vector3(-11, Fg.transform.position.y, Fg.transform.position.z);
				if(Fg.transform.position.x > 10)
					Fg.transform.position = new Vector3(10, Fg.transform.position.y, Fg.transform.position.z);
//				Mg.transform.position = Vector3.right * movement * 0.6f;
//				Bg.transform.position -= Vector3.right * movement /6;
				Mg.transform.position = new Vector3(Fg.transform.position.x * 0.6f, Mg.transform.position.y, Mg.transform.position.z);
				Bg.transform.position = new Vector3(Fg.transform.position.x / 6, Bg.transform.position.y, Bg.transform.position.z);			
			}
			if(Input.GetTouch(i).phase == TouchPhase.Ended && Input.touchCount == 1)
			{
				lastPos = curPos;
			}	
		}		
	}

}
