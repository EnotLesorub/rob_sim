using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_brain : MonoBehaviour
{
    private Robot_navigation robot;
    
    void Start()
    {
        robot = GetComponent<Robot_navigation>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
