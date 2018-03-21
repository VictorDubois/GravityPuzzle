using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnManagerBehavior : MonoBehaviour {
	private ColumnBehaviour[] columns;

	// Use this for initialization
	void Start () {
		columns = GetComponentsInChildren<ColumnBehaviour>();
		if(columns == null)
		{
			Debug.LogWarning("No columns found");
		}
	}

	public void Turn(bool left)
	{
		for(int i = 0; i < columns.Length; i++)
		{
			columns[i].Turn(left);
		}
	}

	public void Invert()
	{
		for (int i = 0; i < columns.Length; i++)
		{
			columns[i].SwitchSide(false);
		}
	}
}
