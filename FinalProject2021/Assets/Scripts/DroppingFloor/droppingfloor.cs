using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droppingfloor : MonoBehaviour
{
    private bool isTrigger;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player")
        {
            isTrigger = true;
            StartCoroutine(rotate());
        }
    }
    IEnumerator rotate()
    {
        while (transform.eulerAngles.y != 90)
        {
            transform.parent.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(90, 0, 0), Time.deltaTime);
            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        isTrigger = false;
    }
}
