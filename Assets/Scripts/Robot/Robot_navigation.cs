using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_navigation : MonoBehaviour
{
    private Robot robot;
    private Map_scan map_scan;

    private int move_state = 0;
    float target_angle = 0;

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
        Robot_movements();
    }

    private void Movement(int moveHorizontal, int moveVertical)
    {
        robot.Movement_Logic(moveHorizontal, moveVertical);
    }

    private void Rotation_log(int flag)
    {
        if (flag == 0)
        { 
            move_state = 1;
            robot.Rotation_Logic(0);

            if (transform.eulerAngles.y - target_angle < 1 && transform.eulerAngles.y - target_angle > 0)
            {
                move_state = 0;

                transform.rotation = Quaternion.Euler(0, target_angle, 0);
            }
        }

        if (flag == 1)
        {
            move_state = 1;
            robot.Rotation_Logic(1);

            if (transform.eulerAngles.y - target_angle < 1 && transform.eulerAngles.y - target_angle > 0)
            {
                move_state = 0;
                transform.rotation = Quaternion.Euler(0, target_angle, 0);
            }
        }
    }

    private void Rotation(int direction, int angle)
    {
        if (move_state == 0)
        {
            if (direction == 0)
                target_angle = Mathf.Round(transform.eulerAngles.y) + angle;

            if (direction == 1)
                target_angle = Mathf.Round(transform.eulerAngles.y) - angle;

            if (target_angle >= 360)
                target_angle -= 360;
            else if (target_angle < 0)
                target_angle += 360;
        }

        Rotation_log(direction);
    }

    
    private void Robot_movements()
    {
        int[] scan = map_scan.RayToScan();

        if (scan[0] == 0 && move_state == 0)
        {
            int move_vertical = 1;
            Movement(0, move_vertical);
        }

        else
        {
            Rotation(0, 90);
        }
    }
    
}
