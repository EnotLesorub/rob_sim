using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_scan : MonoBehaviour
{
	public string targetTag = "Robot";
	public int distance = 15;
	public Vector3 offset;
	private Transform target;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag(targetTag).transform;
	}

	bool GetRaycast(Vector3 dir)
	{
		bool result = false;
		RaycastHit hit = new RaycastHit();
		Vector3 pos = transform.position + offset;
		if (Physics.Raycast(pos, dir, out hit, distance))
		{
			if (hit.transform == target)
			{
				result = true;
				Debug.DrawLine(pos, hit.point, Color.blue);
			}
			else
			{
				Debug.DrawLine(pos, hit.point, Color.green);
			}
		}
		else
		{
			Debug.DrawRay(pos, dir * distance, Color.red);
		}
		return result;
	}

	bool RayToScan()
	{
		bool result = false;

		Vector3 dir = transform.TransformDirection(new Vector3(0, 0, 1));
		GetRaycast(dir);

		dir = transform.TransformDirection(new Vector3(1, 0, 0));
		GetRaycast(dir);

		dir = transform.TransformDirection(new Vector3(-1, 0, 0));
		GetRaycast(dir);

		return result;
	}

	void Update()
	{
		if (Vector3.Distance(transform.position, target.position) < distance)
		{
			if (RayToScan())
			{
				// Контакт с целью
			}
			else
			{
				// Поиск цели...
			}
		}
	}
}
