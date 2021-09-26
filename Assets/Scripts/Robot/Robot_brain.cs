using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_brain : MonoBehaviour
{
    private Robot robot;
    private Map_scan map_scan;
    private int flag = 2;
    
    void Start()
    {
        robot = GetComponent<Robot>();
        map_scan = GetComponent<Map_scan>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Obstacle_scan();
        //Movement();
        //Rotation();
    }

    private void Movement(float[] move)
    {
        float moveHorizontal = move[0];
        float moveVertical = move[1];
        string mas = moveHorizontal.ToString() + " " + moveVertical.ToString();

        //Debug.Log(mas);

        robot.Movement_Logic(moveHorizontal, moveVertical);
    }

    private void Rotation()
    {
        if (Input.GetKey(KeyCode.Q))
            robot.Rotation_Logic(1);

        if (Input.GetKey(KeyCode.E))
            robot.Rotation_Logic(2);
    }

    private void Obstacle_scan()
    {
        float[] move = new float[] { 0, 0 };
        bool[] scan = map_scan.RayToScan();

        if (scan[0] == false)
        {
            move[1] = 1f;
            Movement(move);
        }

        else
        {
            move[1] = 0f;
            Movement(move);
            flag = 0;
        }

        if (scan[1] == false && flag == 0)
        {
            move[0] = 1f;
            Movement(move);
        }

        else if (scan[1] == true && flag == 0)
        {
            move[0] = 0f;
            Movement(move);
        }

        if (scan[2] == false && flag == 1)
        {
            move[0] = -1f;
            Movement(move);
        }

        else if (scan[2] == true && flag == 1)
        {
            move[0] = 0f;
            Movement(move);
        }

        Debug.Log(flag.ToString());
    }

}
