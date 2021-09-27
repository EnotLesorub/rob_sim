using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_scan : MonoBehaviour
{
	private string targetTag = "Robot";
	private float distance = 1.0f;
	private Transform target;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag(targetTag).transform;
	}

	bool GetRaycast(Vector3 dir)
	{
		bool result = false;
		RaycastHit hit = new RaycastHit();
		Vector3 pos = transform.position;
		if (Physics.Raycast(pos, dir, out hit, distance))
		{
			if (hit.transform == target)
			{
				Debug.DrawLine(pos, hit.point, Color.blue);
			}
			else
			{
				result = true;
				Debug.DrawLine(pos, hit.point, Color.green);
			}
		}
		else
		{
			Debug.DrawRay(pos, dir * distance, Color.red);
		}
		return result;
	}

	public bool[] RayToScan()
	{
		bool[] result = new bool[] { false, false, false };

		Vector3 dir = transform.TransformDirection(new Vector3(0, 0, 1));
		result[0] = GetRaycast(dir);

		dir = transform.TransformDirection(new Vector3(1, 0, 0));
		result[1] = GetRaycast(dir);

		dir = transform.TransformDirection(new Vector3(-1, 0, 0));
		result[2] = GetRaycast(dir);

		return result;
	}

	void Update()
	{

	}
}
