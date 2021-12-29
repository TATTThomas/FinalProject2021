using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatFloorController : MonoBehaviour
{
    int time;
    Quaternion targetRotation;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rotate()
    {
        time = 0;
        
        //InvokeRepeating("trueRotate", 0, 0.3f);
    }
}
