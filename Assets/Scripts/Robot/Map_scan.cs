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

	int GetRaycast(Vector3 dir)
	{
		int result = 0;
		RaycastHit hit = new RaycastHit();
		Vector3 pos = transform.position;
		if (Physics.Raycast(pos, dir, out hit, distance))
		{
			if (hit.transform == target)
			{
				result = 0;
				Debug.DrawLine(pos, hit.point, Color.blue);
			}
			else
			{
				result = 2;
				Debug.DrawLine(pos, hit.point, Color.green);
			}
		}
		else
		{
			Debug.DrawRay(pos, dir * distance, Color.red);
		}
		return result;
	}

	public int[] RayToScan()
	{
		int[] result = new int[] { 0, 0, 0 };

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
