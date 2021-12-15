using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_brain : MonoBehaviour
{
    private Robot_navigation robot_nav;
    private Map_scan map_scan;
    private Robot robot;
    GameObject brain;

    public List<int> task_queue = new List<int>();

    void Start()
    {
        robot_nav = GetComponent<Robot_navigation>();
        map_scan = GetComponent<Map_scan>();
        robot = GetComponent<Robot>();
        brain = GameObject.Find("Brain");
    }

    void Update()
    {
        main();
        //int[] scan = map_scan.RayToScan();
    }

    private void FixedUpdate()
    {
        
    }

    void main()
    {
        if (task_queue.Count == 0)
            robot.status = 1;
        else
        {
            robot.status = 0;
            int[] send_mes = new int[] { robot.status, robot.robot_num };
            brain.SendMessage("get_robot_status", send_mes);


        }
    }

    public void get_task(int[] task)
    {
        foreach(int i in task)
        {
            task_queue.Add(i);
        }
    }
}
