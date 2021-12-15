using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    Vector3 spawn_point;
    public GameObject spawner;
    public int robots_count;

    void Start()
    {
        SpawnRobots(robots_count);
        send_robot_num();
    }

    void Update()
    {

    }

    void SpawnRobots(int robots_count)
    {
        float posX = 4f;
        float posY = 0.5f;
        float posZ = 7f;

        for (int i = 0; i < robots_count; i++)
        {
            spawn_point = new Vector3(posX, posY, posZ);
            Instantiate(prefab, spawn_point, Quaternion.Euler(0, 180, 0));
            posZ += 1.5f;            
        }
    }

    void send_robot_num()
    {
        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");
        int robot_num = 0;

        for(int i = 0; i < robots.Length; i++)
        {
            robots[i].SendMessage("get_robot_num", robot_num);
            robot_num += 1;
        }        
    }
}