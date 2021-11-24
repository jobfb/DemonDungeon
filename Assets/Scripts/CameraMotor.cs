using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
	public Transform lookAt;//look at the player

	public float BoundX = 0.30f;
	public float BoundY = 0.15f;

	private void LateUpdate() //late update occurs after update and fix update
	{
		Vector3 delta = Vector3.zero;


		//this is to check if we are inside the bounds of the X axis
		float deltaX = lookAt.position.x - transform.position.x;
		if (deltaX < -BoundX || deltaX > BoundX) //if we are out the bound of the camera//  transform is the focus of the camera and look at is the player position
		{
			if (transform.position.x < lookAt.position.x)	
			{
				delta.x = deltaX - BoundX;
			}
			else
			{
				delta.x = deltaX + BoundX;
			}
		}
		
		
		//this is to check if we are inside the bounds of the Y axis
		float deltaY = lookAt.position.y - transform.position.y;
		if (deltaY < -BoundY || deltaY > BoundY) //if we are out the bound of the camera//  transform is the focus of the camera and look at is the player position
		{
			if (transform.position.y < lookAt.position.y)
			{
				delta.y = deltaY - BoundY;
			}
			else
			{
				delta.y = deltaY + BoundY;
			}
		}

		transform.position += new Vector3(delta.x, delta.y, 0);
	}



}
