using UnityEngine;
using System.Collections;

public class RabitMovement : MonoBehaviour 
{
	public float MoveSpeed;
	private Vector2 startPos;
	private Vector2 curPos;
	private bool isMoving;


	void Start () 
	{
		MoveSpeed = 1f;
		isMoving = false;
	}
	

	void Update () 
	{
		if(Input.GetKey(KeyCode.D))
		{
			transform.position += Vector3.right * Time.deltaTime * MoveSpeed;
			isMoving = true;
		}
		else if(Input.GetKeyUp(KeyCode.D))
			isMoving = false;
		if(Input.GetKey(KeyCode.A))
		{
			transform.position -= Vector3.right * Time.deltaTime * MoveSpeed;
			isMoving = true;
		}
		else if(Input.GetKeyUp(KeyCode.A))
			isMoving = false;
		if(Input.GetKey(KeyCode.S))
		{
			transform.position -= Vector3.forward * Time.deltaTime * MoveSpeed;
			isMoving = true;
		}
		else if(Input.GetKeyUp(KeyCode.S))
			isMoving = false;
		if(Input.GetKey(KeyCode.W))
		{
			transform.position += Vector3.forward * Time.deltaTime * MoveSpeed;
			isMoving = true;
		}
		else if(Input.GetKeyUp(KeyCode.W))
			isMoving = false;
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			transform.position += Vector3.up;
		}
		FingerRec();
		if(isMoving)
			animation.Play("Take 001");
	}
	
	void FingerRec()
	{
		for(int i = 0; i < Input.touchCount; i++)
		{
			//finger touches screen
			if(Input.GetTouch(i).phase == TouchPhase.Began && Input.touchCount == 1)
				startPos = Input.GetTouch(i).position;
			//finger starts moving
			if(Input.GetTouch(i).phase == TouchPhase.Moved && Input.touchCount == 1)
				curPos = Input.GetTouch(i).position;
			//finger release
			if(Input.GetTouch(i).phase == TouchPhase.Ended && Input.touchCount == 1)
			{
				startPos = curPos = Vector2.zero;
				isMoving = false;
			}
			
		}
		
		//right
		if(startPos.x < curPos.x && 
			( Mathf.Abs(startPos.x - curPos.x) > 3 * Mathf.Abs(startPos.y - curPos.y) ) && 
			Mathf.Abs(startPos.x - curPos.x) > 60 )
		{
			transform.position += Vector3.right * Time.deltaTime * MoveSpeed;
			isMoving = true;
		}
		
		//left
		if(startPos.x > curPos.x && 
			( Mathf.Abs(startPos.x - curPos.x) > 3 * Mathf.Abs(startPos.y - curPos.y) ) && 
			Mathf.Abs(startPos.x - curPos.x) > 60)
		{
			transform.position -= Vector3.right * Time.deltaTime * MoveSpeed;
			isMoving = true;
		}
		
		//up
		if(startPos.y < curPos.y && 
			( Mathf.Abs(startPos.y - curPos.y) > 3 * Mathf.Abs(startPos.x - curPos.x) ) && 
			Mathf.Abs(startPos.y - curPos.y) > 60)
		{
			transform.position += Vector3.forward * Time.deltaTime * MoveSpeed;
			isMoving = true;
		}
		
		//down
		if(startPos.y > curPos.y && 
			( Mathf.Abs(startPos.y - curPos.y) > 3 * Mathf.Abs(startPos.x - curPos.x) ) && 
			Mathf.Abs(startPos.y - curPos.y) > 60)
		{
			transform.position -= Vector3.forward * Time.deltaTime * MoveSpeed;
			isMoving = true;
		}
		
		
	//whether move to left,right,up,down. left: startPos.x > curPos.x && X0 > 3Y0
	
	
	
	}
}
