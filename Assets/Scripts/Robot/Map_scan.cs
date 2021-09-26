using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_scan : MonoBehaviour
{
	public string targetTag = "Robot";
	private float distance = 1f;
	private Vector3 offset;
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
		if (Vector3.Distance(transform.position, target.position) < distance)
		{









			/* Проверка работоспособности лучей
			bool[] log = RayToScan();
			string _log = null;

			for (int i = 0; i < 3; i++)
            {
				if (log[i] == true)
					_log += "true" + " ";

				else
					_log += "false" + " ";
            }

			Debug.Log(_log);
			*/
		}
	}
}
