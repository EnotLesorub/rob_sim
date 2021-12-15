using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour
{
    private GameObject[] robots;
    private int robots_num;
    private Spawner spawn;

    int[] test_mes = new int[] { 1, 1, 1 };
    List<int> robots_status = new List<int>();

    void Start()
    {
        spawn = GetComponent<Spawner>();
        robots_num = spawn.robots_count;

        for(int i = 0; i < robots_num; i++)
            robots_status.Add(1);
    }

    void Update()
    {
        robots = GameObject.FindGameObjectsWithTag("Robot");
        if(robots_status[0] == 1)
            robots[0].SendMessage("get_task", test_mes);
        if (robots_status[1] == 1)
            robots[1].SendMessage("get_task", test_mes);
    }

    void get_robot_status(int[] status)
    {
        robots_status[status[1]] = status[0];
    }
}
