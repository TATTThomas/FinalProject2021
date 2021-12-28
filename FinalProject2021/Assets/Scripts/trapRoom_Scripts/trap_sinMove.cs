using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_sinMove : MonoBehaviour
{

    public Vector3 moveDirection;
    Vector3 originalPos;
    public float frequency;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float offest = Mathf.Sin(Time.time * frequency) * 1.5f;
        transform.position = originalPos + offest * moveDirection;
    }
}
