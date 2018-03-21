using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * This class managesthe columns that the player can use.
 * These columns must be (unity) childs of an object that has this script attached.
 * They will be placed in a row, outside the board (starting on the object's transform).
 */
public class ColumnOrganizer : MonoBehaviour {
	// The distance between columns
	public float distance = 1.5f;

	private ColumnBehaviour[] usableColumns;
	// Use this for initialization
	void Start () {
		usableColumns = GetComponentsInChildren<ColumnBehaviour>();

		SortByLength();

		PlaceColumns();
	}

	void SortByLength()
	{
		int arrayLength = usableColumns.Length;
		ColumnBehaviour buffer;
		int shortest = 0;
		int minLength = 0;
		for (int i = 0; i < arrayLength; i++)
		{
			// Find the shortest of the remainning longest
			shortest = i;
			minLength = usableColumns[i].GetLength();
			for (int j = i; j < arrayLength; j++)
			{
				if (usableColumns[j].GetLength() < minLength)
				{
					shortest = j;
					minLength = usableColumns[shortest].GetLength();
				}
			}

			// Put shortest at the beginning
			buffer = usableColumns[i];
			usableColumns[i] = usableColumns[shortest];
			usableColumns[shortest] = buffer;
		}
	}

	void PlaceColumns()
	{
		for (int i = 0; i < usableColumns.Length; i++)
		{
			// Compute new position, shifting by "distance" every column
			Vector3 columnPosition = transform.position + new Vector3(distance * i, 0, 0);
			// Apply new position
			usableColumns[i].SetInitialPosition(columnPosition);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
