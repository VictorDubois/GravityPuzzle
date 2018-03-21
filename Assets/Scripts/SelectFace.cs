using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFace : MonoBehaviour
{
	private bool enableLogs = false;
	private bool leftClickPlacement = false;

	private ColumnBehaviour selectedColumn;
	// Use this for initialization
	void Start()
	{
	}

	bool CheckSelection(out RaycastHit hitInfo)
	{
		//RaycastHit hitInfo = new RaycastHit();
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, 1 << LayerMask.NameToLayer("Faces")))
		{
			if (hitInfo.transform.gameObject.tag == "Construction")
			{
				return true;
			}
			else
			{
				DisablableLogs("Pointed object is not a construction (tag)");
				return false;
			}
		}
		else
		{
			DisablableLogs("Pointed object is not a face (layer)");
			return false;
		}
	}

	void DisablableLogs(object message)
	{
		if (enableLogs)
		{
			Debug.Log(message);
		}
	}

	void DisablableLogs(object message, Object context)
	{
		if (enableLogs)
		{
			Debug.Log(message, context);
		}
	}

	public void ToggleLeftClickPlacement()
	{
		leftClickPlacement = !leftClickPlacement;
	}

	ColumnBehaviour GetColumn(RaycastHit hitInfo)
	{
		GameObject columnObj;

		// Get parent of the parent, while checking if it exists
		Transform potentialParent = hitInfo.transform.parent;
		if (potentialParent != null)
		{
			potentialParent = potentialParent.transform.parent;
			if (potentialParent != null)
			{
				columnObj = potentialParent.gameObject;
				if(columnObj != null)
				{
					// Get the behavior associated
					return columnObj.GetComponent<ColumnBehaviour>();
				}
			}
		}
		return null;
	}

	void SelectColumn() {
		RaycastHit hitInfo = new RaycastHit();
		//Debug.Log(hitInfo);
		//Debug.Log(hitInfo.ToString());
		if (!CheckSelection(out hitInfo))
		{
			return;
		}
		DisablableLogs("Hit " + hitInfo.transform.gameObject.name);

		// Get parent of the parent, while checking if it exists
		ColumnBehaviour column = GetColumn(hitInfo);
		DisablableLogs(column);
		if (!column)
		{
			return;
		}

		// Select column
		DisablableLogs("Column found!");
		if (column.fixedPosition)
		{
			DisablableLogs("Cannot move column");
			return;
		}
		if(selectedColumn)
		{
			selectedColumn.Deselect();
		}
		selectedColumn = column;
		selectedColumn.Select();
	}

	void PlaceColumn()
	{
		// If a column is selected, place it
		if (selectedColumn == null)
		{
			DisablableLogs("Select a column first");
			return;
		}

		RaycastHit hitInfo = new RaycastHit();
		if (!CheckSelection(out hitInfo))
		{
			return;
		}

		// Cannot place a column on itself
		if (selectedColumn == GetColumn(hitInfo))
		{
			return;
		}
		DisablableLogs("Hit " + hitInfo.transform.gameObject.name);

		// Add selected column
		DisablableLogs("Place column");

		// Move
		DisablableLogs(hitInfo.transform);
		DisablableLogs(hitInfo.transform.Find("Spot"));
		Transform newSpot = hitInfo.transform.Find("Spot");

		selectedColumn.transform.SetPositionAndRotation(newSpot.position, newSpot.rotation);
		selectedColumn.transform.Rotate(new Vector3(-90, 0, 0));

		// Auto deselect
		//selectedColumn.Deselect();
		//selectedColumn = null;
	}

	// Update is called once per frame
	void Update()
	{
		//if (Input.GetKeyDown(KeyCode.Escape))
		if (Input.GetButtonDown("DeselectColumn"))
		{
			if (selectedColumn != null)
			{
				selectedColumn.Deselect();
				selectedColumn = null;
			}
		}
		// If no column is selected, and we click on a column, then it is the new selected column
		if (Input.GetButtonDown("SelectColumn"))
		{
			DisablableLogs("Got button selectColumn. leftClickPlacement = " + leftClickPlacement.ToString());
			if(leftClickPlacement)
			{
				// Used for touchscreen interface
				PlaceColumn();
			}
			else
			{
				SelectColumn();
			}
		}

		else if (Input.GetButtonDown("PlaceColumn"))
		{
			PlaceColumn();
		}
	}
}
