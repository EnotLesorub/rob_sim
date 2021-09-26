using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_navigation : MonoBehaviour
{
    private Robot robot;
    private Map_scan map_scan;

    private string target_tag = "Robot";
    private Transform target;

    private int _flag = 0;
    float _angle = 0;

    void Start()
    {
        robot = GetComponent<Robot>();
        map_scan = GetComponent<Map_scan>();
        target = GameObject.FindGameObjectWithTag(target_tag).transform;
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
            _flag = 1;
            robot.Rotation_Logic(0);

            if (target.eulerAngles.y - _angle < 1 && target.eulerAngles.y - _angle > 0)
            {
                _flag = 0;

                transform.rotation = Quaternion.Euler(0, _angle, 0);
            }
        }

        if (flag == 1)
        {
            _flag = 1;
            robot.Rotation_Logic(1);

            if (target.eulerAngles.y - _angle < 1 && target.eulerAngles.y - _angle > 0)
            {
                _flag = 0;
                transform.rotation = Quaternion.Euler(0, _angle, 0);
            }
        }
    }

    private void Rotation(int direction, int angle)
    {
        if (_flag == 0)
        {
            if (direction == 0)
                _angle = Mathf.Round(target.eulerAngles.y) + angle;

            if (direction == 1)
                _angle = Mathf.Round(target.eulerAngles.y) - angle;

            if (_angle >= 360)
                _angle -= 360;
            else if (_angle < 0)
                _angle += 360; 
        }

        Rotation_log(direction);
    }

    private void Robot_movements()
    {
        bool[] scan = map_scan.RayToScan();

        if (scan[0] == false && _flag == 0)
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
