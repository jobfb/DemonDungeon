using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
	private BoxCollider2D boxCollider;

	private Vector3 moveDelta;//difference between the loaded frame and the next frame(place were we will be)

	private RaycastHit2D hit;

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
		
		
		//Comand line that make collision works, it cast a box where we wnt to go and if it returns null its free to move
		hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y),Mathf.Abs(moveDelta.y*Time.deltaTime),LayerMask.GetMask("Actor","Blocking"));

		if(hit.collider == null)
		{

		//Make the player move
		transform.Translate(0, moveDelta.y * Time.deltaTime, 0);

		}
		hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

		if (hit.collider == null)
		{

			//Make the player move
			transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);

		}


	}

}
