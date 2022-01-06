using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droppingfloor : MonoBehaviour
{
    float r;
    bool rotating = false;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player")
        {
            if (r > 0.5)
            {
                if (!rotating)
                {
                    rotating = true;
                    StartCoroutine(RotateMe(new Vector3(90, 0, 0), 1f));
                    StartCoroutine(rotateBack());
                }
            }
        }
    }
    

    IEnumerator rotateBack()
    {
        Debug.Log("1");
        yield return new WaitForSecondsRealtime(3);
        StartCoroutine(RotateMe(new Vector3(-90, 0, 0), 1f));

        rotating = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        r = Random.value;
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.parent.rotation;
        var toAngle = Quaternion.Euler(transform.parent.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.parent.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        transform.parent.rotation = toAngle;
        Debug.Log("r");
    }
}