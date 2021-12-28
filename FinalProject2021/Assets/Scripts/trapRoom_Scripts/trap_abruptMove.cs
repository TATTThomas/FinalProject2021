using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_abruptMove : MonoBehaviour
{
    //define two different time
    public float downTime, upTime;
    public float moveDistance;
    Vector3 originalPos;
    Vector3 newPos;
    bool isOrigin, isNew;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        newPos = originalPos + moveDistance * Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == originalPos)
        {
            isOrigin = true;
            isNew = false;
        }
        if (transform.position == newPos)
        {
            isOrigin = false;
            isNew = true;
        }
        if (isOrigin)
            transform.position = Vector3.MoveTowards(transform.position, newPos, downTime * Time.deltaTime);
        if (isNew)
            transform.position = Vector3.MoveTowards(transform.position, originalPos, upTime * Time.deltaTime);
    }
}
