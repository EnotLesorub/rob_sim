using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float position_x;
    public float position_z;

    public float charge = 100f;

    private float speed = 2f;
    private float rotation_speed = 90f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Movement_Logic(float moveHorizontal, float moveVertical)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.fixedDeltaTime);
    }

    public void Rotation_Logic(int flag)
    {
        if (flag == 1)
            transform.rotation *= Quaternion.Euler(0f, -rotation_speed * Time.deltaTime, 0f);

        if (flag == 2)
            transform.rotation *= Quaternion.Euler(0f, rotation_speed * Time.deltaTime, 0f);
    }
}
