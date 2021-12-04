using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(BoxCollider2D))] Create a BoxCollider2D in case it doesn't exist 
public class Collidable : MonoBehaviour
{
	public ContactFilter2D filter;
	private BoxCollider2D boxCollider;
	private Collider2D[] hits = new Collider2D[10]; // Array that will tell what did you hit ;-;

	protected virtual void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();
	}

	protected virtual void Update()
	{
		//Collision work 
		boxCollider.OverlapCollider(filter, hits);
		for (int i = 0; i < hits.Length; i++)
		{
			if (hits[i] == null)
			{
				continue;
			}

			Debug.Log(hits[i].name);

			// the arrray is not cleaned up, so we do it
			hits[i] = null;
		}

	}
} 
