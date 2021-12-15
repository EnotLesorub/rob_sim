using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_scan : MonoBehaviour
{
	private string targetTag = "Robot";
	private float distance = 1.0f;
	private GameObject[] target;

	void Start()
	{

	}

	List<int> GetRaycast(Vector3 dir)
	{
		List<int> result = new List<int>();
		RaycastHit hit = new RaycastHit();
		Vector3 pos = transform.position;

		target = GameObject.FindGameObjectsWithTag(targetTag);
		foreach (GameObject i in target)
        {
			if (Physics.Raycast(pos, dir, out hit, distance))
			{
				if (hit.transform.tag == targetTag)
				{
					result.Add(0);
					Debug.DrawLine(pos, hit.point, Color.blue);
				}
				else
				{
					result.Add(2);
					Debug.DrawLine(pos, hit.point, Color.green);
				}
			}
			else
			{
				result.Add(0);
				Debug.DrawRay(pos, dir * distance, Color.red);
			}
		}

		return result;
	}

	public int[] RayToScan()
	{
		int[] result = new int[] { 0, 0, 0 };

		Vector3 dir = transform.TransformDirection(new Vector3(0, 0, 1)); 
		List<int> res = GetRaycast(dir);
		result[0] = res[0];

		dir = transform.TransformDirection(new Vector3(1, 0, 0));
		res = GetRaycast(dir);
		result[1] = res[0];

		dir = transform.TransformDirection(new Vector3(-1, 0, 0));
		res = GetRaycast(dir);
		result[2] = res[0];

		return result;
	}

	void Update()
	{

	}
}
