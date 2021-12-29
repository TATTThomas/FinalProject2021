using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoad : MonoBehaviour
{

    bool rotating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate_road()
    {
        if (!rotating)
        {
            rotating = true;
            StartCoroutine(RotateMe(new Vector3(0, 90, 0), 1));
        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        transform.rotation = toAngle;
        rotating = false;
    }
}
