using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
	private BoxCollider2D boxCollider;

	private Vector3 moveDelta;//difference between the loaded frame and the next frame(place were we will be)

	private void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();
	}
	private void FixedUpdate() //because we are using physics and manual collision detection
	{

		float x = Input.GetAxisRaw("Horizontal");//its gonna return -1 if "a" or left arrow is pressed and 1 for "d" or right arrow
		float y = Input.GetAxisRaw("Vertical");//its gonna return -1 if "a" or left arrow is pressed and 1 for "d" or right arrow

		//Reset moveDelta 
		moveDelta = new Vector3(x, y, 0);

		//Debug.Log(x);
		//Debug.Log(y);

		//swap sprite direction right and left
		if (moveDelta.x > 0)
			transform.localScale = Vector3.one;
		else if (moveDelta.x < 0)
			transform.localScale = new Vector3(-1, 1, 1);


		//Make the player move
		transform.Translate(moveDelta * Time.deltaTime);

	}

}
