using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float position_x;
    public float position_z;

    public float charge = 100f;

    private float speed = 2f;
    private float rotation_speed = 45;

    public void Movement_Logic(float moveHorizontal, float moveVertical)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    public void Rotation_Logic(int flag)
    {
        if (flag == 0)
            transform.Rotate(new Vector3(0, rotation_speed, 0) * Time.deltaTime);
        if (flag == 1)
            transform.Rotate(new Vector3(0, -rotation_speed, 0) * Time.deltaTime);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
