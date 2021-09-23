using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_movement : MonoBehaviour
{
    public float Speed = 5f;
    public float Rotation_Force = 90f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Movement_Logic();
        Rotation_Logic();
    }

    private void Movement_Logic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * Speed * Time.fixedDeltaTime);
    }

    public void Rotation_Logic()
    {
        if (Input.GetKey(KeyCode.Q))
            transform.rotation *= Quaternion.Euler(0f, -Rotation_Force * Time.deltaTime, 0f);

        if (Input.GetKey(KeyCode.E))
            transform.rotation *= Quaternion.Euler(0f, Rotation_Force * Time.deltaTime, 0f);
    }
}
